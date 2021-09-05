
namespace RBXRebuilder
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ClientSelect = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PatchMenu = new System.Windows.Forms.PropertyGrid();
            this.PatchButton = new System.Windows.Forms.Button();
            this.downloadPatchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientSelect
            // 
            this.ClientSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClientSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientSelect.Enabled = false;
            this.ClientSelect.FormattingEnabled = true;
            this.ClientSelect.Location = new System.Drawing.Point(0, 24);
            this.ClientSelect.Name = "ClientSelect";
            this.ClientSelect.Size = new System.Drawing.Size(403, 21);
            this.ClientSelect.TabIndex = 0;
            this.ClientSelect.SelectedValueChanged += new System.EventHandler(this.ClientSelect_SelectedValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(403, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openClientToolStripMenuItem,
            this.downloadPatchesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // PatchMenu
            // 
            this.PatchMenu.Location = new System.Drawing.Point(0, 51);
            this.PatchMenu.Name = "PatchMenu";
            this.PatchMenu.Size = new System.Drawing.Size(403, 342);
            this.PatchMenu.TabIndex = 2;
            // 
            // PatchButton
            // 
            this.PatchButton.Enabled = false;
            this.PatchButton.Location = new System.Drawing.Point(12, 403);
            this.PatchButton.Name = "PatchButton";
            this.PatchButton.Size = new System.Drawing.Size(75, 23);
            this.PatchButton.TabIndex = 3;
            this.PatchButton.Text = "Patch";
            this.PatchButton.UseVisualStyleBackColor = true;
            this.PatchButton.Click += new System.EventHandler(this.PatchButton_Click);
            // 
            // downloadPatchesToolStripMenuItem
            // 
            this.downloadPatchesToolStripMenuItem.Name = "downloadPatchesToolStripMenuItem";
            this.downloadPatchesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.downloadPatchesToolStripMenuItem.Text = "Get More Patches";
            this.downloadPatchesToolStripMenuItem.Click += new System.EventHandler(this.downloadPatchesToolStripMenuItem_Click);
            // 
            // openClientToolStripMenuItem
            // 
            this.openClientToolStripMenuItem.Name = "openClientToolStripMenuItem";
            this.openClientToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openClientToolStripMenuItem.Text = "Open Client";
            this.openClientToolStripMenuItem.Click += new System.EventHandler(this.openClientToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(403, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "Choose a client";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(88, 17);
            this.toolStripStatusLabel1.Text = "Choose a client";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 453);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.PatchButton);
            this.Controls.Add(this.PatchMenu);
            this.Controls.Add(this.ClientSelect);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RBX Rebuilder";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ClientSelect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid PatchMenu;
        private System.Windows.Forms.Button PatchButton;
        private System.Windows.Forms.ToolStripMenuItem downloadPatchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openClientToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

