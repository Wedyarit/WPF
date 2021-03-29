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

namespace _18._03._2021
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calculator _calculator;

        char KeyToChar(Key key)
        {
            if (Keyboard.IsKeyDown(Key.LeftAlt) ||
                Keyboard.IsKeyDown(Key.RightAlt) ||
                Keyboard.IsKeyDown(Key.LeftCtrl) ||
                Keyboard.IsKeyDown(Key.RightAlt))
            {
                return '\x00';
            }

            switch (key)
            {
                case Key.Enter: return '\n';
                case Key.D0: return (')');
                case Key.D1: return ('1');
                case Key.D2: return ('2');
                case Key.D3: return ('3');
                case Key.D4: return ('4');
                case Key.D5: return ('%');
                case Key.D6: return ('6');
                case Key.D7: return ('7');
                case Key.D8: return ('8');
                case Key.D9: return ('(');
                case Key.OemPlus: return ('+');
                case Key.OemMinus: return ('-');
                case Key.OemQuestion: return ('/');
                case Key.OemPeriod: return ('.');

                case Key.NumPad0: return '0';
                case Key.NumPad1: return '1';
                case Key.NumPad2: return '2';
                case Key.NumPad3: return '3';
                case Key.NumPad4: return '4';
                case Key.NumPad5: return '5';
                case Key.NumPad6: return '6';
                case Key.NumPad7: return '7';
                case Key.NumPad8: return '8';
                case Key.NumPad9: return '9';
                case Key.Subtract: return '-';
                case Key.Add: return '+';
                case Key.Decimal: return '.';
                case Key.Divide: return '/';
                case Key.Multiply: return '*';

                default: return '\x00';
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            _calculator = new Calculator();
            this.DataContext = _calculator;
            EventManager.RegisterClassHandler(typeof(Button), Button.ClickEvent, new RoutedEventHandler(Calculate));
            this.KeyDown += new KeyEventHandler(KeyCalculate);
        }

        private void Calculate(object sender, RoutedEventArgs e) {
            _calculator.Calculate((sender as Button).Content as string);
        }

        private void KeyCalculate(object sender, KeyEventArgs e)
        {
            _calculator.Calculate(KeyToChar(e.Key).ToString());
        }
    }

    class Calculator
    {
        public string CurrentNumber { get; set; }
        public string History { get; set; }

        public Calculator()
        {
            CurrentNumber = "0";
            History = "";
        }

        public void Calculate(string content)
        {
            if (Int32.TryParse(content, out int n) || content == ".")
            {
                if (CurrentNumber == "0")
                    CurrentNumber = n.ToString();
                else
                    CurrentNumber += content;
            }
        }
    }
}
