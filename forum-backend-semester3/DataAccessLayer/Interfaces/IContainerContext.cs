using DataAccessLayer.DataTransferObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IContainerContext
    {
        ContainerDTO Create();
        ContainerDTO GetById(int containerId);
        IReadOnlyList<ContainerDTO> GetAll();
        ContainerDTO ContainerDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
