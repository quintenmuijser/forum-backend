using DataAccessLayer.DataTransferObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface ISectionContext
    {
        SectionDTO Create();
        SectionDTO GetById(int sectionId);
        IReadOnlyList<SectionDTO> GetAll();
        IReadOnlyList<SectionDTO> GetAllByContainerId(int containerId);
        SectionDTO SectionDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
