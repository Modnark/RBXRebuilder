
namespace RBXRebuilder
{
    partial class PatchReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ApplyPatch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.PatchList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ApplyPatch
            // 
            this.ApplyPatch.Location = new System.Drawing.Point(12, 249);
            this.ApplyPatch.Name = "ApplyPatch";
            this.ApplyPatch.Size = new System.Drawing.Size(75, 23);
            this.ApplyPatch.TabIndex = 1;
            this.ApplyPatch.Text = "Patch";
            this.ApplyPatch.UseVisualStyleBackColor = true;
            this.ApplyPatch.Click += new System.EventHandler(this.ApplyPatch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Below is a list of patches to be applied";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(93, 249);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // PatchList
            // 
            this.PatchList.FormattingEnabled = true;
            this.PatchList.Location = new System.Drawing.Point(12, 25);
            this.PatchList.Name = "PatchList";
            this.PatchList.Size = new System.Drawing.Size(321, 212);
            this.PatchList.TabIndex = 4;
            // 
            // PatchReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 284);
            this.Controls.Add(this.PatchList);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ApplyPatch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatchReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Patch Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ApplyPatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ListBox PatchList;
    }
}