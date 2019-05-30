namespace BeatSaberQuestSongloader
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
            this.LB_AvailableSongs = new System.Windows.Forms.ListBox();
            this.BT_TransferSongsToSongsToLoad = new System.Windows.Forms.Button();
            this.BT_DeleteSongsToLoad = new System.Windows.Forms.Button();
            this.LB_SongsToLoad = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BT_Load = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BTN_Unload = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_AvailableSongs
            // 
            this.LB_AvailableSongs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LB_AvailableSongs.FormattingEnabled = true;
            this.LB_AvailableSongs.Location = new System.Drawing.Point(12, 50);
            this.LB_AvailableSongs.Name = "LB_AvailableSongs";
            this.LB_AvailableSongs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LB_AvailableSongs.Size = new System.Drawing.Size(294, 472);
            this.LB_AvailableSongs.TabIndex = 0;
            // 
            // BT_TransferSongsToSongsToLoad
            // 
            this.BT_TransferSongsToSongsToLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BT_TransferSongsToSongsToLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_TransferSongsToSongsToLoad.Location = new System.Drawing.Point(330, 201);
            this.BT_TransferSongsToSongsToLoad.Name = "BT_TransferSongsToSongsToLoad";
            this.BT_TransferSongsToSongsToLoad.Size = new System.Drawing.Size(61, 54);
            this.BT_TransferSongsToSongsToLoad.TabIndex = 1;
            this.BT_TransferSongsToSongsToLoad.Text = ">";
            this.BT_TransferSongsToSongsToLoad.UseVisualStyleBackColor = true;
            this.BT_TransferSongsToSongsToLoad.Click += new System.EventHandler(this.BT_TransferSongsToSongsToLoad_Click);
            // 
            // BT_DeleteSongsToLoad
            // 
            this.BT_DeleteSongsToLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BT_DeleteSongsToLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_DeleteSongsToLoad.Location = new System.Drawing.Point(330, 271);
            this.BT_DeleteSongsToLoad.Name = "BT_DeleteSongsToLoad";
            this.BT_DeleteSongsToLoad.Size = new System.Drawing.Size(61, 54);
            this.BT_DeleteSongsToLoad.TabIndex = 2;
            this.BT_DeleteSongsToLoad.Text = "<";
            this.BT_DeleteSongsToLoad.UseVisualStyleBackColor = true;
            this.BT_DeleteSongsToLoad.Click += new System.EventHandler(this.BT_DeleteSongsToLoad_Click);
            // 
            // LB_SongsToLoad
            // 
            this.LB_SongsToLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_SongsToLoad.FormattingEnabled = true;
            this.LB_SongsToLoad.Location = new System.Drawing.Point(417, 50);
            this.LB_SongsToLoad.Name = "LB_SongsToLoad";
            this.LB_SongsToLoad.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LB_SongsToLoad.Size = new System.Drawing.Size(295, 472);
            this.LB_SongsToLoad.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Available Songs:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Songs to load on Quest:";
            // 
            // BT_Load
            // 
            this.BT_Load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Load.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_Load.Location = new System.Drawing.Point(725, 438);
            this.BT_Load.Name = "BT_Load";
            this.BT_Load.Size = new System.Drawing.Size(229, 102);
            this.BT_Load.TabIndex = 6;
            this.BT_Load.Text = "Load";
            this.BT_Load.UseVisualStyleBackColor = true;
            this.BT_Load.Click += new System.EventHandler(this.BT_Load_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // BTN_Unload
            // 
            this.BTN_Unload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Unload.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Unload.Location = new System.Drawing.Point(725, 50);
            this.BTN_Unload.Name = "BTN_Unload";
            this.BTN_Unload.Size = new System.Drawing.Size(229, 102);
            this.BTN_Unload.TabIndex = 8;
            this.BTN_Unload.Text = "Unload";
            this.BTN_Unload.UseVisualStyleBackColor = true;
            this.BTN_Unload.Click += new System.EventHandler(this.BTN_Unload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 575);
            this.Controls.Add(this.BTN_Unload);
            this.Controls.Add(this.BT_Load);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_SongsToLoad);
            this.Controls.Add(this.BT_DeleteSongsToLoad);
            this.Controls.Add(this.BT_TransferSongsToSongsToLoad);
            this.Controls.Add(this.LB_AvailableSongs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Beat Saber Songloader for Quest";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_AvailableSongs;
        private System.Windows.Forms.Button BT_TransferSongsToSongsToLoad;
        private System.Windows.Forms.Button BT_DeleteSongsToLoad;
        private System.Windows.Forms.ListBox LB_SongsToLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_Load;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button BTN_Unload;
    }
}

