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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private string connectionString = "your_connection_string_here";
        private int requestId;

        public Edit(int requestId)
        {
            InitializeComponent();
            this.requestId = requestId;
            LoadRequestDetails();
        }

        private void LoadRequestDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Requests WHERE requestID = @requestId", conn);
                cmd.Parameters.AddWithValue("@requestId", requestId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    OrgTechTypeTextBox.Text = reader["orgTechType"].ToString();
                    OrgTechModelTextBox.Text = reader["orgTechModel"].ToString();
                    ProblemDescriptionTextBox.Text = reader["problemDescription"].ToString();
                }
            }
        }

        private void SaveOrderButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Requests SET orgTechType = @orgTechType, orgTechModel = @orgTechModel, problemDescription = @problemDescription WHERE requestID = @requestId", conn);
                cmd.Parameters.AddWithValue("@orgTechType", OrgTechTypeTextBox.Text);
                cmd.Parameters.AddWithValue("@orgTechModel", OrgTechModelTextBox.Text);
                cmd.Parameters.AddWithValue("@problemDescription", ProblemDescriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@requestId", requestId);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Изменения сохранены");
            this.Close();
        }
    }
}