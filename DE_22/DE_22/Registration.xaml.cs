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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private string connectionString = "your_connection_string_here";

        public Registration()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (fio, phone, login, password, type) VALUES (@fio, @phone, @login, @password, 'Заказчик')", conn);
                cmd.Parameters.AddWithValue("@fio", FioTextBox.Text);
                cmd.Parameters.AddWithValue("@phone", PhoneTextBox.Text);
                cmd.Parameters.AddWithValue("@login", LoginTextBox.Text);
                cmd.Parameters.AddWithValue("@password", PasswordTextBox.Password);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Регистрация успешна");
            this.Close();
        }
    }
}