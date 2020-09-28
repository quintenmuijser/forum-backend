using BusinessLogicLayer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface ISectionRepository
    {
        Section Create();
        Section GetById(int sectionId);
        IReadOnlyList<Section> GetAll();

        Section SectionDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
