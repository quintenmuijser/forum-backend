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

        IReadOnlyList<SectionDTO> GetContainersSections(int containerId);

        //should later on create a object which acts as a container thats filled with info here
        IReadOnlyList<ContainerDTO> GetContainersSectionsAndCategories(int containerId);


        TopicDTO GetMostRecentTopicCreated(int containerId);

        ContainerDTO ContainerDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
