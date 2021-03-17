using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Diagnostics;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _16._03. _2021
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly string exampleEmail = "you@example.com";

        public MainWindow()
        {
            InitializeComponent();
            tbEmail.Text = exampleEmail;

            tbEmail.GotFocus += RemoveText;
            tbEmail.LostFocus += AddText;

            btnSubmit.Click += Sumbit;
        }

        private void RemoveText(object sender, EventArgs e)
        {
            if (tbEmail.Text == exampleEmail)
                tbEmail.Text = "";
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
                tbEmail.Text = exampleEmail;
        }

        private void Sumbit(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"\w*@\w*");
            if (regex.Matches(tbEmail.Text).Count > 0 && tbEmail.Text != exampleEmail)
            {

            }
        }
    }
}
