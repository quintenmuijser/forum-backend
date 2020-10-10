using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Models
{
    public class Reply
    {
        public int ReplyId { get; set; }        
        public int TopicId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
