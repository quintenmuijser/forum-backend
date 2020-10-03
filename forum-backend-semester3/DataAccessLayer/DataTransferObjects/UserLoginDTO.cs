using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.DataTransferObjects
{
    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordRaw { get; set; }
        [Required]
        public string RememberMe { get; set; }
    }
}
