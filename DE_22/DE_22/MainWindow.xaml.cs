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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DE_22
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int clientId;

        public MainWindow()
        {
            InitializeComponent();
            RefreshRequestList();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            Create createOrderWindow = new Create(clientId);
            createOrderWindow.ShowDialog();
            RefreshRequestList();
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            if (RequestListView.SelectedItem is Order selectedOrder)
            {
                Edit editOrderWindow = new Edit(clientId);
                editOrderWindow.ShowDialog();
                RefreshRequestList();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshRequestList()
        {
            RequestListView.ItemsSource = GetRequests();
        }

        private List<Order> GetRequests()
        {
            // Логика для получения списка заявок из базы данных или списка
            return new List<Order>
            {
                new Order { Id = 1, Date = DateTime.Now, Type = "Принтер", Model = "HP", Description = "Не печатает", ClientName = "Иван Иванов", Phone = "1234567890", Status = "Новая заявка" },
                new Order { Id = 2, Date = DateTime.Now, Type = "Сканер", Model = "Canon", Description = "Не сканирует", ClientName = "Петр Петров", Phone = "0987654321", Status = "В процессе ремонта" }
            };
        }

        private void ViewOrders_Click(object sender, RoutedEventArgs e)
        {
            ViewOrders viewOrders = new ViewOrders();
            viewOrders.ShowDialog();
        }
    }
}