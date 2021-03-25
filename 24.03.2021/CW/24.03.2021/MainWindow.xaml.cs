using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.ComponentModel;

namespace _24._03._2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _filename;
        private void ChangeTitle(string filename) => Title = $"{filename} - Notepad";
        private void ChangeTitle() => Title = "Untitled - Notepad";

        public MainWindow()
        {
            InitializeComponent();
            _filename = "untitled.txt";
        }

        private void miClickExit(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void miClickNew(object sender, RoutedEventArgs e)
        {
            tbContent.Text = "";
            ChangeTitle();
        }

        private void miClickOpen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                _filename = openFileDialog.FileName;
                string content = File.ReadAllText(_filename);
                ChangeTitle(_filename);
                if (content.Length == 0) MessageBox.Show("File is empty!");
                else tbContent.Text = content;
            }
        }

        private void miClickSave(object sender, RoutedEventArgs e) => File.WriteAllText(_filename, tbContent.Text);

        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (tbContent.Text != File.ReadAllText(_filename))
                switch (MessageBox.Show($"Do you want to save changes before closing in {_filename}?",
                                         "Notepad",
                                         MessageBoxButton.YesNoCancel,
                                         MessageBoxImage.Question))
                {
                    case MessageBoxResult.Yes:
                        File.WriteAllText(_filename, tbContent.Text);
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
        }
    }
}
