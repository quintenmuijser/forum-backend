using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DataTransferObjects
{
    public class ReplyDTO
    {
        public int ReplyId { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public string Content { get; set; }

        public ReplyDTO()
        {

        }

        public ReplyDTO(int replyId,int userId, int topicId,string content)
        {
            this.ReplyId = replyId;
            this.UserId = userId;
            this.TopicId = topicId;
            this.Content = content;
        }
    }
}
