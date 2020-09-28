using DataAccessLayer.DataTransferObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface ICategoryContext
    {
        CategoryDTO Create();
        CategoryDTO GetById(int categoryId);
        IReadOnlyList<CategoryDTO> GetAll();
        IReadOnlyList<CategoryDTO> GetAllBySectionId(int sectionId);
        CategoryDTO CategoryDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
