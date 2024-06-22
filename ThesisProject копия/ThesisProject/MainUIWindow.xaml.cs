using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;

namespace ThesisProject
{
    /// <summary>
    /// Логика взаимодействия для MainUIWindow.xaml
    /// </summary>
    public partial class MainUIWindow : Window
    {
        private string _connectionString;
        private string _tableName;
        private string _pKColumn;

        public MainUIWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new HomePage());
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                DataTable dataTable = LoadDataFromFIle(filePath);
                DisplayData(dataTable);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DataPage dataPage = MainFrame.Content as DataPage;
            if (dataPage != null)
            {
                DataTable dataTable = dataPage.GetDataTable();
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|All files (*.*)|*.*"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    SaveDataToFile(dataTable, filePath);
                }
            }
        }

        private void SaveDataToFile(DataTable dataTable, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                string[] columnNames = dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
                sw.WriteLine(string.Join(",", columnNames));

                foreach(DataRow row in dataTable.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sw.WriteLine(string.Join(",", fields));
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "CSV files (*.csv)|All files(*.*)|*.*";
            
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                DataTable dataTable = LoadDataFromFIle(filePath);
                DisplayData(dataTable);
            }
        }

        private void DisplayData(DataTable dataTable)
        {
            ObservableCollection<DynamicDataModel> dataCollection = new ObservableCollection<DynamicDataModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                var model = new DynamicDataModel();
                foreach (DataColumn column in dataTable.Columns)
                {
                    model.Data[column.ColumnName] = row[column];
                }
                dataCollection.Add(model);
            }

            var dataPage = new DataPage(dataCollection);
            MainFrame.Navigate(dataPage);
        }

        private DataTable LoadDataFromFIle(string filePath)
        {
            DataTable dataTable = new DataTable();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] headers = sr.ReadLine().Split(',');

                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }

                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dataTable.NewRow();

                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dataTable.Rows.Add(dr);
                }
            }
            return dataTable;
        }

        private async void ConnectToDB_Click(object sender, RoutedEventArgs e)
        {
            var connectionWindow = new SelectTableDialog();

            if (connectionWindow.ShowDialog() == true)
            {
                _connectionString = connectionWindow.ConnectionString;
                _tableName = connectionWindow.SelectedTable;
                _pKColumn = connectionWindow.SelectedPKColumn;

                var data = await DBReader.LoadDataAsync(_connectionString, _tableName);

                var observableData = new ObservableCollection<DynamicDataModel>(data);

                var dataPage = new DataPage(observableData);

                MainFrame.Navigate(dataPage);

                LoadDataButton.IsEnabled = true;
                SaveDataButton.IsEnabled = true;
                AnalyzeDataButton.IsEnabled = true;
            }
        }

        private void AnalyzeData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DataPage());
        }


    }
}
