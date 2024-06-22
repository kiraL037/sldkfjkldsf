using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace DE_AA_Migalkina
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private string connectionString = "Data Source=LAPTOP-BP9G4DP1\\SQLEXPRESS;Initial Catalog=DE_DB;";

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                bool loginSuccessful = CheckLogin(username, password);
                if (loginSuccessful)
                {
                    MessageBox.Show("Вход выполнен успешно!");
                    this.Close();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Неправильное имя пользователя или пароль!");
                }
            }
            else
            {
                MessageBox.Show("Введите имя пользователя и пароль!");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
        }

        private bool CheckLogin(string username, string password)
        {
            
            bool loginSuccessful = false;

            // Подключение к базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Запрос к базе данных для поиска пользователя по имени и паролю
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar(); // Получаем количество строк, удовлетворяющих запросу

                    // Если найдена хотя бы одна строка, аутентификация успешна
                    if (count > 0)
                    {
                        loginSuccessful = true;
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок при выполнении запроса
                    MessageBox.Show("Ошибка входа: " + ex.Message);
                }
            }

            return loginSuccessful;
        }
    }
}
