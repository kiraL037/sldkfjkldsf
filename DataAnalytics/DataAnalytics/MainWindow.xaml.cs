using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LiveCharts;
using Microsoft.VisualBasic;
using MathNet.Numerics.LinearAlgebra;
using System.Data;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.Remoting.Messaging;
using Serilog;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataAnalytics
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SeriesCollection SeriesCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SeriesCollection = new SeriesCollection();
        }
        private async void LoadFileButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            // создаем OpenFileDialog чтобы позволить пользователю выбрать файл
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv|XML Files (*.xml)|*.xml|All Files (*.*)|*.*";

            // если пользователь выбирает файл и нажимает ОК
            if (openFileDialog.ShowDialog() == true)
            {
                // получаем путь к файлу
                string filePath = openFileDialog.FileName;

                // показываем индикатор загрузки для удобства пользоватлея
                // пока файл загружается асинхронно
                progressBar.Visibility = Visibility.Visible;

                // загружаем данные асинхронно
                await Task.Run(() => LoadDataToGrid(filePath));

                // организовываем ComboBoxes с именами столбцов
                List<string> columns = LoadColumnsFromCsv(filePath);

                // проверяем если столбцы доступны
                if (columns.Any())
                { 
                    // удаляем существующие файлы ComboBoxes
                    xAxisComboBox.Items.Clear();
                    yAxisComboBox.Items.Clear();

                    foreach (string column in columns)
                    {
                        xAxisComboBox.Items.Add(column);
                        yAxisComboBox.Items.Add(column);
                    }

                    // выбираем первый по умолчанию
                    xAxisComboBox.SelectedIndex = 0;
                    yAxisComboBox.SelectedIndex = 0;

                    // прячем индикатор загрузки
                    progressBar.Visibility = Visibility.Hidden;
                }

                else
                {
                    // показываем сообщение об ошибке если столбцы не найдены
                    MessageBox.Show("В выбранном файле нет столбцов.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RunRegressionAnalysisButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedXColumn = xAxisComboBox.SelectedItem as string;
            string selectedYColumn = yAxisComboBox.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedXColumn) || string.IsNullOrEmpty(selectedYColumn))
            {
                MessageBox.Show("Выберите пожалуйства столбцы и X и Y для регрессионного анализа.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DataView dataView = dataGrid.ItemsSource as DataView;

            // получаем числа из преобразованных столбцов 
            List<double> xValues = GetNumericValues(dataView.ToTable(), selectedXColumn, skipFirstRow: true);
            List<double> yValues = GetNumericValues(dataView.ToTable(), selectedYColumn, skipFirstRow: true);

            if (xValues.Count == 0 || yValues.Count == 0)
            {
                MessageBox.Show("В выбранных столбцах нет числовых данных, выберите другие столбцы.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // регрессионный анализ
            double regressionResult = regression.RegresStat(xValues.ToArray(), yValues.ToArray());
            double szalKvLinearResult = regression.SzalKvLinear(xValues.ToArray(), yValues.ToArray());
            double szalKvParabolicResult = regression.SzalKvParabolic(xValues.ToArray(), yValues.ToArray());
            Tuple<double, double, double> regressionParams = regression.Params(xValues.ToArray(), yValues.ToArray());

            // показываем результат
            resultTextBlock.Text = $"Результат регрессивного анализа: {regressionResult}\n" +
                                   $"Линия регрессии: {szalKvLinearResult}\n" +
                                   $"Результат параболической регрессии: {szalKvParabolicResult}\n" +
                                   $"Коэффициенты: A={regressionParams.Item1}, B={regressionParams.Item2}, C={regressionParams.Item3}";
        }

        private async void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedXColumn = xAxisComboBox.SelectedItem as string;
            string selectedYColumn = yAxisComboBox.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedXColumn) || string.IsNullOrEmpty(selectedYColumn))
            {
                MessageBox.Show("Выберите пожалуйства столбцы и X и Y для анализа.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DataView dataView = dataGrid.ItemsSource as DataView;

            if (!dataView.Table.Columns.Contains(selectedXColumn) || !dataView.Table.Columns.Contains(selectedYColumn))
            {
                MessageBox.Show("Выбранные столбцы не существуют.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<double> xValues = GetNumericValues(dataView.ToTable(), selectedXColumn, skipFirstRow: true);
            List<double> yValues = GetNumericValues(dataView.ToTable(), selectedYColumn, skipFirstRow: true);

            if (xValues.Count == 0 || yValues.Count == 0)
            {
                MessageBox.Show("В выбранных столбцах нет числовых данных, выберите другие столбцы.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // показываем индикатор загрузки для удобства пользоватлея
                // пока файл загружается асинхронно
                progressBar.Visibility = Visibility.Visible;

                // создаем IProgress<int> для отображения прогресса
                var progress = new Progress<int>(value =>
                {
                    // обновляем прогресс
                    progressBar.Value = value;
                });

                // Вызываем метод PerformAnalysisWithProgress 
                string result = await Task.Run(() =>
                    PerformAnalysisWithProgress(selectedXColumn, xValues, selectedYColumn, yValues, progress));

                // отображаем результат анализа
                resultTextBlock.Text = result;

                // прячем индикатор загрузки
                progressBar.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка в анализе: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string PerformAnalysisWithProgress(string xColumnName, List<double> xValues, string yColumnName, List<double> yValues, IProgress<int> progress)
        {
          
            double meanX = xValues.Average();
            double meanY = yValues.Average();


            int totalSteps = 100; 

            for (int step = 0; step < totalSteps; step++)
            {
                progress.Report((step * 100) / totalSteps);
            }

            return $"Результат анализа:\nСтолбец {xColumnName}: {meanX:F2}\nСтолбец {yColumnName}: {meanY:F2}";
        }

        private List<double> GetNumericValues(DataTable dataTable, string columnName, bool skipFirstRow)
        {
            IEnumerable<DataRow> dataRows = dataTable.Rows.Cast<DataRow>();

            if (skipFirstRow)
            {
                dataRows = dataRows.Skip(1);
            }

            List<double> numericValues = new List<double>();

            foreach (DataRow row in dataRows)
            {
                if (row[columnName] is IConvertible convertibleValue)
                {
                    try
                    {
                        double numericValue = Convert.ToDouble(convertibleValue);
                        numericValues.Add(numericValue);
                    }
                    catch (FormatException)
                    {
                        
                    }
                }
            }

            return numericValues;
        }

        private async void OpenVisualizationButton_Click(object sender, RoutedEventArgs e)
        {
            // выбераем столбец из ComboBox
            string selectedColumnName = xAxisComboBox.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedColumnName))
            {
                MessageBox.Show("Пожалуйства выберите столбец.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DataView dataView = dataGrid.ItemsSource as DataView;

            if (dataView != null && dataView.Table.Rows.Count > 0)
            {
                // показываем индикатор загрузки для удобства пользоватлея
                // пока файл загружается асинхронно
                progressBar.Visibility = Visibility.Visible;
                List<double> columnData = GetNumericValues(dataView.ToTable(), selectedColumnName, skipFirstRow: true);

                if (columnData.Count > 0)
                {
                    // открываем окно DataVisualizationWindow с выбранным столбцом
                    var visualizationWindow = new DataVisualizationWindow(columnData);

                    visualizationWindow.Show();

                    // позволяет работать на главном экране при открытой диаграмме
                    await Task.Yield();

                    return;
                }
                // прячем индикатор загрузки
                progressBar.Visibility = Visibility.Hidden;
            }

            MessageBox.Show("Данные не найдены или равны нулю.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void LoadDataToGrid(string filePath)
        {
            var dataSet = new DataSet();

            try
            {
                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.SetDelimiters(",");

                    // читаем названия столбцов
                    string[] headers = parser.ReadFields();

                    //создаем DataTable со столбцами в зависимости от прочитанных названий
                    DataTable dataTable = new DataTable();
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }

                    // читаем строки
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        dataTable.Rows.Add(fields);
                    }

                    dataSet.Tables.Add(dataTable);
                }

                if (dataSet.Tables.Count > 0)
                {
                    Dispatcher.Invoke(() => dataGrid.ItemsSource = dataSet.Tables[0].DefaultView);
                }
            }

            catch (Exception ex)
            {
                // используем SeriaLog
                Log.Error(ex, "Ошибка в загрузке данных");

                // показываем ошибку пользователю
                MessageBox.Show($"Ошибка в загрузке данных: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<string> LoadColumnsFromCsv(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                return lines[0].Split(',').ToList();
            }
            return new List<string>();
        }
    }
}