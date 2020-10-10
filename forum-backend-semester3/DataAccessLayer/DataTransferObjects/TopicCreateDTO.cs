using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.DataTransferObjects
{
    public class TopicCreateDTO
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool Locked { get; set; }

        public TopicCreateDTO()
        {

        }

        public TopicCreateDTO(int categoryId, int creatorId,string title,string content,bool locked)
        {
            this.CategoryId = categoryId;
            this.CreatorId = creatorId;
            this.Title = title;
            this.Content = content;
            this.Locked = locked;
        }
    }
}
