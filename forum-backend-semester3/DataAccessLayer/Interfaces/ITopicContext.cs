using DataAccessLayer.DataTransferObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface ITopicContext
    {
        TopicDTO Create();
        TopicDTO GetById(int topicId);
        bool Delete(int topicId);
        bool Lock(int topicId, int userId);
        IReadOnlyList<TopicDTO> GetAll();
        IReadOnlyList<TopicDTO> GetTopicsContaining(string content);
        TopicDTO TopicDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
