using DataAccessLayer.DataTransferObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface ITopicContext
    {
        TopicDTO Create(TopicCreateDTO topicCreate);
        ReplyDTO CreateReply(ReplyCreateDTO replyCreate);
        TopicDTO GetById(int topicId);
        bool Delete(int topicId);
        bool Lock(int topicId, int userId);
        IReadOnlyList<TopicDTO> GetAll();
        IReadOnlyList<TopicDTO> GetAllByCategoryId(int categoryId);
        IReadOnlyList<TopicDTO> GetTopicsContaining(string content);
        TopicDTO TopicDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
