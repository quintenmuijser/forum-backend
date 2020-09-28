using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DataTransferObjects
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public int SectionId { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }

        public CategoryDTO()
        {

        }

        public CategoryDTO(int categoryId, int sectionId, int priority, string title)
        {
            this.CategoryId = categoryId;
            this.SectionId = sectionId;
            this.Priority = priority;
            this.Title = title;
        }
    }
  
}
