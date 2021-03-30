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

namespace _30._03._2021
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Question> _questions;

        public MainWindow()
        {
            InitializeComponent();
            InitializeQuestionList();

            DataContext = _questions[0].Options;
            tbTitle.Text = _questions[0].Content;
            /*dgOptions.Columns[3].Visibility = Visibility.Hidden;
            dgOptions.Columns[4].Visibility = Visibility.Hidden;
            dgOptions.Columns[5].Visibility = Visibility.Hidden;*/
            dgOptions.HeadersVisibility = DataGridHeadersVisibility.None;
        }

        private void InitializeQuestionList()
        {
            _questions = new List<Question>
            {
                new Question("Which of the folowing are prime numbers?", new List<Option>() { new Option("21"), new Option("31"), new Option("41"), new Option("49") })
            };
        }
    }
}
