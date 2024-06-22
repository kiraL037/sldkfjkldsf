using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
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

namespace CourseProjectAAAAA
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ChartWindow : Window
    {
        private ChartWindowViewModel viewModel;

        public ChartWindow(List<OrderData> dataset)
        {
            InitializeComponent();
            viewModel = new ChartWindowViewModel();  // Create an instance
            DataContext = viewModel;  // Set as DataContext

            // Ensure ViewModel initialization
            viewModel.BarChartValues = new SeriesCollection();
            viewModel.PieChartValues = new SeriesCollection();

            CreateVisualizations(dataset);
        }

        // Step 6: Visualizations
        public void CreateVisualizations(List<OrderData> dataset)
        {
            try
            {
                var categories = dataset.GroupBy(o => o.category)
                           .Select(group => new { Category = group.Key, Count = group.Count() })
                           .OrderByDescending(item => item.Count)
                           .ToList();

                SeriesCollection barChartValues = new SeriesCollection();
                foreach (var category in categories)
                {
                    barChartValues.Add(new ColumnSeries
                    {
                        Title = category.Category,
                        Values = new ChartValues<int> { category.Count }
                    });
                }

                // Pie chart for payment methods
                var paymentMethods = dataset.GroupBy(o => o.payment_method)
                                           .Select(group => new { Method = group.Key, Count = group.Count() })
                                           .ToList();

                SeriesCollection pieChartValues = new SeriesCollection();
                foreach (var method in paymentMethods)
                {
                    pieChartValues.Add(new PieSeries
                    {
                        Title = method.Method,
                        Values = new ChartValues<int> { method.Count },
                        DataLabels = true
                    });
                }

                // Update the view model properties
                viewModel.BarChartValues = barChartValues;
                viewModel.PieChartValues = pieChartValues;

                // Add debug statements
                Console.WriteLine($"BarChartValues Count: {viewModel.BarChartValues?.Count}");
                Console.WriteLine($"PieChartValues Count: {viewModel.PieChartValues?.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateVisualizations: {ex.Message}");

            }
        }
    }
}


