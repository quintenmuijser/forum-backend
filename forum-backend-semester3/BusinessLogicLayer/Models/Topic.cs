using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public int CategoryId { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Locked { get; set; }
    }
}
