using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Context
{
    public class SectionContext : ISectionContext
    {
        private readonly IDatabase _DB;

        public SectionContext(IDatabase DB)
        {
            _DB = DB;
        }

        public SectionDTO Create()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<SectionDTO> GetAll()
        {
            MySqlConnection _conn = _DB.GetConnection();
            List<SectionDTO> sections = new List<SectionDTO>();
            using (MySqlConnection connection = _conn)
            {
                string query = "SELECT * FROM section ORDER BY priority";
                using (MySqlCommand sql_command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = sql_command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SectionDTO section = SectionDTOFromMySqlDataReader(reader);
                            sections.Add(section);
                        }
                    }
                }
            }
            return sections.AsReadOnly();
        }

        public SectionDTO GetById(int sectionId)
        {
            throw new NotImplementedException();
        }

      
        public SectionDTO SectionDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            SectionDTO section = new SectionDTO(
            Convert.ToInt32(reader["section_id"]),
            Convert.ToInt32(reader["container_id"]),
            Convert.ToInt32(reader["priority"]),
            Convert.ToString(reader["title"]));
            return section;
        }
    }
}
