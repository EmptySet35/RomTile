using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ookii.Dialogs.Wpf;

namespace RomTile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Microsoft.Win32.OpenFileDialog fileDialog;
        VistaFolderBrowserDialog folderDialog;
        Dictionary<string, RomSettings> romDict;

        public MainWindow()
        {
            InitializeComponent();
            
            fileDialog = new Microsoft.Win32.OpenFileDialog();
            folderDialog = new VistaFolderBrowserDialog();
            romDict = new Dictionary<string, RomSettings>();
        }

        public class RomSettings
        {
            private string name;
            private string romPath;
            private string arguments;
            private string imagePath;
            private Color tileColor;
            private Color textColor;
            private Boolean showName;
            private int tileSize;

            public RomSettings(string path)
            {
                string rawName = System.IO.Path.GetFileNameWithoutExtension(path);
                string tempImagePath = System.IO.Path.GetDirectoryName(path) + "\\Images\\" + rawName + ".jpg";

                SetName(rawName);
                SetPath(path);
                SetArguments("");
                SetImagePath(tempImagePath, false);
                SetTileColor(Color.FromRgb(0, 0, 0));
                SetTextColor(Color.FromRgb(255, 255, 255));
                SetShowName(false);
                SetTileSize(1);
            }
            public void SetName(string rawName)
            {
                name = SanitizeName(rawName);
            }
            private void SetPath(string path)
            {
                romPath = path;
            }
            public void SetArguments(string args)
            {
                arguments = args;
            }
            public void SetImagePath(string path, bool force)
            {
                bool imagePathIsValid = File.Exists(path);
                if (imagePathIsValid || force)
                    imagePath = path;
                else
                    imagePath = "";            
            }
            public void SetTileColor(Color clr)
            {
                tileColor = clr;    
            }
            public void SetTextColor(Color clr)
            {
                textColor = clr;      
            }
            public void SetShowName(bool show)
            {
                showName = show;
            }
            public void SetTileSize(int size)
            {
                if (size >= 0 && size <= 3)
                    tileSize = size;
            }
            public string GetName()
            {
                return name;
            }
            public string GetPath()
            {
                return romPath;
            }
            public string GetArguments()
            {
                return arguments;
            }
            public string GetImagePath()
            {
                return imagePath;
            }
            public Color GetTileColor()
            {
                return tileColor;
            }
            public Color GetTextColor()
            {
                return textColor;
            }
            public bool GetShowName()
            {
                return showName;
            }
            public int GetTileSize()
            {
                return tileSize;
            }
            public string IsRomValid()
            {
                bool tileColorIsValid = (tileColor.A == 0xFF);
                bool textColorIsValid = (textColor.A == 0xFF);
                bool imagePathIsValid = File.Exists(imagePath);
                bool romPathIsValid = File.Exists(romPath) && !romPath.Contains("&");

                string errors = "";
                errors += tileColorIsValid ? "" : "\n    Tile Color: OblyTile does not have alpha channel support, please adjust the color.";
                errors += textColorIsValid ? "" : "\n    Text Color: OblyTile does not have alpha channel support, please adjust the color.";
                errors += imagePathIsValid ? "" : "\n    Image Path: OblyTile requires that you have an image selected.";
                errors += romPathIsValid ? "" : "\n    Rom Path: The rom could not be found. Did you delete it?";

                return errors;
            }
            private string SanitizeName(string rawName)
            {
                Regex rgx1 = new Regex("[\\(|\\[|\\{].*?[\\)|\\}\\]]");
                Regex rgx2 = new Regex("[^a-zA-Z0-9\\- _]");
                Regex rgx3 = new Regex("\\s+");
                string result = rgx2.Replace(rgx1.Replace(rawName, ""), "");
                return Truncate(rgx3.Replace(result, " "), 50);
            }
            private string Truncate(string value, int maxLength)
            {
                if (string.IsNullOrEmpty(value)) return value;
                return value.Length <= maxLength ? value : value.Substring(0, maxLength);
            }
        }

        private void Emulator_Browse_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            fileDialog.DefaultExt = ".exe"; // Default file extension
            fileDialog.Filter = "Emulators|*.exe"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = fileDialog.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                EmulatorPath.Text = fileDialog.FileName;
            }
        }

        private void Rom_Browse_Click(object sender, RoutedEventArgs e)
        {
            // Show open file dialog box
            Nullable<bool> result = folderDialog.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                RomDirectory.Text = folderDialog.SelectedPath;
            }
        }

        private void Image_Path_Browse_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            fileDialog.DefaultExt = ".jpg"; // Default file extension
            fileDialog.Filter = "Images|*.jpg"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = fileDialog.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                romImagePath.Text = fileDialog.FileName;
            }
        }

        private void OblyTile_Browse_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            fileDialog.DefaultExt = ".exe"; // Default file extension
            fileDialog.Filter = "OblyTile|*.exe"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = fileDialog.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                OblyTilePath.Text = fileDialog.FileName;
            }
        }

        private void Find_Roms_Click(object sender, RoutedEventArgs e)
        {

            char[] delimiter = { ' ', ',' };
            string[] romExtenstions = MyExtensions.Text.Split(delimiter);
            string path = RomDirectory.Text;
            if (Directory.Exists(path))
            {
                string[] fileEntries = Directory.GetFiles(path);
                foreach (string fileName in fileEntries)
                {
                    foreach (string extension in romExtenstions)
                    {
                        if (System.IO.Path.GetExtension(fileName) == extension)
                        {
                            string file = System.IO.Path.GetFileName(fileName);
                            if (!MyListBox.Items.Contains(file))
                            {
                                MyListBox.Items.Add(file);
                                romDict[file] = new RomSettings(fileName);
                            }
                        }
                    }
                }
            }

        }

        private void Generate_Shortcuts_Click(object sender, RoutedEventArgs e)
        {
            if (Show_Rom_Report() != MessageBoxResult.OK)
                return;

            if (romDict.Count > 0)
            {
                string[] comboVals = { "tiny", "square", "wide", "large" };             
                foreach (RomSettings rom in romDict.Values)
                {
                    bool valid = File.Exists(OblyTilePath.Text);
                    valid &= File.Exists(EmulatorPath.Text);
                    valid &= (rom.IsRomValid() == "");
                    if (valid)
                    {
                        string oblyTileCall = "\"" + OblyTilePath.Text + "\" ";
                        oblyTileCall += "\"" + rom.GetName() + "\" ";
                        oblyTileCall += "\"" + EmulatorPath.Text + "\" ";
                        oblyTileCall += "\"" + "\\\"" + rom.GetPath() + "\\\"";
                        if (emuArgs.Text.ToString().Length > 0)
                            oblyTileCall += " " + emuArgs.Text;
                        if (rom.GetArguments().Length > 0)
                            oblyTileCall += " " + rom.GetArguments();
                        oblyTileCall += "\" ";
                        oblyTileCall += "\"" + rom.GetImagePath() + "\" \"\" \"\" \"\" \"\" ";
                        oblyTileCall += "#" + rom.GetTileColor().R.ToString("X2") + rom.GetTileColor().G.ToString("X2") + rom.GetTileColor().B.ToString("X2") + " ";
                        oblyTileCall += "#" + rom.GetTextColor().R.ToString("X2") + rom.GetTextColor().G.ToString("X2") + rom.GetTextColor().B.ToString("X2") + " ";
                        if (rom.GetShowName())
                            oblyTileCall += "show ";
                        else
                            oblyTileCall += "hide ";
                        oblyTileCall += "normal no yes no ";
                        oblyTileCall += comboVals[rom.GetTileSize()];

                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();
                        startinfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startinfo.FileName = "cmd.exe";
                        startinfo.Arguments = "/C call " + oblyTileCall;
                        process.StartInfo = startinfo;
                        process.Start();
                        process.WaitForExit();
                    }
                }
            }
        }

        private void Update_Rom_Settings_Click(object sender, RoutedEventArgs e)
        {
            if (MyListBox.SelectedItem != null)
            {
                string selectedFile = MyListBox.SelectedItem.ToString();
                RomSettings romToUpdate = romDict[selectedFile];
                romToUpdate.SetName(romName.Text);
                romToUpdate.SetArguments(romArgs.Text);
                romToUpdate.SetImagePath(romImagePath.Text, true);
                romToUpdate.SetTileColor(tileColor.SelectedColor);
                romToUpdate.SetTextColor(textColor.SelectedColor);
                romToUpdate.SetShowName((bool)showNameCheck.IsChecked);
                romToUpdate.SetTileSize(tileCombo.SelectedIndex);
            }
        }

        private void Delete_Rom_Click(object sender, RoutedEventArgs e)
        {
            if (MyListBox.SelectedItem != null)
            {
                string itemToDelete = MyListBox.SelectedItem.ToString();
                string deleteWarning = "Are you sure you want to delete " + itemToDelete + "?";
                if (MessageBox.Show(deleteWarning, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    MyListBox.SelectedItem = null;
                    MyListBox.Items.Remove(itemToDelete);
                    romDict.Remove(itemToDelete);
                }
            }
        }

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyListBox.SelectedItem != null)
            {
                string selectedFile = e.AddedItems[0].ToString();
                RomSettings selectedRom = romDict[selectedFile];
                romName.Text = selectedRom.GetName();
                romArgs.Text = selectedRom.GetArguments();
                romImagePath.Text = selectedRom.GetImagePath();
                tileColor.SelectedColor = selectedRom.GetTileColor();
                textColor.SelectedColor = selectedRom.GetTextColor();
                showNameCheck.IsChecked = selectedRom.GetShowName();
                tileCombo.SelectedIndex = selectedRom.GetTileSize();
            }
        }

        private void Generate_Report_Click(object sender, RoutedEventArgs e)
        {
            Show_Rom_Report();
        }



        private void romImagePath_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (File.Exists(romImagePath.Text))
            {
                BitmapImage preview = new BitmapImage();
                preview.BeginInit();
                preview.UriSource = new Uri(@romImagePath.Text);
                preview.DecodePixelHeight = 100;
                preview.DecodePixelWidth = 100;
                preview.EndInit();
                imagePreview.Source = preview;
            }
            else
            {
                imagePreview.Source = null;
            }
        }

        public MessageBoxResult Show_Rom_Report()
        {
            if (romDict.Count > 0)
            {
                string report = "The following roms have errors and no shortcut will be generated for them:\n";
                foreach (RomSettings rom in romDict.Values)
                {
                    if (rom.IsRomValid() != "")
                    {
                        report += rom.GetName() + ":";
                        report += rom.IsRomValid() + "\n";
                    }
                }
                return MessageBox.Show(report, "Rom Generation Report", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
            return MessageBoxResult.None;
        }
        
    }
}
