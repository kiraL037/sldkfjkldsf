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

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для AnalysisWindow.xaml
    /// </summary>
    public partial class AnalysisWindow : Window
    {
        public AnalysisWindow()
        {
            InitializeComponent();
            // Populate the ComboBox with analysis options
            AnalysisComboBox.Items.Add("Analysis 1");
            AnalysisComboBox.Items.Add("Analysis 2");
            // Add more analysis options as needed
        }

        private void RunAnalysis_Click(object sender, RoutedEventArgs e)
        {
            string selectedAnalysis = AnalysisComboBox.SelectedItem.ToString();

            if (selectedAnalysis == "Analysis 1")
            {
                string parameters = ParameterTextBox.Text;
                // Process analysis with the provided parameters
                // Example:
                // var result = YourAnalysisLogic.PerformAnalysis1WithParameters(parameters);
                // Display or process the result accordingly
            }
            // Implement logic for other analysis options with parameters
        }
    }
}
