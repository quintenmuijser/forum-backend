﻿using BusinessLogicLayer.Models;
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

        IReadOnlyList<Category> GetCategoriesFromSection(int sectionId);

        Section SectionDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
