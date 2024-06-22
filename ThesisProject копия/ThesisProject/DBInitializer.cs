using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ThesisProject
{
    public static class DBInitializer
    {
        //public static void Initialize()
        //{
        //    string connectionString = GetConnectionString();
        //    if (string.IsNullOrEmpty(connectionString))
        //    {
        //        OpenDatabaseConnectionWindow(); // Открываем окно для ввода параметров подключения к базе данных.
        //        return;
        //    }

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            if (!DatabaseExists(connection))
        //            {
        //                CreateDatabase(connection); // Создаем базу данных, если ее нет.
        //            }

        //            if (!UserTableExists(connection))
        //            {
        //                CreateUserTable(connection); // Создаем таблицу пользователей, если ее нет.
        //            }

        //            if (!AdminUserExists(connection))
        //            {
        //                OpenAdminCreationWindow(connection); // Открываем окно для создания администратора, если его нет.
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error initializing database: {ex.Message}");
        //        }
        //    }
        //}
        
        public static void CreateAdminUser(string connectionString, string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkAdminQuery = "USE DB_THESIS; SELECT COUNT(*) FROM Users WHERE IsAdmin>0";

                using(SqlCommand command=new SqlCommand(checkAdminQuery, connection))
                {
                    int adminCount = (int)command.ExecuteScalar();

                    if (adminCount > 0)
                        return;
                }

                string salt = GenerateSalt();
                string hashPassword = HashPassword(password, salt);
                string insertAdminQuery = @"
                    USE DB_THESIS; 
                    INSERT INTO Users (Username, PasswordHash, Salt, IsAdmin) 
                    VALUES (@username, @passwordHash, @salt, 1)";

                using (SqlCommand command = new SqlCommand(insertAdminQuery, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@passwordHash", hashPassword);
                    command.Parameters.AddWithValue("@salt", salt);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private static string GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider()) 
            {
                byte[] saltBytes = new byte[32];
                rng.GetBytes(saltBytes);
                return Convert.ToBase64String(saltBytes);
            }
        }
    }
}
