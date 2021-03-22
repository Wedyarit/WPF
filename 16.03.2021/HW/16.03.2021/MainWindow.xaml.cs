using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;

namespace _16._03._2021
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

        bool IsValidEmail(string email)
        {
            try
            {
                return new MailAddress(email).Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void Sumbit(object sender, EventArgs e)
        {
            if (IsValidEmail(tbEmail.Text) && tbEmail.Text != exampleEmail && new Regex("^[^0-9][^@#]+$").IsMatch(tbName.Text))
                new User(tbName.Text, tbEmail.Text).SaveToJson();
        }
    }
}
