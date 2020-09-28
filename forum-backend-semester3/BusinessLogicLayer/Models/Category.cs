using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int SectionId { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
    }
}
