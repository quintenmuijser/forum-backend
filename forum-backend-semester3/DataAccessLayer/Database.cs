using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class Database : IDatabase
    {
        private readonly string connectionString = "server=localhost;user=root;database=forum;port=3308;password=";
        public MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}
