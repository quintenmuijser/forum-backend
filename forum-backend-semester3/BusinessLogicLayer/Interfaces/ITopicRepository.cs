using BusinessLogicLayer.Models;
using DataAccessLayer.DataTransferObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{

    public interface ITopicRepository
    {
        //later this needs the topicCreateDTO as varible in it
        Reply CreateReply(ReplyCreateDTO replyCreate);
        Topic Create(TopicCreateDTO topicCreate);
        Topic GetById(int topicId);
        bool Delete(int topicId);
        bool Lock(int topicId, int userId);
        IReadOnlyList<Topic> GetAll();
        IReadOnlyList<Topic> GetAllByCategoryId(int categoryId);
        IReadOnlyList<Topic> GetTopicsContaining(string content);
        Topic TopicDTOFromMySqlDataReader(MySqlDataReader reader);
    }
   
}
