using System.Collections.Generic;
using System.Xml;
using System.IO;
using System;
using System.Windows.Forms;

namespace RBXRebuilder
{
    class PatchReader
    {
        private const string SIGNATURE = "RBXRB";
        private string[] VALID_META = {"Patch Author", "Build Version", "Client Date"};
        private string[] VALID_PATCH_INF = { "Title", "Type", "Description", "Category" };

        public void PatchFileProblem(string reason, PropertyGrid propGrid1)
        {
            MessageBox.Show("This patch file is invalid\nReason: " + reason, "RBX Rebuilder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            propGrid1.Clear();
        }

        public List<string> GetPatches()
        {
            List<string> patches = new List<string>();
            // If the "Patches" directory is not found, create it
            if(!Directory.Exists("Patches"))
            {
                Directory.CreateDirectory("Patches");
            }

            // Get all .xml files from directory
            foreach(string fileName in Directory.GetFiles("Patches"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                string rootName = doc.SelectSingleNode("/*").Name;

                // Verify that it's a valid patch file
                if (rootName == SIGNATURE)
                {
                    patches.Add(Path.GetFileName(fileName));
                }
            }

            return patches;
        }

        // This is sloppy, will fix later
        public void UpdateProperties(object propGrid, PropertyGrid propGrid1, string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            // Clear the propgrid
            propGrid1.Clear();

            foreach (XmlNode node in doc.SelectNodes("/RBXRB"))
            {
                // Read the metadata
                foreach (XmlNode itemNode in node.SelectNodes("Meta"))
                {
                    foreach (XmlNode metaData in itemNode.SelectNodes("String"))
                    {
                        string metaName = metaData.Attributes["name"].Value;
                        // Make sure the meta tag is valid
                        if (Array.Exists(VALID_META, metaTag => metaTag == metaName))
                        {
                            Property metaProp = new Property(metaData.Attributes["name"].Value, String.Empty, "Patch Info", metaData.InnerText, true, true); ;
                            propGrid1.Add(metaProp);
                        }
                    }
                }

                // Read Patch elements
                foreach (XmlNode itemNode in node.SelectNodes("Patch"))
                {
                    XmlNode patchInf = itemNode.SelectSingleNode("PatchInfo");
                    if (patchInf != null) {
                        XmlNode titleNode = patchInf.SelectSingleNode("String[@name='Title']");
                        XmlNode typeNode = patchInf.SelectSingleNode("String[@name='Type']");
                        XmlNode descNode = patchInf.SelectSingleNode("String[@name='Description']");
                        XmlNode catNode = patchInf.SelectSingleNode("String[@name='Category']");
                        XmlNode securityNode = patchInf.SelectSingleNode("String[@name='SecurityWarning']");
                        
                        dynamic value = false;

                        if (titleNode == null)
                        {
                            PatchFileProblem("Missing \"Title\" node.", propGrid1);
                            break;
                        }

                        if (typeNode == null)
                        {
                            PatchFileProblem("Missing \"Title\" node.", propGrid1);
                            break;
                        }

                        string patchDesc = String.Empty;
                        string patchCat = "Default Category";

                        if (descNode != null)
                        {
                            patchDesc = descNode.InnerText;
                        }

                        if(catNode != null)
                        {
                            patchCat = catNode.InnerText;
                        }

                        if (securityNode != null)
                        {
                            patchDesc += "\nWarning: " + securityNode.InnerText;
                        }

                        switch(typeNode.InnerText)
                        {
                            case "Bool":
                                value = false;
                                break;
                            case "String":
                                value = "";
                                break;
                            case "Int":
                                value = 0;
                                break;
                            default:
                                value = false;
                                break;
                        }

                        Property patchProp = new Property(titleNode.InnerText, patchDesc, patchCat, value, false, true); ;
                        propGrid1.Add(patchProp);
                    } else
                    {
                        PatchFileProblem("Missing \"PatchInfo\" node.", propGrid1);
                        break;
                    }
                }
            }
        }
    }
}
