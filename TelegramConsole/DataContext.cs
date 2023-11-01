using System.Data.SqlClient;
using System.Security.AccessControl;

namespace TelegramConsole
{
    public class DataContext
    {
        public static string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=AdoNET;Trusted_Connection=True;";

        public static void CreateUser(string userName, string firstName, string lastName)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                string query = $"insert into UserTable(userName,firstName,lastName) values ('{userName}', '{firstName}', '{lastName}')";

                SqlCommand command = new SqlCommand(query, connection);

                using(SqlDataReader reader = command.ExecuteReader()) { }
            }
        }

        public static void GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                string query = "select * from UserTable";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Console.WriteLine($"{reader["userName"]} {reader["firstName"]} {reader["lastName"]}");
                    }
                }
            }
        }

        public static void SendMessage(string text,string userName)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                string query = $"Insert into Messages(Message) values ('{userName}: {text}')";

                SqlCommand command = new SqlCommand(query, connection);

                using(SqlDataReader reader = command.ExecuteReader()) { }
            }
        }

        public static void GetAllMessages()
        {
            using(SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                string query = "select * from Messages";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Message"]}");
                    }
                }
            }
        }

        public static bool CheackUserName(string userName)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                string query = $"select * from userTable where userName = '{userName}'";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["userName"] != null)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
        }
    }
}