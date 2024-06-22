using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private string connectionString = "your_connection_string_here";

        public ManagerWindow()
        {
            InitializeComponent();
            LoadRequests();
        }

        private void LoadRequests()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Requests", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                RequestsDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void AssignMasterButton_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsDataGrid.SelectedItem != null)
            {
                DataRowView row = (DataRowView)RequestsDataGrid.SelectedItem;
                AssignMasterWindow assignMasterWindow = new AssignMasterWindow((int)row["requestID"]);
                assignMasterWindow.Show();
            }
        }
    }
}