using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace _23._03._2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DisableOptions(string text)
        {
            miBlack.IsChecked = false;
            miRed.IsChecked = false;
            miGreen.IsChecked = false;
            miBlue.IsChecked = false;
            tbName.Text = text;
        }

        private void miClickExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void miClickBlack(object sender, RoutedEventArgs e)
        {
            gRoot.Background = Brushes.Black;
            DisableOptions((sender as MenuItem).Header as string);
            miBlack.IsChecked = true;
        }

        private void miClickRed(object sender, RoutedEventArgs e)
        {
            gRoot.Background = Brushes.Red;
            DisableOptions((sender as MenuItem).Header as string);
            miRed.IsChecked = true;
        }

        private void miClickBlue(object sender, RoutedEventArgs e)
        {
            gRoot.Background = Brushes.Blue;
            DisableOptions((sender as MenuItem).Header as string);
            miBlue.IsChecked = true;
        }

        private void miClickGreen(object sender, RoutedEventArgs e)
        {
            gRoot.Background = Brushes.Green;
            DisableOptions((sender as MenuItem).Header as string);
            miGreen.IsChecked = true;
        }
    }
}
