using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisProject
{
    public static class DBReader
    {
        public static async Task<ObservableCollection<DynamicDataModel>> 
            LoadDataAsync(string connectionString, string tableName)
        {
            var data = new ObservableCollection<DynamicDataModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM {tableName}";
                
                SqlCommand command = new SqlCommand(query, connection);
                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var model = new DynamicDataModel();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            model.Data[reader.GetName(i)] = reader.GetValue(i);
                        }
                        data.Add(model);
                    }
                }
            }
            return data;
        }

        public static async Task InsertDataAsync(string connectionString,
            string tableName, DynamicDataModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var columns = string.Join(",", model.Data.Keys);
                var values = string.Join(",", model.Data.Values);

                string query = $"INSERT INTO {tableName} ({columns}) VALUE ({values})";
                
                SqlCommand command = new SqlCommand(query, connection);
                await command.ExecuteNonQueryAsync();

            }
        }

        public static async Task UpdateDataAsync(string connectionString,
            string tableName, DynamicDataModel model, string pKColumn, object pKValue)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var setValue = string.Join(",", model.Data.Select(kvp => $"{kvp.Key}='{kvp.Value}'"));
                
                string query = $"UPDATE {tableName} SET {setValue} WHERE {pKColumn}='{pKValue}'";
                
                SqlCommand command = new SqlCommand(query, connection);
                await command.ExecuteNonQueryAsync();
            }
        }

        public static async Task DeleteDataAsync(string connectionString,
            string tableName, string pKColumn, object pKValue)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = $"DELETE FROM {tableName} WHERE {pKColumn} ='{pKValue}'";
                
                SqlCommand command = new SqlCommand(query, connection);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
