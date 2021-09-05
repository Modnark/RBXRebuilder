using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RBXRebuilder
{
    public partial class PatchReport : Form
    {
        public PatchReport(List<string> patchList)
        {
            InitializeComponent();
            foreach(string patch in patchList)
            {
                PatchList.Items.Add(patch);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyPatch_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
