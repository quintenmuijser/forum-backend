using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DataTransferObjects
{
    public class ReplyCreateDTO
    {
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public string Content { get; set; }

        public ReplyCreateDTO()
        {

        }

        public ReplyCreateDTO(int userId, int topicId,string content)
        {
            this.UserId = userId;
            this.TopicId = topicId;
            this.Content = content;
        }
    }
}
