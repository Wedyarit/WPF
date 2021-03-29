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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace _28._03._2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FB2Reader _FB2Reader;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void miClickExit(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        private void miClickOpen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "FictionBook (*.fb2)|*.fb2";
            if (openFileDialog.ShowDialog() == true)
            {
                _FB2Reader = new FB2Reader(openFileDialog.FileName);
                foreach (Block block in _FB2Reader.GetBlocks())
                    fdContent.Blocks.Add(block);
            }
        }
    }
}
