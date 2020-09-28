using DataAccessLayer.Interfaces;
using DataAccessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccessLayer.Context
{
    public class TopicContext : ITopicContext
    {
        private readonly IDatabase _DB;

        public TopicContext(IDatabase DB)
        {
            _DB = DB;
        }

        public TopicDTO Create()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int topicId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<TopicDTO> GetAll()
        {
            MySqlConnection _conn = _DB.GetConnection();
            List<TopicDTO> topics = new List<TopicDTO>();
            using (MySqlConnection connection = _conn)
            {
                string query = "SELECT * FROM topic ORDER BY topic_id";
                using (MySqlCommand sql_command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = sql_command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TopicDTO topic = TopicDTOFromMySqlDataReader(reader);
                            topics.Add(topic);
                        }
                    }
                }
            }
            return topics.AsReadOnly();
        }

        public TopicDTO GetById(int topicId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<TopicDTO> GetTopicsContaining(string content)
        {
            throw new NotImplementedException();
        }

        public bool Lock(int topicId, int userId)
        {
            throw new NotImplementedException();
        }

        public TopicDTO TopicDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            TopicDTO topic = new TopicDTO(
            Convert.ToInt32(reader["topic_id"]),
            Convert.ToInt32(reader["category_id"]),
            Convert.ToInt32(reader["creator_id"]),
            Convert.ToString(reader["title"]),
            Convert.ToString(reader["content"]),
            Convert.ToBoolean(reader["locked"]));
            return topic;
        }
    }
}
