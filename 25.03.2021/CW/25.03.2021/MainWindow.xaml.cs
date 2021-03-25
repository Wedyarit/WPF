using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Interop;
using Microsoft.VisualBasic.FileIO;

namespace _25._03._2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (string s in Directory.GetLogicalDrives())
            {
                TreeViewItem item = new TreeViewItem
                {
                    Header = s,
                    Tag = s
                };
                item.Items.Add(null);
                item.Expanded += Expand;
                tvExplorer.Items.Add(item);
            }
        }

        private void Expand(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            if (item.Items.Count == 1 && item.Items[0] == null)
            {
                item.Items.Clear();
                try
                {
                    foreach (string filename in Directory.GetDirectories(item.Tag.ToString()))
                    {
                        TreeViewItem subitem = new TreeViewItem
                        {
                            Header = filename[(filename.LastIndexOf("\\") + 1)..],
                            Tag = filename
                        };
                        subitem.Items.Add(null);
                        subitem.Expanded += Expand;
                        subitem.Selected += Select;
                        item.Items.Add(subitem);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error");
                }
            }
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            try
            {
                lbFiles.Items.Clear();
                foreach (string filename in FileSystem.GetFiles((sender as TreeViewItem).Tag as string))
                {
                    ListBoxItem item = new ListBoxItem
                    {
                        Content = filename[(filename.LastIndexOf("\\") + 1)..],
                        Tag = filename
                    };
                    item.Selected += Info;
                    lbFiles.Items.Add(item);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            try
            {
                FileInfo fileInfo = FileSystem.GetFileInfo((sender as ListBoxItem).Tag as string);
                tbName.Text = fileInfo.Name;
                tbExtension.Text = fileInfo.Extension;
                tbSize.Text = $"{fileInfo.Length} byte";
                tbCreation.Text = fileInfo.CreationTime.ToString("MM/dd/yyyy h:mm tt");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }
    }
}
