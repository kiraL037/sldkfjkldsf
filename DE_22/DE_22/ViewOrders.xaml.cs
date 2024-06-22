using System;
using System.Collections.Generic;
using System.Data;
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

namespace DE_22
{
    /// <summary>
    /// Логика взаимодействия для ViewOrders.xaml
    /// </summary>
    public partial class ViewOrders : Window
    {
        public ViewOrders()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            throw new NotImplementedException();
        }
        public static List<Order> GetAllOrders()
        {
            string query = "SELECT * FROM Orders;";
            DataTable dataTable = DB.ExecuteQuery(query);

            List<Order> Orders = new List<Order>();

            foreach (DataRow row in dataTable.Rows)
            {
                Order Order = new Order
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Date = Convert.ToDateTime(row["DateAdded"]),
                    Type = row["EquipmentType"].ToString(),
                    Model = row["Model"].ToString(),
                    Description = row["ProblemDescription"].ToString(),
                    ClientName = row["ClientName"].ToString(),
                    Phone = row["ClientPhone"].ToString(),
                    Status = row["Status"].ToString(),
                    AssignedMaster = row["AssignedMaster"].ToString()
                };
                Orders.Add(Order);
            }

            return Orders;
        }
    }
}
