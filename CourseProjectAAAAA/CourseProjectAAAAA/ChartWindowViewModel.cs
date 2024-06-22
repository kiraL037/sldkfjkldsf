using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectAAAAA
{
    public class ChartWindowViewModel : INotifyPropertyChanged
    {
        private SeriesCollection _barChartValues;
        public SeriesCollection BarChartValues
        {
            get { return _barChartValues; }
            set
            {
                _barChartValues = value;
                OnPropertyChanged(nameof(BarChartValues));
            }
        }

        private SeriesCollection _pieChartValues;
        public SeriesCollection PieChartValues
        {
            get { return _pieChartValues; }
            set
            {
                _pieChartValues = value;
                OnPropertyChanged(nameof(PieChartValues));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}