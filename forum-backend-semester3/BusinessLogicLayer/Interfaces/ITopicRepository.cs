using BusinessLogicLayer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{

    public interface ITopicRepository
    {
        //later this needs the topicCreateDTO as varible in it
        Topic Create();
        Topic GetById(int topicId);
        bool Delete(int topicId);
        bool Lock(int topicId, int userId);
        IReadOnlyList<Topic> GetAll();
        IReadOnlyList<Topic> GetTopicsContaining(string content);
        Topic TopicDTOFromMySqlDataReader(MySqlDataReader reader);
    }
   
}
