using BusinessLogicLayer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IContainerRepository
    {
        Container Create();
        Container GetById(int containerId);
        IReadOnlyList<Topic> GetAll();


        //container categories model needed
        IReadOnlyList<Topic> GetContainersCategories(int id);


        Container ContainerDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
