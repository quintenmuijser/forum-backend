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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
