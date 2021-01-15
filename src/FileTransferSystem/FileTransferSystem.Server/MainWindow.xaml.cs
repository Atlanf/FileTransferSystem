using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FileTransferSystem.Logic.Helper;

namespace FileTransferSystem.Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ConfigurationFileManager _fileManager;

        public MainWindow(ConfigurationFileManager fileManager)
        {
            InitializeComponent();
            _fileManager = fileManager;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.ProgramFiles;

            var result = fbd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                tbDirectory.Text = fbd.SelectedPath;
                _fileManager.SetWorkingDirectoryPath(fbd.SelectedPath);
            }
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            tbDirectory.Text = _fileManager.GetWorkingDirectoryPath();
        }
    }
}
