namespace BeatSaberQuestSongloader
{
    partial class FolderForm
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
            this.TB_Folder = new System.Windows.Forms.TextBox();
            this.LBL_Header = new System.Windows.Forms.Label();
            this.LNKLBL_LinkToWebsite = new System.Windows.Forms.LinkLabel();
            this.BTN_Browse = new System.Windows.Forms.Button();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_Folder
            // 
            this.TB_Folder.Location = new System.Drawing.Point(12, 87);
            this.TB_Folder.Name = "TB_Folder";
            this.TB_Folder.Size = new System.Drawing.Size(381, 20);
            this.TB_Folder.TabIndex = 0;
            // 
            // LBL_Header
            // 
            this.LBL_Header.AutoSize = true;
            this.LBL_Header.Location = new System.Drawing.Point(12, 25);
            this.LBL_Header.Name = "LBL_Header";
            this.LBL_Header.Size = new System.Drawing.Size(35, 13);
            this.LBL_Header.TabIndex = 1;
            this.LBL_Header.Text = "label1";
            // 
            // LNKLBL_LinkToWebsite
            // 
            this.LNKLBL_LinkToWebsite.AutoSize = true;
            this.LNKLBL_LinkToWebsite.Location = new System.Drawing.Point(12, 166);
            this.LNKLBL_LinkToWebsite.Name = "LNKLBL_LinkToWebsite";
            this.LNKLBL_LinkToWebsite.Size = new System.Drawing.Size(55, 13);
            this.LNKLBL_LinkToWebsite.TabIndex = 2;
            this.LNKLBL_LinkToWebsite.TabStop = true;
            this.LNKLBL_LinkToWebsite.Text = "linkLabel1";
            // 
            // BTN_Browse
            // 
            this.BTN_Browse.Location = new System.Drawing.Point(399, 84);
            this.BTN_Browse.Name = "BTN_Browse";
            this.BTN_Browse.Size = new System.Drawing.Size(75, 23);
            this.BTN_Browse.TabIndex = 3;
            this.BTN_Browse.Text = "Browse";
            this.BTN_Browse.UseVisualStyleBackColor = true;
            this.BTN_Browse.Click += new System.EventHandler(this.BTN_Browse_Click);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(399, 191);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save.TabIndex = 4;
            this.BTN_Save.Text = "Save";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // FolderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 226);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.BTN_Browse);
            this.Controls.Add(this.LNKLBL_LinkToWebsite);
            this.Controls.Add(this.LBL_Header);
            this.Controls.Add(this.TB_Folder);
            this.Name = "FolderForm";
            this.Text = "FolderForm";
            this.Load += new System.EventHandler(this.FolderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Folder;
        private System.Windows.Forms.Label LBL_Header;
        private System.Windows.Forms.LinkLabel LNKLBL_LinkToWebsite;
        private System.Windows.Forms.Button BTN_Browse;
        private System.Windows.Forms.Button BTN_Save;
    }
}