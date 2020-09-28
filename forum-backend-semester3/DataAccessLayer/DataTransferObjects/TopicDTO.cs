using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DataTransferObjects
{
    public class TopicDTO
    {
        public int TopicId { get; set; }
        public int CategoryId { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Locked { get; set; }

        public TopicDTO()
        {

        }

        public TopicDTO(int topicId,int categoryId, int creatorId,string title,string content,bool locked)
        {
            this.TopicId = topicId;
            this.CategoryId = categoryId;
            this.CreatorId = creatorId;
            this.Title = title;
            this.Content = content;
            this.Locked = locked;
        }
    }
}
