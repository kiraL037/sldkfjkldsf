using System;
using System.Data;
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

namespace WpfApp1калькулятор
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double res;
        double a;
        public MainWindow()
        {
            InitializeComponent();
            foreach(UIElement element in calc.Children)
            {
                if (element is Button button)
                {
                    button.Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "C")
                name.Text = "";

            else if (str == "=")
            {
                if (name.Text.Contains('^'))
                {
                    if (Pow(name.Text) == "Ошибка") MessageBox.Show("Ошибка!");
                    else name.Text = Pow(name.Text);
                }

                try
                {
                    var wha = new DataTable().Compute(name.Text, null).ToString();
                    name.Text = wha;
                }

                catch
                {
                }
            }

            else if (str == "←")
                name.Text = name.Text.Substring(0, name.Text.Length - 1);

            else if (str == ",")
            {
                if (!name.Text.Contains(","))
                    name.Text += str;
            }

            else if (str == "+/-")
            {
                double res = double.Parse(name.Text);
                res = res * -1;
                name.Text = res.ToString();
            }

            else if (str == "10ᵡ")
            {
                double res = double.Parse(name.Text);
                res = Math.Pow(10, res);
                name.Text = res.ToString();
            }

            else if (str == "sin°")
            {
                double res = double.Parse(name.Text);
                res *= Math.PI / 180;
                res = Math.Sin(res);
                name.Text = res.ToString();
            }

            else if (str == "1/x")
            {
                double res = double.Parse(name.Text);
                res = 1 / res;
                name.Text = res.ToString();
            }

            else if (str == "x²")
            {
                double res = double.Parse(name.Text);
                res = Math.Pow(res, 2);
                name.Text = res.ToString();
            }

            else if (str == "ln")
            {
                double res = double.Parse(name.Text);
                res = Math.Log10(res);
                name.Text = res.ToString();
            }

            else if (str == "²√x")
            {
                double res = double.Parse(name.Text);
                res = Math.Sqrt(res);
                name.Text = res.ToString();
            }


            else if (str == "n!")
            {
                int res1 = 1;
                double res = double.Parse(name.Text);
                for (int i = 1; i <= res; i++)
                {
                    res1 = res1 * i;
                }
                name.Text = res1.ToString();
            }

            else if (str == "%")
            {
                double res = double.Parse(name.Text);
                res /= 100;
                name.Text = res.ToString();
            }

            else
                name.Text += str;
        }
        private string Pow(string input)
        {
            double power = 1;
            string[] array = input.Split('^');
            if (array.Length < 2 || array.FirstOrDefault(e => e == "") != null)
            {
                return "Ошибка";
            }
            for (int i = 1; i < array.Length ; i++)
            {
                power *= double.Parse(array[i]);
            }
            return Math.Pow(double.Parse(array[0]), power).ToString();
        }
    }
}
//switch (str)
//{
//    case "+":
//        name.Text = (a + double.Parse(name.Text)).ToString();
//        break;
//    case "-":
//        name.Text = (a - double.Parse(name.Text)).ToString();
//        break;
//    case "*":
//        name.Text = (a * double.Parse(name.Text)).ToString();
//        break;
//    case "/":
//        name.Text = (a / double.Parse(name.Text)).ToString();
//        break;
//    default:
//        break;
//}
//else if (name.Text.Contains('π') || name.Text.Contains('e'))
//{
//    if (str == "π")
//    {
//        res = Math.PI;
//        name.Text = res.ToString();
//    }
//    else if (str == "e")
//    {
//        res = 2.7182818284590451;
//        name.Text = res.ToString();
//    }
//}
