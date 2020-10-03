using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Context
{
    public class UserContext : IUserContext
    {
        private readonly IDatabase _DB;
        public UserContext(IDatabase DB)
        {
            _DB = DB;
        }

        public IReadOnlyList<UserDTO> GetAll()
        {
            MySqlConnection _conn = _DB.GetConnection();
            List<UserDTO> users = new List<UserDTO>();
            using (MySqlConnection connection = _conn)
            {
                string query = "SELECT * FROM user ORDER BY user_id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserDTO user = UserDTOFromMySqlDataReader(reader);
                            users.Add(user);
                        }
                    }
                }
            }
            return users.AsReadOnly();
        }

        public UserDTO GetById(int Id)
        {
            MySqlConnection _conn = _DB.GetConnection();
            UserDTO user;
            using (MySqlConnection connection = _conn)
            {
                string query = "SELECT * FROM user WHERE user_id = @Id";
                MySqlTransaction transaction = connection.BeginTransaction();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@Id", Id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = UserDTOFromMySqlDataReader(reader);
                        }
                        else
                        {
                            user = null;
                        }
                    }
                }
            }
            return user;
        }

        public UserDTO GetByUsername(string username)
        {
            MySqlConnection _conn = _DB.GetConnection();
            UserDTO user;
            using (MySqlConnection connection = _conn)
            {
                string query = "SELECT * FROM user WHERE username = @Username";
                MySqlTransaction transaction = connection.BeginTransaction();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@Username", username);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = UserDTOFromMySqlDataReader(reader);
                        }
                        else
                        {
                            user = null;
                        }
                    }
                }
            }
            return user;
        }

        public UserDTO Update(UserDTO user)
        {
            MySqlConnection _conn = _DB.GetConnection();
            UserDTO updatedUser;

            using (MySqlConnection connection = _conn)
            {
                MySqlTransaction transaction = connection.BeginTransaction();
                string query = "UPDATE user SET user_id = @Id, username = @Username, password = @Password " +
                    "WHERE Id = @Id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@Id", user.UserId);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                query = "SELECT * FROM user WHERE user_id = @Id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@Id", user.UserId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            updatedUser = UserDTOFromMySqlDataReader(reader);
                        }
                        else
                        {
                            updatedUser = null;
                        }
                    }
                }
                try
                {
                    transaction.Commit();
                }
                catch (MySqlException e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine(e.Message);
                }
            }
            return updatedUser;
        }

        public UserDTO Create(UserCreateDTO userCreate)
        {
            MySqlConnection _conn = _DB.GetConnection();
            int id;
            MySqlConnection connection = _conn;
            {
                string query = "INSERT INTO user (username, password)" +
                    "VALUES (@Username, @Password)";
                MySqlTransaction transaction = connection.BeginTransaction();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@Username", userCreate.Username);
                    command.Parameters.AddWithValue("@Password", userCreate.PasswordRaw);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine(e.Message);
                        throw e;
                    }
                }
                query = "SELECT user_id FROM user ORDER BY user_id DESC LIMIT 1";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["user_id"]);
                        }
                        else
                        {
                            id = 0;
                        }
                    }
                }
                try
                {
                    transaction.Commit();
                }
                catch (MySqlException e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine(e.Message);
                }
            }
            UserDTO createdUser = new UserDTO(id, userCreate.Username, userCreate.PasswordRaw);

            return createdUser;
        }

        public UserDTO UserDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            UserDTO user = new UserDTO(
                Convert.ToInt32(reader["user_id"]),
                Convert.ToString(reader["username"]),
                Convert.ToString(reader["password"])
            );
            return user;
        }
    }
}
