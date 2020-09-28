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
        IReadOnlyList<Container> GetAll();

        IReadOnlyList<Section> GetContainersSections(int containerId);

        //should later on create a object which acts as a container thats filled with info here
        IReadOnlyList<Container> GetContainersSectionsAndCategories(int containerId);


        Topic GetMostRecentTopicCreated(int containerId);

        Container ContainerDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
