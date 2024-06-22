using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.ML;
using Microsoft.ML.AutoML;
using Microsoft.ML.Data;

namespace CourseProject
{
    public partial class MainWindow : Window
    {
        private static readonly MLContext mlContext = new MLContext();
        private DataTable dataTable;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Prompt user to enter the label column name
                Console.Write("Enter the label column name: ");
                string labelColumnName = Console.ReadLine();

                // Open file dialog to choose CSV file
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                    Title = "Choose CSV File"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    // Load data with dynamic columns
                    var textLoader = mlContext.Data.LoadFromTextFile(openFileDialog.FileName, separatorChar: ',');

                    // Display column names and types for informational purposes
                    var columnInfo = textLoader.Schema.Select(column => $"{column.Name}: {column.Type}");
                    Console.WriteLine($"Columns in the dataset: {string.Join(", ", columnInfo)}");

                    // Create DataTable based on the inferred columns
                    dataTable = new DataTable();

                    foreach (var column in textLoader.Schema)
                    {
                        dataTable.Columns.Add(column.Name);
                    }

                    // Load data into the DataTable
                    foreach (var row in mlContext.Data.CreateEnumerable<object>(textLoader, reuseRowObject: false))
                    {
                        var dataRow = dataTable.NewRow();
                        foreach (var column in textLoader.Schema)
                        {
                            dataRow[column.Name] = row.GetType().GetProperty(column.Name).GetValue(row);
                        }
                        dataTable.Rows.Add(dataRow);
                    }

                    // Show data in the DataGrid
                    Data.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteData_Click(object sender, RoutedEventArgs e)
        {
            // Logic to delete the database
            DeleteDataButton.IsEnabled = false;
        }

        private void ChooseAnalysis_Click(object sender, RoutedEventArgs e)
        {
            // Logic to open a window or dialog for selecting analysis
            // Navigate to Window 2
        }
        private void DataAnalysis(object sender, RoutedEventArgs e)
        {
            AnalysisWindow newForm = new AnalysisWindow();
            newForm.Show();
            Close();
        }

        private void ChooseAnalysisButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
