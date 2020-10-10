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

        public TopicDTO Create(TopicCreateDTO topicCreate)
        {
            MySqlConnection _conn = _DB.GetConnection();
            int id;
            MySqlConnection connection = _conn;
            {
                string query = "INSERT INTO topic " +
                    "(category_id, creator_id, title, content, locked)" +
                    "VALUES (@CategoryId, @CreatorId, @Title, @Content, @Locked)";
                MySqlTransaction transaction = connection.BeginTransaction();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@CategoryId", topicCreate.CategoryId);
                    command.Parameters.AddWithValue("@CreatorId", topicCreate.CreatorId);
                    command.Parameters.AddWithValue("@Title", topicCreate.Title);
                    command.Parameters.AddWithValue("@Content", topicCreate.Content);
                    command.Parameters.AddWithValue("@Locked", topicCreate.Locked);
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
                query = "SELECT topic_id FROM topic ORDER BY topic_id DESC LIMIT 1";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["topic_id"]);
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
            TopicDTO createdTopic = new TopicDTO(id, topicCreate.CategoryId, topicCreate.CreatorId, topicCreate.Title, topicCreate.Content, topicCreate.Locked);

            return createdTopic;
        }

        public ReplyDTO CreateReply(ReplyCreateDTO replyCreate)
        {
            MySqlConnection _conn = _DB.GetConnection();
            int id;
            MySqlConnection connection = _conn;
            {
                string query = "INSERT INTO reply " +
                    "(user_id, topic_id, content)" +
                    "VALUES (@UserId, @TopicId, @Content)";
                MySqlTransaction transaction = connection.BeginTransaction();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@UserId", replyCreate.UserId);
                    command.Parameters.AddWithValue("@TopicId", replyCreate.TopicId);
                    command.Parameters.AddWithValue("@Content", replyCreate.Content);
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
                query = "SELECT reply_id FROM reply ORDER BY reply_id DESC LIMIT 1";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["reply_id"]);
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
            ReplyDTO createdReply = new ReplyDTO(id, replyCreate.UserId, replyCreate.TopicId, replyCreate.Content);

            return createdReply;
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

        public IReadOnlyList<TopicDTO> GetAllByCategoryId(int categoryId)
        {
            MySqlConnection _conn = _DB.GetConnection();
            List<TopicDTO> topics = new List<TopicDTO>();
            using (MySqlConnection connection = _conn)
            {
                //find out how to do prepared statement here
                string query = "SELECT * FROM topic where category_id = @categoryId ORDER BY topic_id";
                MySqlTransaction transaction = connection.BeginTransaction();

                using (MySqlCommand sql_command = new MySqlCommand(query, connection))
                {
                    sql_command.Transaction = transaction;
                    sql_command.Parameters.AddWithValue("@categoryId", categoryId);
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
            MySqlConnection _conn = _DB.GetConnection();
            TopicDTO topic;
            using (MySqlConnection connection = _conn)
            {
                string query = "SELECT * FROM topic WHERE topic_id = @TopicId";
                MySqlTransaction transaction = connection.BeginTransaction();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@TopicId", topicId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            topic = TopicDTOFromMySqlDataReader(reader);
                        }
                        else
                        {
                            topic = null;
                        }
                    }
                }
            }
            return topic;
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

        public ReplyDTO ReplyDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            ReplyDTO reply = new ReplyDTO(
            Convert.ToInt32(reader["reply_id"]),
            Convert.ToInt32(reader["user_id"]),
            Convert.ToInt32(reader["topic_id"]),
            Convert.ToString(reader["content"]));
            return reply;
        }
    }
}
