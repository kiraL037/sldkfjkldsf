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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic.FileIO;

namespace sql_data_analytics_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> queryHistory = new List<string>();
        private DataTable csvData = new DataTable();

        public MainWindow()
        {
            InitializeComponent();
            QueryHistoryListBox.SelectionChanged += QueryHistoryListBox_SelectionChanged;
        }

        private string GetConnectionString()
        {
            string server = ServerTextBox.Text;
            string database = DatabaseTextBox.Text;

            // For Windows Authentication
            if (!SqlServerAuthCheckBox.IsChecked.HasValue || !SqlServerAuthCheckBox.IsChecked.Value)
            {
                return $"Server={server};Database={database};Integrated Security=True;";
            }
            // For SQL Server Authentication
            else
            {
                string username = UsernameTextBox.Text;
                string password = PasswordBox.Password;
                return $"Server={server};Database={database};User Id={username};Password={password};";
            }
        }

        private void SqlServerAuthCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Show controls related to SQL Server Authentication
            UsernameTextBox.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Visible;
        }

        private void SqlServerAuthCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Hide controls related to SQL Server Authentication
            UsernameTextBox.Visibility = Visibility.Collapsed;
            PasswordBox.Visibility = Visibility.Collapsed;
        }

        private void ExecuteQueryButton_Click(object sender, RoutedEventArgs e)
        {
            string queryString = QueryTextBox.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    SqlDataAdapter adapter;
                    DataTable dataTable;

                    // Use csvData if it has been populated
                    if (csvData.Rows.Count > 0)
                    {
                        adapter = new SqlDataAdapter(queryString, GetConnectionString());
                        dataTable = csvData.Copy();
                    }
                    else
                    {
                        adapter = new SqlDataAdapter(queryString, connection);
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);
                    }

                    ResultDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing query: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateQueryHistoryListBox()
        {
            // Update the ListBox with the query history
            QueryHistoryListBox.ItemsSource = queryHistory;
        }

        // Additional event handler for selecting a query from history
        private void QueryHistoryListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (QueryHistoryListBox.SelectedItem != null)
            {
                // Set the selected query in the text box
                QueryTextBox.Text = QueryHistoryListBox.SelectedItem.ToString();
            }
        }
        private void ImportCsvButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Show file dialog to select CSV file
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    DefaultExt = ".csv",
                    Filter = "CSV Files (*.csv)|*.csv"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    string csvFilePath = openFileDialog.FileName;

                    // Read CSV and populate DataTable
                    csvData = ReadCsvToDataTable(csvFilePath);

                    // Display imported data in the DataGrid
                    ResultDataGrid.ItemsSource = csvData.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing CSV: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private DataTable ReadCsvToDataTable(string filePath)
        {
            DataTable dataTable = new DataTable();

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Read header
                string[] headers = parser.ReadFields();
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }

                // Read data
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    dataTable.Rows.Add(fields);
                }
            }

            return dataTable;
        }
    }
}
