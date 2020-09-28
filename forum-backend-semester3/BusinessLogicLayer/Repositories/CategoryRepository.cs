using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ICategoryContext _context;

        public CategoryRepository(ICategoryContext context)
        {
            _context = context;
        }

        public Category CategoryDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Category Create()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Category> GetCategoryTopics(int containerId)
        {
            throw new NotImplementedException();
        }

        public Topic GetMostRecentTopicCreated(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
