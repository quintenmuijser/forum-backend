using BusinessLogicLayer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICategoryRepository
    {
        Category Create();
        Category GetById(int categoryId);
        IReadOnlyList<Category> GetAll();
        Category CategoryDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
