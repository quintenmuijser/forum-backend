using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public int ContainerId { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
    }
}
