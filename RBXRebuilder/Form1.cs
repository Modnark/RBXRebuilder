using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.ComponentModel;
using System.Text;

namespace RBXRebuilder
{
    public partial class Form1 : Form
    {
        private PatchReader reader = new PatchReader();
        private PropertyGrid propertyGrid = new PropertyGrid();
        private string fileLocation = String.Empty;

        public Form1()
        {
            InitializeComponent();
            PatchMenu.SelectedObject = propertyGrid;

            // Get all available patches
            LoadPatches();
        }

        private void LoadPatches()
        {
            ClientSelect.Items.Clear();
            List<string> patches = reader.GetPatches();
            foreach (string patch in patches)
            {
                ClientSelect.Items.Add(patch);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ClientSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            
            PatchButton.Enabled = true;
            try
            {
                string fileName = "Patches\\" + ClientSelect.SelectedItem.ToString();
                reader.UpdateProperties(PatchMenu, propertyGrid, fileName);
            } catch(Exception ex)
            {
#if DEBUG
                MessageBox.Show("RBX Rebuilder", "An exception occured while loading patch: " + ex.Message);
#else
                MessageBox.Show("RBX Rebuilder", "An exception occured while loading patch.");
#endif
                LoadPatches();
            }
            PatchMenu.Refresh();
        }

        private void openClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openClient = new OpenFileDialog())
            {
                openClient.Filter = "EXE Files (*.exe)|*.exe|All files (*.*)|*.*";
                openClient.FilterIndex = 1;

                if (openClient.ShowDialog() == DialogResult.OK)
                {
                    fileLocation = openClient.FileName;
                    statusStrip1.Items[0].Text = "Ready";
                    ClientSelect.Enabled = true;
                }
            }
        }

        private bool PatchByte(byte toWrite, long seek, Stream outStream)
        {
            try
            {
                outStream.Seek(seek, SeekOrigin.Begin);
                outStream.WriteByte(toWrite);
                return true;
            } catch
            {
                return false;
            }
        }

        private void PatchButton_Click(object sender, EventArgs e)
        {
            if(fileLocation == String.Empty)
            {
                MessageBox.Show("Please select a client EXE (File > Open Client)", "RBX Rebuilder");
            } else
            {
                if(File.Exists(fileLocation))
                {
                    // Determine the patches we want to apply
                    List<string> patchList = new List<string>();
                    foreach (Property patch in propertyGrid)
                    {
                        if (!patch.ReadOnly)
                        {
                            bool canAdd = false;
                            switch(patch.Value.GetType().ToString())
                            {
                                case "System.String":
                                    if ((string)patch.Value != String.Empty)
                                        canAdd = true;
                                    break;
                                case "System.Boolean":
                                    if ((bool)patch.Value != false)
                                        canAdd = true;
                                    break;
                                case "System.Int16":
                                    if ((int)patch.Value != 0)
                                        canAdd = true;
                                    break;
                                default:
                                    canAdd = false;
                                    break;
                            }
                            if(canAdd)
                                patchList.Add(patch.Name);
                        }
                    }

                    if (patchList.Count == 0)
                    {
                        MessageBox.Show("Please choose at least one patch", "RBX Rebuilder");
                    }
                    else
                    {
                        PatchReport patchReport = new PatchReport(patchList);
                        DialogResult result = patchReport.ShowDialog();
                        if(result == DialogResult.OK)
                        {
                            using (SaveFileDialog saveClient = new SaveFileDialog())
                            {
                                saveClient.Filter = "EXE Files (*.exe)|*.exe|All files (*.*)|*.*";
                                saveClient.FilterIndex = 1;

                                if (saveClient.ShowDialog() == DialogResult.OK)
                                {
                                    string saveLocation = saveClient.FileName;
                                    // Delete client in location if it exists
                                    if (File.Exists(saveLocation))
                                        File.Delete(saveLocation);

                                    // Copy source client to save location
                                    File.Copy(fileLocation, saveLocation);

                                    // Open stream for writing
                                    Stream outStream = File.Open(saveLocation, FileMode.Open);

                                    // Get all of the patch values & offsets
                                    XmlDocument xmlDocument = new XmlDocument();
                                    xmlDocument.Load("Patches\\" + ClientSelect.SelectedItem.ToString());

                                    XmlNodeList offsets = xmlDocument.GetElementsByTagName("Offset");
                                    foreach (XmlNode offset in offsets)
                                    {
                                        XmlNode patchInf = offset.ParentNode.ParentNode.ParentNode.FirstChild.SelectSingleNode("String[@name='Title']");
                                        XmlNode patchVal = offset.ParentNode;

                                        string patchName = patchInf.InnerText;
                                        if (patchList.Contains(patchName))
                                        {
                                            foreach(Property property in propertyGrid)
                                            {
                                                if (property.Name == patchName)
                                                {
                                                    bool multiByte = false;

                                                    string patchByte = "";
                                                    
                                                    // Check if the parent contains the value, or if the child has the value
                                                    if(patchVal.Attributes.GetNamedItem("value") == null)
                                                    {
                                                        patchByte = offset.Attributes["value"].InnerText;
                                                    } else
                                                    {
                                                        patchByte = patchVal.Attributes["value"].InnerText;
                                                    }

                                                    // Check if they're special case
                                                    switch(patchByte)
                                                    {
                                                        case "LEN":
                                                            patchByte = property.Value.ToString().Length.ToString();
                                                            break;
                                                        case "STR":
                                                            multiByte = true;
                                                            break;
                                                    }

                                                    string patchOffset = offset.InnerText;
                                                    bool success;
                                                    long seek = Convert.ToInt64(patchOffset, 16);

                                                    // See if we should write multiple bytes
                                                    if (multiByte)
                                                    {
                                                        byte[] bytes = Encoding.ASCII.GetBytes(property.Value.ToString());
                                                        foreach (byte toWrite in bytes)
                                                        {
                                                            success = PatchByte(toWrite, seek, outStream);
                                                            if (!success)
                                                            {
                                                                outStream.Close();
                                                                if (File.Exists(saveLocation))
                                                                    File.Delete(saveLocation);
                                                                MessageBox.Show("Failed to write \"" + patchByte + "\" @ \"" + patchOffset + "\"", "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            }
                                                            seek += 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        byte toWrite;
                                                        success = byte.TryParse(patchByte, out toWrite);
                                                        if (!success)
                                                        {
                                                            outStream.Close();
                                                            if (File.Exists(saveLocation))
                                                                File.Delete(saveLocation);
                                                            MessageBox.Show("Failed to parse \"" + patchByte + "\" @ \"" + patchOffset + "\"", "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            return;
                                                        }
                                                        else
                                                        {
                                                            success = PatchByte(toWrite, seek, outStream);
                                                            if(!success)
                                                            {
                                                                outStream.Close();
                                                                if (File.Exists(saveLocation))
                                                                    File.Delete(saveLocation);
                                                                MessageBox.Show("Failed to write \"" + patchByte + "\" @ \"" + patchOffset + "\"", "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    outStream.Close();
                                }
                            }
                        }
                    }
                } else
                {
                    MessageBox.Show("The chosen client EXE could not be found", "RBX Rebuilder");
                    statusStrip1.Items[1].Text = "Choose a client";
                    ClientSelect.Enabled = false;
                    propertyGrid.Clear();
                    PatchMenu.Refresh();
                    fileLocation = "";
                }
            }
        }

        private void downloadPatchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Modnark/RBXRB-Patch-files/tree/main/Patches");
        }
    }
}
