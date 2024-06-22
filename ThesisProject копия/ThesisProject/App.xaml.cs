using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ThesisProject
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string connectionString = "your_initial_connection_string";

            //DBInitializer.Initialize(connectionString);

            bool adminExists = CheckAdminExists(connectionString);
            if (!adminExists)
            {
                var setupWindow = new FirstSetupWindow();
                if (setupWindow.ShowDialog() == true)
                {
                    ShowAuthWindow();
                }
                else
                {
                    Shutdown();
                }
            }
            else
            {
                ShowAuthWindow();
            }
        }

        private bool CheckAdminExists(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "USE YourDatabaseName; SELECT COUNT(*) FROM Users WHERE IsAdmin = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int adminCount = (int)command.ExecuteScalar();
                    return adminCount > 0;
                }
            }
        }

        private void ShowAuthWindow()
        {
            var authWindow = new AuthentificationWindow();
            if (authWindow.ShowDialog() == true)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                Shutdown();
            }
        }
    }
}
