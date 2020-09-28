using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Context
{
    public class ContainerContext : IContainerContext
    {
        private readonly IDatabase _DB;

        public ContainerContext(IDatabase DB)
        {
            _DB = DB;
        }

        public ContainerDTO ContainerDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            ContainerDTO container = new ContainerDTO(
               Convert.ToInt32(reader["container_id"]),
               Convert.ToInt32(reader["priority"]),
               Convert.ToString(reader["title"])
           );
            return container;
        }

        public ContainerDTO Create()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<ContainerDTO> GetAll()
        {
            MySqlConnection _conn = _DB.GetConnection();
            List<ContainerDTO> containers = new List<ContainerDTO>();
            using (MySqlConnection connection = _conn)
            {
                string query = "SELECT * FROM container ORDER BY priority";
                using (MySqlCommand sql_command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = sql_command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ContainerDTO container = ContainerDTOFromMySqlDataReader(reader);
                            containers.Add(container);
                        }
                    }
                }
            }
            return containers.AsReadOnly();
        }

        public ContainerDTO GetById(int containerId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<SectionDTO> GetContainersSections(int containerId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<ContainerDTO> GetContainersSectionsAndCategories(int containerId)
        {
            throw new NotImplementedException();
        }

        public TopicDTO GetMostRecentTopicCreated(int containerId)
        {
            throw new NotImplementedException();
        }
    }
}
