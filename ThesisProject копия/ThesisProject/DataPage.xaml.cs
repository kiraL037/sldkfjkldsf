using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ThesisProject
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        public ObservableCollection<DynamicDataModel> Data { get; set; }
        private string _connectionString;
        private string _tableName;
        private string _pKColumn;

        public DataPage()
        {
            InitializeComponent();
            Data = new ObservableCollection<DynamicDataModel>();
            DataGrid.ItemsSource = Data;
        }

        public DataPage(ObservableCollection<DynamicDataModel> data) : this()
        {
            LoadData(data);
        }

        public DataPage(string connectionString, string tableName, string primaryKeyColumn) : this()
        {
            _connectionString = connectionString;
            _tableName = tableName;
            _pKColumn = primaryKeyColumn;
        }

        public void LoadData(DataTable dataTable)
        {
            Data.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                var model = new DynamicDataModel();
                foreach (DataColumn column in dataTable.Columns)
                {
                    model.Data[column.ColumnName] = row[column];
                }
                Data.Add(model);
            }
        }

        public void LoadData(ObservableCollection<DynamicDataModel> data)
        {
            Data.Clear();
            foreach (var model in data)
            {
                Data.Add(model);
            }
        }

        public DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();

            if (Data.Count > 0)
            {
                foreach (var key in Data[0].Data.Keys)
                {
                    dataTable.Columns.Add(key);
                }

                foreach (var model in Data)
                {
                    DataRow row = dataTable.NewRow();

                    foreach (var kvp in model.Data)
                    {
                        row[kvp.Key] = kvp.Value;
                    }
                    dataTable.Rows.Add(row);
                }
            }
            return dataTable;
        }

        private async void AddData_Click(object sender, RoutedEventArgs e)
        {
            var newData = new DynamicDataModel();
            var dialog = new DataEntryDialog(newData);

            if (dialog.ShowDialog() == true)
            {
                Data.Add(newData);
                await DBReader.InsertDataAsync(_connectionString, _tableName, newData);
            }
        }

        private async void UpdateData_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is DynamicDataModel selectedData)
            {
                var dialog = new DataEntryDialog(selectedData);

                if (dialog.ShowDialog() == true)
                {
                    await DBReader.UpdateDataAsync(_connectionString, _tableName,
                        selectedData, _pKColumn, selectedData.Data[_pKColumn]);
                }
            }
        }

        private async void DeleteData_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is DynamicDataModel selectedData)
            {
                Data.Remove(selectedData);
                await DBReader.DeleteDataAsync(_connectionString, _tableName,
                    _pKColumn, selectedData.Data[_pKColumn]);
            }
        }
    }
}