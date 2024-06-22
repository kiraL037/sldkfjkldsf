using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using MathNet.Numerics.RootFinding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace DataAnalytics
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class DataVisualizationWindow : Window
    {
        public SeriesCollection SeriesCollection { get; set; }

        public DataVisualizationWindow(List<double> selectedData)
        {
            InitializeComponent();

            // используем SeriesCollection
            SeriesCollection = new SeriesCollection();

            // создаем LineSeries и добавляем к SeriesCollection
            var lineSeries = new LineSeries
            {
                Title = "Data",
                Values = new ChartValues<double>(selectedData)
            };

            SeriesCollection.Add(lineSeries);

            // используем SeriesCollection в диаграмме
            chart.Series = SeriesCollection;
        }
    }
}