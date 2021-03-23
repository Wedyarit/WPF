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

namespace _17._03._2021
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnCalculate.Click += Calculate;
            btnExit.Click += Exit;
        }

        private void Calculate(object sender, EventArgs e)
        {
            IEnumerable<TextBox> textBoxes = root.Children.OfType<TextBox>();
            int max = Int32.MinValue;
            int second = Int32.MinValue;
            for (int i = 0; i < textBoxes.Count() - 2; i++)
            {
                if (int.TryParse(textBoxes.ElementAt(i).Text, out int n) && n > max)
                {
                    if (max == Int32.MinValue)
                        second = n;
                    else
                        second = max;
                    max = n;
                }
            }

            tbLargestNumber.Text = max.ToString();
            tbSecondLargestNumber.Text = second.ToString();
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
