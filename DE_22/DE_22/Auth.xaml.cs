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

namespace DE_22
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        private string connectionString = "your_connection_string_here";

        public Auth()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE login = @login AND password = @password", connection);
                cmd.Parameters.AddWithValue("@login", LoginTextBox.Text);
                cmd.Parameters.AddWithValue("@password", PasswordTextBox.Password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string userType = reader["type"].ToString();
                    if (userType == "Заказчик")
                    {
                        ClientWindow clientWindow = new ClientWindow((int)reader["userID"]);
                        clientWindow.Show();
                    }
                    else if (userType == "Оператор")
                    {
                        OperatorWindow operatorWindow = new OperatorWindow();
                        operatorWindow.Show();
                    }
                    else if (userType == "Менеджер")
                    {
                        ManagerWindow managerWindow = new ManagerWindow();
                        managerWindow.Show();
                    }
                    else if (userType == "Мастер")
                    {
                        MasterWindow masterWindow = new MasterWindow((int)reader["userID"]);
                        masterWindow.Show();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
    }
}