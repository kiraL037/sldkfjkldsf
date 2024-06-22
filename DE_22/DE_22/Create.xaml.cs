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
    /// Логика взаимодействия для Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        private string connectionString = "your_connection_string_here";
        private int clientId;

        public Create(int clientId)
        {
            InitializeComponent();
            this.clientId = clientId;
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Requests (startDate, orgTechType, orgTechModel, problemDescription, requestStatus, clientID) VALUES (@startDate, @orgTechType, @orgTechModel, @problemDescription, 'Новая заявка', @clientId)", conn);
                cmd.Parameters.AddWithValue("@startDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@orgTechType", OrgTechTypeTextBox.Text);
                cmd.Parameters.AddWithValue("@orgTechModel", OrgTechModelTextBox.Text);
                cmd.Parameters.AddWithValue("@problemDescription", ProblemDescriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@clientId", clientId);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Заявка добавлена");
            this.Close();
        }
    }
}