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
    public class TopicRepository : ITopicRepository
    {
        private ITopicContext _context;

        public TopicRepository(ITopicContext context)
        {
            _context = context;
        }

        public Topic TopicFromTopicDTO(TopicDTO topicDTO)
        {
            Topic topicFromDTO = new Topic();
            topicFromDTO.TopicId = topicDTO.TopicId;
            topicFromDTO.CategoryId = topicDTO.CategoryId;
            topicFromDTO.CreatorId = topicDTO.CreatorId;
            topicFromDTO.Title = topicDTO.Title;
            topicFromDTO.Content = topicDTO.Content;
            topicFromDTO.Locked = topicDTO.Locked;
            return topicFromDTO;
        }

        public Reply ReplyFromReplyDTO(ReplyDTO replyDTO)
        {
            Reply replyFromDTO = new Reply();
            replyFromDTO.ReplyId = replyDTO.ReplyId;
            replyFromDTO.TopicId = replyDTO.TopicId;
            replyFromDTO.UserId = replyDTO.UserId;
            replyFromDTO.Content = replyDTO.Content;
            return replyFromDTO;
        }

        public Topic Create(TopicCreateDTO topicCreate)
        {
            TopicDTO topicDTO = _context.Create(topicCreate);
            return TopicFromTopicDTO(topicDTO);
        }

        public Reply CreateReply(ReplyCreateDTO replyCreate)
        {
            ReplyDTO replyDTO = _context.CreateReply(replyCreate);
            return ReplyFromReplyDTO(replyDTO);
        }

        public bool Delete(int topicId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Topic> GetAll()
        {
            IReadOnlyList<TopicDTO> topicDTOs = _context.GetAll();
            List<Topic> topics = new List<Topic>();
            foreach (TopicDTO topicDTO in topicDTOs)
            {
                topics.Add(TopicFromTopicDTO(topicDTO));
            }
            return topics.AsReadOnly();
        }

        public IReadOnlyList<Topic> GetAllByCategoryId(int categoryId)
        {
            IReadOnlyList<TopicDTO> topicDTOs = _context.GetAllByCategoryId(categoryId);
            List<Topic> topics = new List<Topic>();
            foreach (TopicDTO topicDTO in topicDTOs)
            {
                topics.Add(TopicFromTopicDTO(topicDTO));
            }
            return topics.AsReadOnly();
        }

        public Topic GetById(int topicId)
        {
            TopicDTO topicDTO = _context.GetById(topicId);
            return TopicFromTopicDTO(topicDTO);
        }

        public IReadOnlyList<Topic> GetTopicsContaining(string content)
        {
            throw new NotImplementedException();
        }

        public bool Lock(int topicId, int userId)
        {
            throw new NotImplementedException();
        }

        public Topic TopicDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            return TopicFromTopicDTO(_context.TopicDTOFromMySqlDataReader(reader));
        }
    }
}
