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

namespace ThesisProject
{
    /// <summary>
    /// Логика взаимодействия для DataEntryDialog.xaml
    /// </summary>
    public partial class DataEntryDialog : Window
    {
        public DynamicDataModel DataModel { get; set; }

        public DataEntryDialog(DynamicDataModel dataModel)
        {
            InitializeComponent();
            DataModel = dataModel;
            LoadFields();
        }

        private void LoadFields()
        {
            foreach (var kvp in DataModel.Data)
            {
                var stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
                var label = new TextBlock { Text = kvp.Key, Width = 100 };
                var textBox = new TextBox { Text = kvp.Value.ToString() }; 
                textBox.TextChanged += (s, e) => DataModel.Data[kvp.Key] = textBox.Text;
                stackPanel.Children.Add(label);
                stackPanel.Children.Add(textBox);
                FieldsPanel.Items.Add(stackPanel);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
