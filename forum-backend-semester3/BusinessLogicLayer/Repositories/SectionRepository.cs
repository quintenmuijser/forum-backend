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
    public class SectionRepository : ISectionRepository
    {
        private ISectionContext _context;

        public SectionRepository(ISectionContext context)
        {
            _context = context;
        }

        public Section Create()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Section> GetAll()
        {
            throw new NotImplementedException();
        }

        public Section GetById(int sectionId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Category> GetCategoriesFromSection(int sectionId)
        {
            throw new NotImplementedException();
        }

        public Section SectionDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
