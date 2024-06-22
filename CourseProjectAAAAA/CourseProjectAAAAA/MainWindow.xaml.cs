using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using OxyPlot;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.Reflection;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using LiveCharts.Wpf;
using LiveCharts;

namespace CourseProjectAAAAA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public class OrderData
    {
        [LoadColumn(1)] public string order_id;
        [LoadColumn(2)] public DateTime order_date;
        [LoadColumn(3)] public string status;
        [LoadColumn(4)] public float item_id;
        [LoadColumn(5)] public string sku;
        [LoadColumn(6)] public float qty_ordered;
        [LoadColumn(7)] public float price;
        [LoadColumn(8)] public float value;
        [LoadColumn(9)] public float discount_amount;
        [LoadColumn(10)] public float total;
        [LoadColumn(11)] public string category;
        [LoadColumn(12)] public string payment_method;
        [LoadColumn(13)] public string bi_st;
        [LoadColumn(14)] public float cust_id;
        [LoadColumn(15)] public int year;
        [LoadColumn(16)] public string month;
        [LoadColumn(17)] public float ref_num;
        [LoadColumn(18)] public string name_prefix;
        [LoadColumn(19)] public string First_Name;
        [LoadColumn(20)] public string Middle_Initial;
        [LoadColumn(21)] public string Last_Name;
        [LoadColumn(22)] public string Gender;
        [LoadColumn(23)] public float age;
        [LoadColumn(24)] public string full_name;
        [LoadColumn(25)] public string EMail;
        [LoadColumn(25)] public DateTime Customer_Since;
        [LoadColumn(26)] public string SSN;
        [LoadColumn(27)] public string PhoneNo;
        [LoadColumn(28)] public string PlaceName;
        [LoadColumn(29)] public string Country;
        [LoadColumn(30)] public string City;
        [LoadColumn(31)] public string State;
        [LoadColumn(32)] public float Zip;
        [LoadColumn(33)] public string Region;
        [LoadColumn(34)] public string UserName;
        [LoadColumn(35)] public float Discount_Percent;
    }

    public class OrderMap : ClassMap<OrderData>
    {
        public OrderMap()
        {
            Map(m => m.order_id).Name("order_id");
            Map(m => m.order_date).Name("order_date").TypeConverterOption.Format("yyyy-MM-dd");
            Map(m => m.status).Name("status");
            Map(m => m.item_id).Name("item_id");
            Map(m => m.sku).Name("sku");
            Map(m => m.qty_ordered).Name("qty_ordered");
            Map(m => m.price).Name("price");
            Map(m => m.value).Name("value");
            Map(m => m.discount_amount).Name("discount_amount");
            Map(m => m.total).Name("total");
            Map(m => m.category).Name("category");
            Map(m => m.payment_method).Name("payment_method");
            Map(m => m.bi_st).Name("bi_st");
            Map(m => m.cust_id).Name("cust_id");
            Map(m => m.year).Name("year");
            Map(m => m.month).Name("month");
            Map(m => m.ref_num).Name("ref_num");
            Map(m => m.name_prefix).Name("name_prefix");
            Map(m => m.First_Name).Name("First_Name");
            Map(m => m.Middle_Initial).Name("Middle_Initial");
            Map(m => m.Last_Name).Name("Last_Name");
            Map(m => m.Gender).Name("Gender");
            Map(m => m.age).Name("age");
            Map(m => m.full_name).Name("full_name");
            Map(m => m.EMail).Name("EMail");
            Map(m => m.Customer_Since).Name("Customer_Since").TypeConverterOption.Format("M/d/yyyy");
            Map(m => m.SSN).Name("SSN");
            Map(m => m.PhoneNo).Name("PhoneNo");
            Map(m => m.PlaceName).Name("PlaceName");
            Map(m => m.Country).Name("Country");
            Map(m => m.City).Name("City");
            Map(m => m.State).Name("State");
            Map(m => m.Zip).Name("Zip");
            Map(m => m.Region).Name("Region");
            Map(m => m.UserName).Name("UserName");
            Map(m => m.Discount_Percent).Name("Discount_Percent");
        }
    }

    public partial class MainWindow : Window
    {
        private List<OrderData> dataset;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadDataset_Click(object sender, RoutedEventArgs e)
        {
            dataset = LoadDataset("C:\\Users\\Анастас\\Downloads\\sales_06_FY2020-21 copy.csv");
            dataGrid.ItemsSource = dataset; 
            if (dataset != null && dataset.Any())
            {
                Console.WriteLine($"Number of rows in dataset: {dataset.Count}");
            }
            else
            {
                Console.WriteLine("Dataset is null or empty.");
            }
        }

        private void InitialExploration_Click(object sender, RoutedEventArgs e)
        {
            DisplayFirstRows(dataset);
            CheckDataTypes(dataset);
        }

        private void DataCleaning_Click(object sender, RoutedEventArgs e)
        {
            dataset = CleanData(dataset);
            if (dataset != null)
            {
                // Remove null values
                dataset = dataset.Where(o => o != null).ToList();

                // Remove duplicates based on OrderId
                dataset = dataset.GroupBy(o => o.order_id)
                                 .Select(group => group.First())
                                 .ToList();

                // Display the cleaned dataset in the DataGrid
                dataGrid.ItemsSource = dataset.Take(5).ToList();
            }
            else
            {
                MessageBox.Show("Please load the dataset first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void FeatureEngineering_Click(object sender, RoutedEventArgs e)
        {
            dataset = FeatureEngineering(dataset); 
            if (dataset != null)
            {
                // Extract year and month from order_date
                foreach (var order in dataset)
                {
                    order.year = order.order_date.Year;
                    order.month = order.order_date.ToString("MMM-yyyy");
                }

                // Display the dataset with added features in the DataGrid
                dataGrid.ItemsSource = dataset.Take(5).ToList();
            }
            else
            {
                MessageBox.Show("Please load the dataset first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DescriptiveStatistics_Click(object sender, RoutedEventArgs e)
        {
            ComputeStatistics(dataset); 
            if (dataset != null)
            {
                var orderValues = dataset.Select(o => o.value).ToList();
                var mean = orderValues.Average();
                var min = orderValues.Min();
                var max = orderValues.Max();

                MessageBox.Show($"Mean: {mean}, Min: {min}, Max: {max}", "Descriptive Statistics", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please load the dataset first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Visualizations_Click(object sender, RoutedEventArgs e)
        {
            if (dataset != null)
            {
                // Create a new instance of ChartWindow and pass the dataset
                ChartWindow chartWindow = new ChartWindow(dataset);

                // Show the ChartWindow
                chartWindow.Show();
            }
            else
            {
                MessageBox.Show("Please load the dataset first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SaveCleanedDataset_Click(object sender, RoutedEventArgs e)
        {
            if (dataset != null)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv",
                    DefaultExt = "csv",
                    FileName = "cleaned_dataset.csv"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    using (var writer = new StreamWriter(saveFileDialog.FileName))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<OrderMap>();
                        csv.WriteRecords(dataset);
                    }

                    MessageBox.Show("Cleaned dataset saved successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please load the dataset first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private static List<OrderData> LoadDataset(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Context.RegisterClassMap<OrderMap>();
                return csv.GetRecords<OrderData>().ToList();
            }
        }

        // Step 2: Initial Exploration
        private static void DisplayFirstRows(List<OrderData> dataset)
        {
            if (dataset != null)
            {
                var firstRows = dataset.Take(5);
                Console.WriteLine("First few rows of the dataset:");
                foreach (var row in firstRows)
                {
                    Console.WriteLine($"{row.order_id}, {row.order_date}, {row.status}, " +
                        $"{row.item_id}, {row.sku}, {row.qty_ordered}, {row.price}, " +
                        $"{row.value}, {row.discount_amount}, {row.total}, {row.category},  " +
                        $"{row.payment_method},  {row.bi_st},  {row.cust_id},  {row.year},  " +
                        $"{row.month},  {row.ref_num},  {row.name_prefix}, {row.First_Name},  " +
                        $"{row.Middle_Initial},  {row.Last_Name},  {row.Gender},  {row.age},  " +
                        $"{row.full_name},  {row.EMail},  {row.Customer_Since}, {row.SSN},    " +
                        $"{row.PhoneNo}, {row.PlaceName}, {row.Country}, {row.City}, " +
                        $"{row.State}, {row.Zip}, {row.Region}, {row.UserName}, {row.Discount_Percent}$");
                }
            }
            else
            {
                MessageBox.Show("Please load the dataset first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private static void CheckDataTypes(List<OrderData> dataset)
        {
            if (dataset != null)
            {
                // Inspect the data types of properties in the Order class
                Console.WriteLine("Data types of properties in Order class:");
                var orderProperties = typeof(OrderData).GetProperties();
                foreach (var property in orderProperties)
                {
                    Console.WriteLine($"{property.Name}: {property.PropertyType}");
                }
            }
            else
            {
                MessageBox.Show("Please load the dataset first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Step 3: Data Cleaning
        private static List<OrderData> CleanData(List<OrderData> dataset)
        {
            dataset = dataset.Where(o => o != null).ToList();

            // Remove duplicates based on OrderId
            dataset = dataset.GroupBy(o => o.order_id)
                             .Select(group => group.First())
                             .ToList();

            return dataset;

        }

        // Step 4: Feature Engineering
        private static List<OrderData> FeatureEngineering(List<OrderData> dataset)
        {
            foreach (var order in dataset)
            {
                order.year = order.order_date.Year;
                order.month = order.order_date.ToString("MMM-yyyy");
            }

            return dataset;
        }

        // Step 5: Descriptive Statistics
        private static void ComputeStatistics(List<OrderData> dataset)
        {
            if (dataset != null)
            {
                var orderValues = dataset.Select(o => o.value).ToList();
                var mean = orderValues.Average();
                var min = orderValues.Min();
                var max = orderValues.Max();

                Console.WriteLine($"Mean: {mean}, Min: {min}, Max: {max}");
            }
            else
            {
                MessageBox.Show("Please load the dataset first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}