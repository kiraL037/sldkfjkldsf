using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DE_AA_Migalkina;

public class DataAccessLayer
{
    private string connectionString = "Data Source=LAPTOP-BP9G4DP1\\SQLEXPRESS;Initial Catalog=DE_DB;Integrated Security= True;";

    public List<Request> GetAllRequests()
    {
        List<Request> requests = new List<Request>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Request";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Request request = new Request();
                request.ID_Request = Convert.ToInt32(reader["ID_Request"]);
                request.Number_Request = Convert.ToInt32(reader["Number_Request"]);
                request.Date_Request = Convert.ToDateTime(reader["Date_Request"]);
                request.Equipment = reader["Equipment"].ToString();
                request.Type_Issue = reader["Type_Issue"].ToString();
                request.Description_Issue = reader["Description_Issue"].ToString();
                request.Name_Client = reader["Name_Client"].ToString();
                request.Status = reader["Status"].ToString();

                requests.Add(request);
            }
            reader.Close();
        }
        return requests;
    }

    public void AddEquipmentRequest(Request request)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Request (ID_Request, Date_Request, Equipment, Type_Issue, Description_Issue, Name_Client, Status) " +
                           "VALUES (@ID_Request, @Date_Request, @Equipment, @Type_Issue, @Description_Issue, @Name_Client, @Status)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID_Request", request.ID_Request);
            command.Parameters.AddWithValue("@Date_Request", request.Date_Request);
            command.Parameters.AddWithValue("@Equipment", request.Equipment);
            command.Parameters.AddWithValue("@Type_Issue", request.Type_Issue);
            command.Parameters.AddWithValue("@Description_Issue", request.Description_Issue);
            command.Parameters.AddWithValue("@Name_Client", request.Name_Client);
            command.Parameters.AddWithValue("@Status", request.Status);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Метод для редактирования существующей заявки на ремонт
    public void UpdateRequest(Request request)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Request SET ID_Request = @ID_Request, Date_Request = @Date_Request, " +
                           "Equipment = @Equipment, Type_Issue = @Type_Issue, Description_Issue = @Description_Issue, " +
                           "Name_Client = @Name_Client, Status = @Status WHERE ID_Request = @Original_ID_Request";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID_Request", request.ID_Request);
            command.Parameters.AddWithValue("@Date_Request", request.Date_Request);
            command.Parameters.AddWithValue("@Equipment", request.Equipment);
            command.Parameters.AddWithValue("@Type_Issue", request.Type_Issue);
            command.Parameters.AddWithValue("@Description_Issue", request.Description_Issue);
            command.Parameters.AddWithValue("@Name_Client", request.Name_Client);
            command.Parameters.AddWithValue("@Status", request.Status);
            command.Parameters.AddWithValue("@Original_ID_Request", request.ID_Request); 

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Метод для удаления заявки на ремонт
    public void DeleteEquipmentRequest(int ID_Request)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Request WHERE ID_Request = @ID_Request";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID_Request", ID_Request);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public List<Workers> GetAllWorkers()
    {
        List<Workers> workers = new List<Workers>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Workers";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Workers worker = new Workers();
                worker.ID_Worker = Convert.ToInt32(reader["ID_Worker"]);
                worker.Name_Worker = reader["Name_Worker"].ToString();
                worker.Specialty = reader["Specialty"].ToString();

                workers.Add(worker);
            }
            reader.Close();
        }
        return workers;
    }

    // Метод для добавления нового исполнителя
    public void AddWorkers(Workers workers)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Workers (Name_Worker, Specialty) VALUES (@Name_Worker, @Specialty)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name_Worker", workers.Name_Worker);
            command.Parameters.AddWithValue("@Specialty", workers.Specialty);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Метод для редактирования существующего исполнителя
    public void UpdateWorkers(Workers workers)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Workers SET Name_Worker = @Name_Worker, Specialty = @Specialty WHERE ID_Worker = @ID_Worker";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name_Worker", workers.Name_Worker);
            command.Parameters.AddWithValue("@Specialty", workers.Specialty);
            command.Parameters.AddWithValue("@ID_Worker", workers.ID_Worker);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Метод для удаления исполнителя
    public void DeleteWorkers(int ID_Worker)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Workers WHERE ID_Worker = @ID_Worker";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID_Worker", ID_Worker);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public List<Managers> GetAllManagers()
    {
        List<Managers> managers = new List<Managers>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Managers";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Managers manager = new Managers();
                manager.ID_Manager = Convert.ToInt32(reader["ID_Manager"]);
                manager.Name_Manager = reader["Name_Managers"].ToString();
         
                managers.Add(manager);
            }
            reader.Close();
        }
        return managers;
    }
    // Метод для добавления нового менеджера
    public void AddManager(Managers managers)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Managers (Name_Managers) VALUES (@Name_Managers)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name_Managers", managers.Name_Manager);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Метод для редактирования существующего менеджера
    public void UpdateManager(Managers managers)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Managers SET Name_Managers = @Name_Managers WHERE ID_Manager = @ID_Manager";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name_Managers", managers.Name_Manager);
            command.Parameters.AddWithValue("@ID_Manager", managers.ID_Manager);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Метод для удаления менеджера
    public void DeleteManager(int ID_Manager)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Managers WHERE ID_Manager = @ID_Manager";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID_Manager", ID_Manager);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Метод для назначения исполнителя заявке на ремонт
    public void AssignExecutorToRequest(int ID_Request, int ID_Worker)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Request SET ID_Worker = @ID_Worker WHERE ID_Request = @ID_Request";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID_Worker", ID_Worker);
            command.Parameters.AddWithValue("@ID_Request", ID_Request);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Метод для продления срока выполнения заявки менеджером
    public void ExtendRequestDeadline(int ID_Request, DateTime newDeadline)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Request SET Deadline = @NewDeadline WHERE ID_Request = @ID_Request";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NewDeadline", newDeadline);
            command.Parameters.AddWithValue("@ID_Request", ID_Request);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    public int GetMaxRequestId()
    {
        int maxId = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT MAX(ID_Request) FROM Request";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            object result = command.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                maxId = Convert.ToInt32(result);
            }
        }

        return maxId;
    }
}

