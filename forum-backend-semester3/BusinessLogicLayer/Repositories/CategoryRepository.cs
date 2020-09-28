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
    public class CategoryRepository : ICategoryRepository
    {
        private ICategoryContext _context;

        public CategoryRepository(ICategoryContext context)
        {
            _context = context;
        }


        public Category CategoryFromCategoryDTO(CategoryDTO categoryDTO)
        {
            Category categoryFromDTO = new Category();
            categoryFromDTO.CategoryId = categoryDTO.CategoryId;
            categoryFromDTO.SectionId = categoryDTO.SectionId;
            categoryFromDTO.Priority = categoryDTO.Priority;
            categoryFromDTO.Title = categoryDTO.Title;
            return categoryFromDTO;
        }

        public Category CategoryDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Category Create()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Category> GetAll()
        {
            IReadOnlyList<CategoryDTO> categoryDTOs = _context.GetAll();
            List<Category> categories = new List<Category>();
            foreach (CategoryDTO categoryDTO in categoryDTOs)
            {
                categories.Add(CategoryFromCategoryDTO(categoryDTO));
            }
            return categories.AsReadOnly();
        }

        public Category GetById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Category> GetCategoryTopics(int containerId)
        {
            throw new NotImplementedException();
        }

        public Topic GetMostRecentTopicCreated(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
