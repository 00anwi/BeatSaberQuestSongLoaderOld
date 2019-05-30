using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeatSaberQuestSongloader
{
    public partial class FolderForm : Form
    {
        string ForSetting, LinkLabel, TextLabel;
        public FolderForm(string GetForSetting, string GetLinkLabel, string GetTextLabel)
        {
            InitializeComponent();

            ForSetting = GetForSetting;
            LNKLBL_LinkToWebsite.Text = GetLinkLabel;
            LBL_Header.Text = GetTextLabel;
        }

        private void FolderForm_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TB_Folder.Text))
            {
                MessageBox.Show("You have to choose a folder!");
                return;
            }

            if(ForSetting == "AvailableSongsFolder")
            {
                Properties.Settings.Default.AvailableSongsFolder = TB_Folder.Text;
            }
            else if(ForSetting == "JARSIGNERLOC_Folder")
            {
                Properties.Settings.Default.JARSIGNERLOC_Folder = TB_Folder.Text;
            }
            else if (ForSetting == "songeconverter_Folder")
            {
                Properties.Settings.Default.songeconverter_Folder = TB_Folder.Text;
            }
            else if (ForSetting == "ADB_Folder")
            {
                Properties.Settings.Default.ADB_Folder = TB_Folder.Text;
            }
            else if (ForSetting == "apktool_Folder")
            {
                Properties.Settings.Default.apktool_Folder = TB_Folder.Text;
            }
            else if (ForSetting == "BeatMapAssetMaker_Folder")
            {
                Properties.Settings.Default.BeatMapAssetMaker_Folder = TB_Folder.Text;
            }


            Properties.Settings.Default.Save();

            this.Close();
        }

        private string OpenFolder()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    return fbd.SelectedPath.ToString();
                }
                return "";
            }
        }

        private void BTN_Browse_Click(object sender, EventArgs e)
        {
            var folder = OpenFolder();

            TB_Folder.Text = folder;
        }


    }
}
