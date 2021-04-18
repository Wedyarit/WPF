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

namespace _23._02._2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void UpdateButtonState(Button btn, object resource)
        {
            foreach (Button button in NavBar.Children.OfType<Button>())
            {
                button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0d2738"));
                if (button.Content == FindResource("HomeWhite"))
                    button.Content = FindResource("HomeBlue");
                else if (button.Content == FindResource("EmailWhite"))
                    button.Content = FindResource("EmailBlue");
                else if (button.Content == FindResource("CloudWhite"))
                    button.Content = FindResource("CloudBlue");
            }

            foreach (StackPanel stackpanel in root.Children.OfType<StackPanel>())
            {
                stackpanel.Visibility = Visibility.Hidden;
            }
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1f90fe"));
            btn.Content = resource;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonHomeClick(object sender, RoutedEventArgs e)
        {
            UpdateButtonState(sender as Button, FindResource("HomeWhite"));
            Home.Visibility = Visibility.Visible;
        }

        private void ButtonEmailClick(object sender, RoutedEventArgs e)
        {
            UpdateButtonState(sender as Button, FindResource("EmailWhite"));
            Email.Visibility = Visibility.Visible;
        }

        private void ButtonCloudClick(object sender, RoutedEventArgs e)
        {
            UpdateButtonState(sender as Button, FindResource("CloudWhite"));
            Cloud.Visibility = Visibility.Visible;
        }
    }
}