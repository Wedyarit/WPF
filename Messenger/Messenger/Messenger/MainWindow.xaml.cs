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

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Messenger _messenger;
        public MainWindow()
        {
            InitializeComponent();
            _messenger = new Messenger
            {
                User = "Jack",
                Users = new List<User>()
            {
                new User
                {
                    Username = "Olive", Messages = new List<MessageBox>()
                    {
                        new MessageBox
                        {
                            Author="Olive",
                            Content="Jack, look. This TV program is about your favourite topic.",
                            Time="8:45 PM",
                            Mine=false
                        },
                        new MessageBox
                        {
                            Author="Jack",
                            Content="You mean about space exploration?",
                            Time="9:00 PM",
                            Mine=true
                        }
                    }
                }
            }
            };
        }
        void OnGotFocusTextBox(object sender, RoutedEventArgs e) => ((TextBox)sender).Text = "";
        void OnLostFocusTextBox(object sender, RoutedEventArgs e) => ((TextBox)sender).Text = "Type Message";
    }
}
