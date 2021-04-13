using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using System.Xml;

namespace _29._03._2021
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PagingCollectionView _cview;

        private void InitializePagingCollectionView()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(File.ReadAllText("MOCK_DATA.xml"));
            XmlNodeList nodes = xmlDoc.GetElementsByTagName("record");
            List<User> users = new List<User>();
            foreach (XmlNode node in nodes)
                users.Add(new User()
                {
                    ID = node.ChildNodes[0].InnerText,
                    FirstName = node.ChildNodes[1].InnerText,
                    LastName = node.ChildNodes[2].InnerText,
                    Email = node.ChildNodes[3].InnerText,
                    IP = node.ChildNodes[4].InnerText
                });
            _cview = new PagingCollectionView(users, 12);
            DataContext = _cview;
        }

        private void OnNextClicked(object sender, RoutedEventArgs e) => _cview.MoveToNextPage();

        private void OnPreviousClicked(object sender, RoutedEventArgs e) => _cview.MoveToPreviousPage();

        public MainWindow()
        {
            InitializeComponent();
            InitializePagingCollectionView();
        }
    }


    class User
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IP { get; set; }
    }
}
