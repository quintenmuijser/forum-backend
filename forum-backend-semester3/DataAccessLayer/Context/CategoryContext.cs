﻿using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Context
{
    public class CategoryContext : ICategoryContext
    {
        private readonly IDatabase _DB;

        public CategoryContext(IDatabase DB)
        {
            _DB = DB;
        }

        public CategoryDTO CategoryDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            CategoryDTO category = new CategoryDTO(
            Convert.ToInt32(reader["category_id"]),
            Convert.ToInt32(reader["section_id"]),
            Convert.ToInt32(reader["priority"]),
            Convert.ToString(reader["title"]));
            return category;
        }

        public CategoryDTO Create()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<CategoryDTO> GetAll()
        {
            MySqlConnection _conn = _DB.GetConnection();
            List<CategoryDTO> categories = new List<CategoryDTO>();
            using (MySqlConnection connection = _conn)
            {
                string query = "SELECT * FROM category ORDER BY priority";
                using (MySqlCommand sql_command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = sql_command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CategoryDTO category = CategoryDTOFromMySqlDataReader(reader);
                            categories.Add(category);
                        }
                    }
                }
            }
            return categories.AsReadOnly();
        }

        public IReadOnlyList<CategoryDTO> GetAllBySectionId(int sectionId)
        {
            MySqlConnection _conn = _DB.GetConnection();
            List<CategoryDTO> categories = new List<CategoryDTO>();
            using (MySqlConnection connection = _conn)
            {
                //find out how to do prepared statement here
                string query = "SELECT * FROM category where section_id = @sectionId ORDER BY category_id";
                MySqlTransaction transaction = connection.BeginTransaction();

                using (MySqlCommand sql_command = new MySqlCommand(query, connection))
                {
                    sql_command.Transaction = transaction;
                    sql_command.Parameters.AddWithValue("@sectionId", sectionId);
                    using (MySqlDataReader reader = sql_command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CategoryDTO category = CategoryDTOFromMySqlDataReader(reader);
                            categories.Add(category);
                        }
                    }
                }
            }
            return categories.AsReadOnly();
        }

        public CategoryDTO GetById(int categoryId)
        {
            MySqlConnection _conn = _DB.GetConnection();
            CategoryDTO category;
            using (MySqlConnection connection = _conn)
            {
                string query = "SELECT * FROM category WHERE category_id = @CategoryId";
                MySqlTransaction transaction = connection.BeginTransaction();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category = CategoryDTOFromMySqlDataReader(reader);
                        }
                        else
                        {
                            category = null;
                        }
                    }
                }
            }
            return category;
        }

     
    }
}
