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
            throw new NotImplementedException();
        }

        public CategoryDTO Create()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<CategoryDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryDTO GetById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<CategoryDTO> GetCategoryTopics(int containerId)
        {
            throw new NotImplementedException();
        }

        public TopicDTO GetMostRecentTopicCreated(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
