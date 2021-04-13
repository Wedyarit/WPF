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
    /// Логика взаимодействия для UserPanel.xaml
    /// </summary>
    public partial class UserPanel : UserControl
    {   
        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }
        public static readonly DependencyProperty UsernameProperty =
            DependencyProperty.Register("Username", typeof(string),
            typeof(UserPanel), new UIPropertyMetadata("", new PropertyChangedCallback(UsernameChanged)));
        
        private static void UsernameChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ((UserPanel)depObj).tbUsername.Text = $" {args.NewValue.ToString()}";
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value);}
        }
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string),
            typeof(UserPanel), new UIPropertyMetadata("", new PropertyChangedCallback(MessageChanged)));
        private static void MessageChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ((UserPanel)depObj).tbMessage.Text = $" {args.NewValue.ToString()}";
        }

        public string Time
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); tbTime.Text = value; }
        }
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(string),
            typeof(UserPanel), new UIPropertyMetadata("", new PropertyChangedCallback(TimeChanged)));
        private static void TimeChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ((UserPanel)depObj).tbTime.Text = args.NewValue.ToString();
        }

        public string Avatar
        {
            get { return (string)GetValue(AvatarProperty); }
            set { SetValue(AvatarProperty, value); }
        }
        public static readonly DependencyProperty AvatarProperty =
            DependencyProperty.Register("Avatar", typeof(string),
            typeof(UserPanel), new UIPropertyMetadata("", new PropertyChangedCallback(AvatarChanged)));
        private static void AvatarChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ((UserPanel)depObj).ibAvatar.ImageSource = new BitmapImage(new Uri(args.NewValue.ToString(), UriKind.Relative));
        }

        public UserPanel()
        {
            InitializeComponent();
        }
    }
}
