using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DataTransferObjects
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserDTO()
        {

        }

        public UserDTO(int userId,string username,string password)
        {
            this.UserId = userId;
            this.Username = username;
            this.Password = password;
        }
    }
}
