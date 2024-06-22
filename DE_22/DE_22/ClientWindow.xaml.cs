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
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private string connectionString = "your_connection_string_here";
        private int clientId;

        public ClientWindow(int clientId)
        {
            InitializeComponent();
            this.clientId = clientId;
            LoadRequests();
        }

        private void LoadRequests()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Requests WHERE clientID = @clientId", conn);
                da.SelectCommand.Parameters.AddWithValue("@clientId", clientId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                RequestsDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void AddRequestButton_Click(object sender, RoutedEventArgs e)
        {
            Create createWindow = new Create(clientId);
            createWindow.Show();
        }

        private void EditRequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsDataGrid.SelectedItem != null)
            {
                DataRowView row = (DataRowView)RequestsDataGrid.SelectedItem;
                Edit editWindow = new Edit((int)row["requestID"]);
                editWindow.Show();
            }
        }
    }
}