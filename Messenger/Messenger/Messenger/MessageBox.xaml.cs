using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для Messenger.xaml
    /// </summary>
    public partial class MessageBox : UserControl
    {
        public string Author
        {
            get { return (string)GetValue(AuthorProperty); }
            set { SetValue(AuthorProperty, value); }
        }
        public static readonly DependencyProperty AuthorProperty =
            DependencyProperty.Register("Author", typeof(string),
            typeof(MessageBox), new UIPropertyMetadata("", new PropertyChangedCallback(AuthorChanged)));

        private static void AuthorChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ((MessageBox)depObj).tbAuthor.Text = $" {args.NewValue.ToString()}";
        }

        public new string Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public static new readonly DependencyProperty ContentProperty =  DependencyProperty.Register("Content", typeof(string),
            typeof(MessageBox), new UIPropertyMetadata("", new PropertyChangedCallback(ContentChanged)));
        private static void ContentChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ((MessageBox)depObj).tbContent.Text = args.NewValue.ToString();
        }

        public string Time
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(string),
            typeof(MessageBox), new UIPropertyMetadata("", new PropertyChangedCallback(TimeChanged)));
        private static void TimeChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ((MessageBox)depObj).tbTime.Text = args.NewValue.ToString();
        }

        public bool Mine
        {
            get { return (bool)GetValue(MineProperty); }
            set { SetValue(MineProperty, value); }
        }
        public static readonly DependencyProperty MineProperty =
            DependencyProperty.Register("Mine", typeof(bool),
            typeof(MessageBox), new UIPropertyMetadata(false, new PropertyChangedCallback(MineChanged)));
        private static void MineChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            if ((bool)args.NewValue)
            {
                ((MessageBox)depObj).tbContent.Style = (Style)((MessageBox)depObj).FindResource("MessageContentMe");
                ((MessageBox)depObj).spMain.Style = (Style)((MessageBox)depObj).FindResource("MessageMe");
                ((MessageBox)depObj).bBorder.Style = (Style)((MessageBox)depObj).FindResource("MessageBorderMe");
                ((MessageBox)depObj).spTooltip.HorizontalAlignment = HorizontalAlignment.Right;
            }
        }
        public MessageBox()
        {
            InitializeComponent();
        }
    }
}
