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
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            TB_ADB_Folder.Text = Properties.Settings.Default.ADB_Folder;
            TB_apkFolder.Text = Properties.Settings.Default.apkFolder;
            TB_apktool_Folder.Text = Properties.Settings.Default.apktool_Folder;
            TB_assetsFolder.Text = Properties.Settings.Default.assetsFolder;
            TB_backupFolder.Text = Properties.Settings.Default.backupFolder;
            TB_BeatMapAssetMaker_Folder.Text = Properties.Settings.Default.BeatMapAssetMaker_Folder;
            TB_JARSIGNERLOC_Folder.Text = Properties.Settings.Default.JARSIGNERLOC_Folder;
            TB_songeconverter_Folder.Text = Properties.Settings.Default.songeconverter_Folder;
            TB_SongsToLoadFolder.Text = Properties.Settings.Default.SongsToLoadFolder;
            TB_AvailableSongsFolder.Text = Properties.Settings.Default.AvailableSongsFolder;
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ADB_Folder = TB_ADB_Folder.Text;
            Properties.Settings.Default.apkFolder = TB_apkFolder.Text;
            Properties.Settings.Default.apktool_Folder = TB_apktool_Folder.Text;
            Properties.Settings.Default.assetsFolder = TB_assetsFolder.Text;
            Properties.Settings.Default.backupFolder = TB_backupFolder.Text;
            Properties.Settings.Default.BeatMapAssetMaker_Folder = TB_BeatMapAssetMaker_Folder.Text;
            Properties.Settings.Default.JARSIGNERLOC_Folder = TB_JARSIGNERLOC_Folder.Text;
            Properties.Settings.Default.songeconverter_Folder = TB_songeconverter_Folder.Text;
            Properties.Settings.Default.SongsToLoadFolder = TB_SongsToLoadFolder.Text;
            Properties.Settings.Default.AvailableSongsFolder = TB_AvailableSongsFolder.Text;

            Properties.Settings.Default.Save();

            Close();
        }
    }
}
