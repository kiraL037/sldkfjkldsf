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
using System.Windows.Shapes;

namespace ThesisProject
{
    /// <summary>
    /// Логика взаимодействия для FirstSetupWindow.xaml
    /// </summary>
    public partial class FirstSetupWindow : Window
    {
        public FirstSetupWindow()
        {
            InitializeComponent();
        }

        private void SetupButton_Click(object sender, RoutedEventArgs e)
        {
            string server = ServerTextBox.Text;
            string database = DatabaseTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            string connectionString = $"Server={server};Database={database};User Id=your_user;Password=your_password;";

            try
            {
                //DBInitializer.Initialize(connectionString);
                DBInitializer.CreateAdminUser(connectionString, username, password);
                MessageBox.Show("Настройка завершена. Учетная запись администратора создана.");
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при настройке: " + ex.Message);
            }
        }

        private void FinishSetupButton_Click(object sender, RoutedEventArgs e)
        {
            string server = ServerTextBox.Text;
            string database = DatabaseTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            string connectionString = $"Server={server};Database={database};User Id={username};Password={password};";

            try
            {
                //DBInitializer.Initialize(connectionString);
                //DatabaseInitializer.CreateAdminUser(connectionString, username, password);

                MessageBox.Show("Настройка завершена. Учетная запись администратора создана.");

                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при настройке: " + ex.Message);
            }
        }

        private void ServerTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ServerTextBox.Text == "Сервер")
            {
                ServerTextBox.Text = "";
                ServerTextBox.Foreground = Brushes.Black;
            }
        }

        private void ServerTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ServerTextBox.Text))
            {
                ServerTextBox.Text = "Сервер";
                ServerTextBox.Foreground = Brushes.Gray;
            }
        }

        private void DatabaseTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DatabaseTextBox.Text == "База данных")
            {
                DatabaseTextBox.Text = "";
                DatabaseTextBox.Foreground = Brushes.Black;
            }
        }

        private void DatabaseTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DatabaseTextBox.Text))
            {
                DatabaseTextBox.Text = "База данных";
                DatabaseTextBox.Foreground = Brushes.Gray;
            }
        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "Логин")
            {
                UsernameTextBox.Text = "";
                UsernameTextBox.Foreground = Brushes.Black;
            }
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "Логин";
                UsernameTextBox.Foreground = Brushes.Gray;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            if (passwordBox.Tag.ToString() == "Пароль")
            {
                passwordBox.Password = "";
                passwordBox.Foreground = Brushes.Black;
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            if (string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                passwordBox.Password = passwordBox.Tag.ToString();
                passwordBox.Foreground = Brushes.Gray;
            }
        }
        private void ConfirmPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox ConfirmPasswordBox = (PasswordBox)sender;
            if (ConfirmPasswordBox.Tag.ToString() == "Пароль")
            {
                ConfirmPasswordBox.Password = "";
                ConfirmPasswordBox.Foreground = Brushes.Black;
            }
        }

        private void ConfirmPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox ConfirmPasswordBox = (PasswordBox)sender;
            if (string.IsNullOrWhiteSpace(ConfirmPasswordBox.Password))
            {
                ConfirmPasswordBox.Password = ConfirmPasswordBox.Tag.ToString();
                ConfirmPasswordBox.Foreground = Brushes.Gray;
            }
        }
    }
}