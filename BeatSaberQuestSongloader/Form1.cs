using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeatSaberQuestSongloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private class SongData
        {
            public string SongName { get; set; }
            public string SongFolder { get; set; }
        }

        List<SongData> AvailableSongs = new List<SongData>();
        List<SongData> SongsToLoad = new List<SongData>();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var SongsToLoadfolder = Properties.Settings.Default.SongsToLoadFolder;
                // If the directory doesn't exist, create it.
                if (!Directory.Exists(SongsToLoadfolder))
                {
                    Directory.CreateDirectory(SongsToLoadfolder);
                }

                var apkFolder = Properties.Settings.Default.apkFolder;
                if (!Directory.Exists(apkFolder))
                {
                    Directory.CreateDirectory(apkFolder);
                }

                var assetsFolder = Properties.Settings.Default.assetsFolder;
                if (!Directory.Exists(assetsFolder))
                {
                    Directory.CreateDirectory(assetsFolder);
                }

                var backupFolder = Properties.Settings.Default.backupFolder;
                if (!Directory.Exists(backupFolder))
                {
                    Directory.CreateDirectory(backupFolder);
                }
            }
            catch (Exception)
            {
                // Fail silently
            }

            CheckAllFolders();

            LoadAvailableSongs();

            LoadSongsToLoad();

            LoadSongsToListBoxes();

        }

        private bool CheckAllFolders()
        {
            bool AllOK = true;

            var AvailableSongsFolderPath = Properties.Settings.Default.AvailableSongsFolder;

            if (String.IsNullOrEmpty(AvailableSongsFolderPath))
            {
                FolderForm x = new FolderForm("AvailableSongsFolder", "", "Choose the folder where you save your custom songs");
                x.ShowDialog();

                AllOK = false;
            }

            var SongsToLoadFolderPath = Properties.Settings.Default.SongsToLoadFolder;

            if (String.IsNullOrEmpty(SongsToLoadFolderPath))
            {
                FolderForm x = new FolderForm("SongsToLoadFolder", "", "Choose the folder where program should save the Songs To Load to Quest");
                x.ShowDialog();

                AllOK = false;
            }

            var JARSIGNERLOC_FolderPath = Properties.Settings.Default.JARSIGNERLOC_Folder;

            if (String.IsNullOrEmpty(JARSIGNERLOC_FolderPath))
            {
                FolderForm x = new FolderForm("JARSIGNERLOC_Folder", "https://www.oracle.com/technetwork/java/javase/downloads/jdk12-downloads-5295953.html", "Choose the bin folder where Java JDK is installed. If you don't have it installed download and install from link below");
                x.ShowDialog();

                AllOK = false;
            }

            var ADB_FolderPath = Properties.Settings.Default.ADB_Folder;

            if (String.IsNullOrEmpty(ADB_FolderPath))
            {
                FolderForm x = new FolderForm("ADB_Folder", "https://developer.android.com/studio/releases/platform-tools", "Choose the folder where ADB is saved. If you don't have it download from link below");
                x.ShowDialog();

                AllOK = false;
            }

            var apktool_FolderPath = Properties.Settings.Default.apktool_Folder;

            if (String.IsNullOrEmpty(apktool_FolderPath))
            {
                FolderForm x = new FolderForm("apktool_Folder", "https://ibotpeaches.github.io/Apktool/", "Choose the folder where apktool is saved. If you don't have it download 2.4.0 from link below");
                x.ShowDialog();

                AllOK = false;
            }

            var songeconverter_FolderPath = Properties.Settings.Default.songeconverter_Folder;

            if (String.IsNullOrEmpty(songeconverter_FolderPath))
            {
                FolderForm x = new FolderForm("songeconverter_Folder", "https://github.com/lolPants/songe-converter/releases", "Choose the folder where apktool is saved. If you don't have it download from link below");
                x.ShowDialog();

                AllOK = false;
            }

            return AllOK;
        }

        private void LoadSongsToListBoxes()
        {
            LB_AvailableSongs.Items.Clear();
            LB_SongsToLoad.Items.Clear();

            foreach(var song in SongsToLoad)
            {
                LB_SongsToLoad.Items.Add(song.SongName);
            }

            foreach(var song in AvailableSongs)
            {
                var anySongInSongsToLoad = SongsToLoad.Where(s => s.SongName == song.SongName);

                if(!anySongInSongsToLoad.Any())
                {
                    LB_AvailableSongs.Items.Add(song.SongName);
                }
            }
            
        }

        private void LoadAvailableSongs()
        {
            var path = Properties.Settings.Default.AvailableSongsFolder;

            AvailableSongs = songDatas(path);
        }

        private void LoadSongsToLoad()
        {
            var path = Properties.Settings.Default.SongsToLoadFolder;

            SongsToLoad = songDatas(path);
        }

        private List<SongData> songDatas(string path)
        {
            var songList = new List<SongData>();

            foreach (var subdir in Directory.GetDirectories(path))
            {
                string filepathNewInfo = $"{subdir}/info.dat";
                string filepathOldInfo = $"{subdir}/info.json";
                string songName = null;

                if (FileExist(filepathNewInfo))
                {
                    songName = ParseNewInfoFileAndReturnSongName(filepathNewInfo, subdir);
                }
                else if (FileExist(filepathOldInfo))
                {
                    songName = ParseOldInfoFileAndReturnSongName(filepathOldInfo, subdir);
                }

                if (!String.IsNullOrEmpty(songName))
                {
                    var anySong = songList.Where(s => s.SongName == songName);

                    if (!anySong.Any())
                    {
                        var availibleSong = new SongData
                        {
                            SongFolder = subdir,
                            SongName = songName
                        };
                        songList.Add(availibleSong);
                    }
                }
            }

            return songList;
        }

        static bool FileExist(string FilePath)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                return false;
            }
            else
            {
                if (File.Exists(FilePath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void ChangeSongAndCoverNamesAndCheckPNGs()
        {
            Directory.GetCurrentDirectory();
            var path = Path.Combine(Directory.GetCurrentDirectory(), Properties.Settings.Default.SongsToLoadFolder);
            foreach (var subdir in Directory.GetDirectories(path))
            {
                string filepathNewInfo = $"{subdir}/info.dat";
                string filepathOldInfo = $"{subdir}/info.json";

                if (FileExist(filepathNewInfo))
                {
                    ParseNewInfoFile(filepathNewInfo, subdir);
                }
                else if (FileExist(filepathOldInfo))
                {
                    ParseOldInfoFile(filepathOldInfo, subdir);

                }
            }
        }

        static void ParseNewInfoFile(string filepath, string subdir)
        {
            string result = string.Empty;

            using (StreamReader r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);
                foreach (var item in jobj.Properties())
                {
                    if (item.Name == "_songFilename" && item.Value.ToString() == "song.ogg")
                    {
                        var songName = jobj.Properties().Single(s => s.Name == "_songName").Value.ToString() + ".ogg";
                        var isValid = !string.IsNullOrEmpty(songName) &&
                            songName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 &&
                            !File.Exists(Path.Combine(subdir, songName));

                        if (!isValid)
                        {
                            songName = string.Join("", songName.Split(Path.GetInvalidFileNameChars()));
                        }

                        item.Value = songName;

                        if (FileExist(subdir + "/song.ogg"))
                        {
                            File.Move(subdir + "/song.ogg", subdir + "/" + songName);
                        }

                        Console.WriteLine("Changed name off song.ogg to" + songName);
                    }

                    if (item.Name == "_coverImageFilename" && item.Value.ToString() == "cover.jpg" || item.Value.ToString() == "cover.png")
                    {
                        var extension = Path.GetExtension(item.Value.ToString()).ToLowerInvariant();
                        var songName = jobj.Properties().Single(s => s.Name == "_songName").Value.ToString() + extension;
                        var isValid = !string.IsNullOrEmpty(songName) &&
                            songName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 &&
                            !File.Exists(Path.Combine(subdir, songName));

                        if (!isValid)
                        {
                            songName = string.Join("", songName.Split(Path.GetInvalidFileNameChars()));
                        }

                        item.Value = songName;

                        if (FileExist(subdir + "/cover" + extension))
                        {
                            File.Move(subdir + "/cover" + extension, subdir + "/" + songName);
                        }

                        Console.WriteLine("Changed name off cover" + extension + " to" + songName);
                    }

                    if (item.Name == "_coverImageFilename")
                    {
                        if (Path.GetExtension(item.Value.ToString()).ToLowerInvariant() == ".png")
                        {
                            var extension = Path.GetExtension(item.Value.ToString()).ToLowerInvariant();
                            string oldFile = item.Value.ToString();

                            string file = subdir + "/" + item.Value.ToString();
                            string name = Path.GetFileNameWithoutExtension(file);
                            string path = Path.GetDirectoryName(file);
                            Image png = Image.FromFile(file);
                            png.Save(path + @"/" + name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            png.Dispose();

                            string newFile = name + ".jpg";

                            item.Value = newFile;

                            Console.WriteLine($"Changed {oldFile} to {newFile}");
                        }
                    }

                }
                result = jobj.ToString();
            }
            File.WriteAllText(filepath, result);
        }

        static string ParseNewInfoFileAndReturnSongName(string filepath, string subdir)
        {
            string result = string.Empty;

            using (StreamReader r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);
                foreach (var item in jobj.Properties())
                {
                    if (item.Name == "_songName")
                    {
                        return item.Value.ToString();
                    }
                }
            }

            return "";
        }

        static void ParseOldInfoFile(string filepath, string subdir)
        {
            string result = string.Empty;

            using (StreamReader r = new StreamReader(filepath))
            {

                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);
                foreach (var item in jobj.Properties())
                {
                    if (item.Name == "audioPath" && item.Value.ToString() == "song.ogg")
                    {
                        var songName = jobj.Properties().Single(s => s.Name == "songName").Value.ToString() + ".ogg";
                        var isValid = !string.IsNullOrEmpty(songName) &&
                            songName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 &&
                            !File.Exists(Path.Combine(subdir, songName));

                        if (!isValid)
                        {
                            songName = string.Join("", songName.Split(Path.GetInvalidFileNameChars()));
                        }

                        item.Value = songName;

                        if (FileExist(subdir + "/song.ogg"))
                        {
                            File.Move(subdir + "/song.ogg", subdir + "/" + songName);
                        }

                        Console.WriteLine("Changed name off song.ogg to" + songName);
                    }

                    if (item.Name == "coverImagePath" && item.Value.ToString() == "cover.jpg" || item.Value.ToString() == "cover.png")
                    {
                        var extension = Path.GetExtension(item.Value.ToString()).ToLowerInvariant();
                        var songName = jobj.Properties().Single(s => s.Name == "songName").Value.ToString() + extension;
                        var isValid = !string.IsNullOrEmpty(songName) &&
                            songName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 &&
                            !File.Exists(Path.Combine(subdir, songName));

                        if (!isValid)
                        {
                            songName = string.Join("", songName.Split(Path.GetInvalidFileNameChars()));
                        }

                        item.Value = songName;

                        if (FileExist(subdir + "/cover" + extension))
                        {
                            File.Move(subdir + "/cover" + extension, subdir + "/" + songName);
                        }

                        Console.WriteLine("Changed name off cover" + extension + " to" + songName);
                    }

                }
                result = jobj.ToString();
            }
            File.WriteAllText(filepath, result);

        }

        static string ParseOldInfoFileAndReturnSongName(string filepath, string subdir)
        {
            string result = string.Empty;

            using (StreamReader r = new StreamReader(filepath))
            {

                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);
                foreach (var item in jobj.Properties())
                {
                    if (item.Name == "songName")
                    {
                        return item.Value.ToString();
                    }

                }
            }
            return "";
        }

        private void BT_TransferSongsToSongsToLoad_Click(object sender, EventArgs e)
        {
            
            foreach (var song in LB_AvailableSongs.SelectedItems)
            {
                var songName = song.ToString();
                var AvailableSong = AvailableSongs.Single(s => s.SongName == song.ToString());
                var isValid = !string.IsNullOrEmpty(songName) &&
                    songName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 &&
                    !File.Exists(Path.Combine(Properties.Settings.Default.SongsToLoadFolder, songName));

                if (!isValid)
                {
                    songName = string.Join("", songName.Split(Path.GetInvalidFileNameChars()));
                }
                var destDirName = Properties.Settings.Default.SongsToLoadFolder + songName;
                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(AvailableSong.SongFolder);

                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + AvailableSong.SongFolder);
                }

                DirectoryInfo[] dirs = dir.GetDirectories();
                // If the destination directory doesn't exist, create it.
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, false);
                }
            }

            LoadSongsToLoad();

            LoadSongsToListBoxes();
        }

        private void BT_DeleteSongsToLoad_Click(object sender, EventArgs e)
        {
            foreach(var song in LB_SongsToLoad.SelectedItems)
            {
                var songName = song.ToString();
                var songToLoad = SongsToLoad.Single(s => s.SongName == song.ToString());

                Directory.Delete(songToLoad.SongFolder, recursive: true);
            }
            

            LoadSongsToLoad();

            LoadSongsToListBoxes();
        }

        private void BT_Load_Click(object sender, EventArgs e)
        {
            ProcessStartInfo processtartinfo = new ProcessStartInfo("cmd.exe");
            processtartinfo.Arguments = $"/K erase /s /Q {Properties.Settings.Default.apkFolder}\\base";

            Process p = new Process();
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/K \"{Properties.Settings.Default.ADB_Folder}\\adb.exe\" pull /data/app/com.beatgames.beatsaber-1/base.apk";
            p = Process.Start(processtartinfo);
            p.WaitForExit();


            processtartinfo.Arguments = $"/K echo n | copy /-y base.apk {Properties.Settings.Default.backupFolder}\\";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/K java -jar \"{Properties.Settings.Default.apktool_Folder}\\apktool_2.4.0.jar\" d .\\base.apk -o {Properties.Settings.Default.apkFolder}\\base -f";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/K echo n | copy /-y \"{Properties.Settings.Default.apkFolder}\\base\\lib\\armeabi-v7a\\libil2cpp.so\" {Properties.Settings.Default.backupFolder}\\";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/K \"{Properties.Settings.Default.songeconverter_Folder}\\songe-converter.exe\" -a {Properties.Settings.Default.SongsToLoadFolder}";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            ChangeSongAndCoverNamesAndCheckPNGs();

            processtartinfo.Arguments = $"/K \"{Properties.Settings.Default.BeatMapAssetMaker_Folder}\\BeatMapAssetMaker.exe\" --patch .\\apk\\base\\lib\\armeabi-v7a\\libil2cpp.so";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/K \"{Properties.Settings.Default.BeatMapAssetMaker_Folder}\\BeatMapAssetMaker.exe\" {Properties.Settings.Default.apkFolder}\\base\\assets\\bin\\Data\\ .\\assets\\ {Properties.Settings.Default.SongsToLoadFolder}\\ covers";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/c erase /Q \"{Properties.Settings.Default.apkFolder}\\base\\assets\\bin\\Data\\sharedassets17.assets\"";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/c erase /Q \"{Properties.Settings.Default.apkFolder}\\base\\assets\\bin\\Data\\sharedassets17.assets.split*\"";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/c erase /Q \"{Properties.Settings.Default.apkFolder}\\base\\assets\\bin\\Data\\sharedassets19.assets\"";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/c erase /Q \"{Properties.Settings.Default.apkFolder}\\base\\assets\\bin\\Data\\sharedassets19.assets.split*\"";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/K copy .\\assets\\*.* \"{Properties.Settings.Default.apkFolder}\\base\\assets\\bin\\Data\\\"";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/K java -jar \"{Properties.Settings.Default.apktool_Folder}\\apktool_2.4.0.jar\" b {Properties.Settings.Default.apkFolder}\\base";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/K \"{Properties.Settings.Default.JARSIGNERLOC_Folder}\\jarsigner.exe\" -storepass emulamer -keypass emulamer -verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore bskey .\\apk\\base\\dist\\base.apk bs";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/K \"{Properties.Settings.Default.ADB_Folder}\\adb.exe\" uninstall com.beatgames.beatsaber";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/K \"{Properties.Settings.Default.ADB_Folder}\\adb.exe\" install {Properties.Settings.Default.apkFolder}\\base\\dist\\base.apk";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            MessageBox.Show("Complete");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings y = new FormSettings();
            y.ShowDialog();

            LoadSongsToLoad();

            LoadSongsToListBoxes();
        }

        private void BTN_Unload_Click(object sender, EventArgs e)
        {
            ProcessStartInfo processtartinfo = new ProcessStartInfo("cmd.exe");
            processtartinfo.Arguments = $"/K \"{Properties.Settings.Default.ADB_Folder}\\adb.exe\" uninstall com.beatgames.beatsaber";

            Process p = new Process();
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            processtartinfo.Arguments = $"/K \"{Properties.Settings.Default.ADB_Folder}\\adb.exe\" install {Properties.Settings.Default.backupFolder}\\base.apk";
            p = Process.Start(processtartinfo);
            p.WaitForExit();

            MessageBox.Show("Complete");
        }
    }
}
