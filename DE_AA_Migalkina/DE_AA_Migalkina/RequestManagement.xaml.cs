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

namespace DE_AA_Migalkina
{
    /// <summary>
    /// Логика взаимодействия для RequestManagement.xaml
    /// </summary>
    public partial class RequestManagement : Window
    {
        private DataAccessLayer dataAccessLayer;

        public RequestManagement()
        {
            InitializeComponent();
            dataAccessLayer = new DataAccessLayer();
            LoadRequests();
        }

        private void LoadRequests()
        {
            lvRequests.ItemsSource = dataAccessLayer.GetAllRequests();
        }
    }
}
