using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private ISectionContext _context;

        public SectionRepository(ISectionContext context)
        {
            _context = context;
        }

        public Section SectionFromSectionDTO(SectionDTO sectionDTO)
        {
            Section sectionFromDTO = new Section();
            sectionFromDTO.SectionId = sectionDTO.SectionId;
            sectionFromDTO.ContainerId = sectionDTO.ContainerId;
            sectionFromDTO.Priority = sectionDTO.Priority;
            sectionFromDTO.Title = sectionDTO.Title;
            return sectionFromDTO;
        }

        public Section Create()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Section> GetAll()
        {
            IReadOnlyList<SectionDTO> sectionDTOs = _context.GetAll();
            List<Section> sections = new List<Section>();
            foreach (SectionDTO sectionDTO in sectionDTOs)
            {
                sections.Add(SectionFromSectionDTO(sectionDTO));
            }
            return sections.AsReadOnly();
        }

        public Section GetById(int sectionId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Category> GetCategoriesFromSection(int sectionId)
        {
            throw new NotImplementedException();
        }

        public Section SectionDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
