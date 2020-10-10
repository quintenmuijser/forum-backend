using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace forum_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private ITopicRepository _repo;

        public TopicController(ITopicRepository repo)
        {
            _repo = repo;
        }


        [Route("all"), ActionName("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                IReadOnlyList<Topic> topics = _repo.GetAll();
                if (topics.Count != 0)
                {
                    return Ok(topics);
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetById/{id}"), ActionName("GetTopic")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Request doesn't pass validation");
                }
                Topic topic = _repo.GetById(id);
                if (topic == null)
                {
                    return NotFound();
                }
                return Ok(topic);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("create"), ActionName("CreateTopic")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateTopic([FromBody] TopicCreateDTO topicCreate)
        {
            try
            {
                if (topicCreate == null)
                {
                    return BadRequest("Empty body");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Request doesn't pass validation");
                }
                Topic createdTopic = _repo.Create(topicCreate);
                return CreatedAtAction("CreateTopic", new { id = createdTopic.TopicId }, createdTopic);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("createReply"), ActionName("CreateReply")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateReply([FromBody] ReplyCreateDTO replyCreate)
        {
            try
            {
                if (replyCreate == null)
                {
                    return BadRequest("Empty body");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Request doesn't pass validation");
                }
                Reply createdReply = _repo.CreateReply(replyCreate);
                return CreatedAtAction("CreateTopic", new { id = createdReply.ReplyId }, createdReply);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet]
        [Route("allByCategory/{id}"), ActionName("GetAllByCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllByCategory(int id)
        {
            try
            {
                IReadOnlyList<Topic> topics = _repo.GetAllByCategoryId(id);
                if (topics.Count != 0)
                {
                    return Ok(topics);
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
