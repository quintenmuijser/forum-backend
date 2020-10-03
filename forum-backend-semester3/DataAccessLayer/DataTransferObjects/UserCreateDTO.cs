using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.DataTransferObjects
{
    public class UserCreateDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordRaw { get; set; }

        public UserCreateDTO()
        {

        }

        public UserCreateDTO(string username, string passwordRaw)
        {
            Username = username;
            PasswordRaw = passwordRaw;
        }
    }
}
