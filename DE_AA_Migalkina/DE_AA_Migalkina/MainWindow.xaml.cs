using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DE_AA_Migalkina;

namespace DE_AA_Migalkina
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataAccessLayer dataAccess;

        public MainWindow()
        {
            InitializeComponent();
            dataAccess = new DataAccessLayer();
            LoadRequests();
        }

        private void LoadRequests()
        {
            List<Request> requests = dataAccess.GetAllRequests();
            dataGrid.ItemsSource = requests;
        }

        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            // Получаем максимальное значение идентификатора заявки из базы данных
            int maxId = dataAccess.GetMaxRequestId();

            // Создаем новый идентификатор заявки, увеличивая максимальное значение на 1
            int newId = maxId + 1;

            // Создаем новую заявку на основе введенных данных
            Request newRequest = new Request
            {
                ID_Request = newId,
                Date_Request = DateTime.Now, 
                Equipment = txtEquipment.Text,
                Type_Issue = cmbType.Text, 
                Description_Issue = txtDescription.Text,
                Name_Client = txtClientName.Text,
                Status = "Новая" 
            };

            // Добавляем новую заявку в базу данных
            dataAccess.AddEquipmentRequest(newRequest);

            // Обновляем отображение списка заявок
            LoadRequests();
        }

        private void EditRequest_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранной заявки
            Request selectedRequest = dataGrid.SelectedItem as Request;

            if (selectedRequest != null)
            {
                // Проверка наличия данных в текстовых полях
                if (!string.IsNullOrEmpty(txtEquipment.Text) &&
                    !string.IsNullOrEmpty(cmbType.Text) &&
                    !string.IsNullOrEmpty(txtDescription.Text) &&
                    !string.IsNullOrEmpty(txtClientName.Text))
                {
                    // Редактирование выбранной заявки на основе введенных данных
                    selectedRequest.Equipment = txtEquipment.Text;
                    selectedRequest.Type_Issue = cmbType.Text;
                    selectedRequest.Description_Issue = txtDescription.Text;
                    selectedRequest.Name_Client = txtClientName.Text;

                    // Сохранение изменений в базе данных
                    dataAccess.UpdateRequest(selectedRequest);

                    // Обновляем отображение списка заявок
                    LoadRequests();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для редактирования.");
            }
        }

        private void DeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            Request selectedRequest = dataGrid.SelectedItem as Request;
           
            if (selectedRequest != null)
            {
                // Запрос подтверждения удаления заявки
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту заявку?", "Подтверждение удаления", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    // Удаление выбранной заявки из базы данных
                    dataAccess.DeleteEquipmentRequest(selectedRequest.ID_Request);

                    // Обновляем отображение списка заявок
                    LoadRequests();
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для удаления.");
            }
        }
    }
}
