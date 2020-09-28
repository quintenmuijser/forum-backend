﻿using BusinessLogicLayer.Interfaces;
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



        public Topic Create()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int topicId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Topic> GetAll()
        {
            throw new NotImplementedException();
        }

        public Topic GetById(int topicId)
        {
            throw new NotImplementedException();
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