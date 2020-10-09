using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace forum_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _repo;
        private IAuthenticationHandler _authenticationHandler;
        private IJWTHandler _jWTHandler;

        public UserController(IUserRepository repo, IAuthenticationHandler authenticationHandler, IJWTHandler jWTHandler)
        {
            _repo = repo;
            _authenticationHandler = authenticationHandler;
            _jWTHandler = jWTHandler;
        }

        [HttpGet]
        [Authorize]
        [Route("details"), ActionName("userDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUserDetails()
        {
            try
            {
                string jwt = HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1];
                int id = Convert.ToInt32(_jWTHandler.GetClaim(jwt, "UserId"));
                if (id <= 0)
                {
                    return BadRequest("Request doesn't pass validation");
                }
                User user = _repo.GetById(id);
                if (user == null)
                {
                    return NotFound();
                }
                user.Password = "";
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Authorize]
        [Route("byId/{id}"), ActionName("userById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUserById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Request doesn't pass validation");
                }
                User user = _repo.GetById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("create"), ActionName("createUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateUser([FromBody] UserCreateDTO userCreate)
        {
            try
            {
                if (userCreate == null)
                {
                    return BadRequest("Empty body");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Request doesn't pass validation");
                }
                User createdUser = _authenticationHandler.CreateUser(userCreate);
                return CreatedAtAction("userDetails", new { id = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login"), ActionName("loginUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody] UserLoginDTO loginDTO)
        {
            try
            {
                return Ok(new { Token = _authenticationHandler.LoginUser(loginDTO) });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Unauthorized();
            }
        }
    }
}