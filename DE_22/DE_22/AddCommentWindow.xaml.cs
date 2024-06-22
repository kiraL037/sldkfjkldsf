using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AddCommentWindow.xaml
    /// </summary>
    public partial class AddCommentWindow : Window
    {
        private string connectionString = "your_connection_string_here";
        private int requestId;
        private int masterId;
        private string comment;

        public AddCommentWindow(int requestId, int masterId)
        {
            InitializeComponent();
            this.requestId = requestId;
            this.masterId = masterId;
        }

        private void AddCommentButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Comments (requestID, masterID, commentText, commentDate) VALUES (@requestID, @masterID, @commentText, @commentDate)", conn);
                cmd.Parameters.AddWithValue("@requestID", requestId);
                cmd.Parameters.AddWithValue("@masterID", masterId);
                cmd.Parameters.AddWithValue("@commentText", CommentTextBox.Text);
                cmd.Parameters.AddWithValue("@commentDate", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Комментарий добавлен");
            this.Close();
        }
    }
}