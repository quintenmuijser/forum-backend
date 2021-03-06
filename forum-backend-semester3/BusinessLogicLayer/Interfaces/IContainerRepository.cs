﻿using BusinessLogicLayer.Models;
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

        //should later on create a object which acts as a container thats filled with info here

        Container ContainerDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
