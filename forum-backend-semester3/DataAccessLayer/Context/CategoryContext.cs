using DataAccessLayer.DataTransferObjects;
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

        public CategoryDTO GetById(int categoryId)
        {
            throw new NotImplementedException();
        }

     
    }
}
