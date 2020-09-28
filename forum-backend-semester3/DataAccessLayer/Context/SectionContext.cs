using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Context
{
    public class SectionContext : ISectionContext
    {
        private readonly IDatabase _DB;

        public SectionContext(IDatabase DB)
        {
            _DB = DB;
        }

        public SectionDTO Create()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<SectionDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public SectionDTO GetById(int sectionId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<CategoryDTO> GetCategoriesFromSection(int sectionId)
        {
            throw new NotImplementedException();
        }

        public SectionDTO SectionDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
