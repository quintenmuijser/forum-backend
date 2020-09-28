using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
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
