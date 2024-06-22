using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ThesisProject
{
    /// <summary>
    /// Логика взаимодействия для SelectTableDialog.xaml
    /// </summary>
    public partial class SelectTableDialog : Window
    {
        public string ConnectionString { get; set; }
        public string SelectedTable => TablesComboBox.SelectedItem as string;
        public string SelectedPKColumn => PrimaryKeyComboBox.SelectedItem as string;

        public SelectTableDialog()
        {
            InitializeComponent();
            TablesComboBox.SelectionChanged += TablesComboBox_SelectionChanged;
        }

        private async void TablesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TablesComboBox.SelectedItem == null) 
                return;

            string selectedTable=TablesComboBox.SelectedItem.ToString();

            try
            {
                using (SqlConnection connection=new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='{selectedTable}'";
                    SqlCommand command = new SqlCommand(query, connection);

                    using(SqlDataReader reader=await command.ExecuteReaderAsync())
                    {
                        List<string> columns = new List<string>();

                        while(await reader.ReadAsync())
                        {
                            columns.Add(reader.GetString(0));
                        }
                        PrimaryKeyComboBox.ItemsSource = columns;
                    }
                }    

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка в отображении таблицы: {ex.Message}");
            }
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string server = ServerTextbox.Text;
            string database = DatabaseTextbox.Text;
            string user = UserTextbox.Text;
            string password = Passwordbox.Password;
            ConnectionString = $"Server={server};Database={database};User Id={user};Password={password};";

            try
            {
                using (SqlConnection connection=new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();
                    DataTable schema = connection.GetSchema("Tables");

                    List<string> tables = new List<string>();
                    foreach (DataRow row in schema.Rows)
                    {
                        tables.Add(row[2].ToString());
                    }
                    TablesComboBox.ItemsSource = tables;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подключении к базе данных: {ex.Message}");
            }
        }
    }
}
