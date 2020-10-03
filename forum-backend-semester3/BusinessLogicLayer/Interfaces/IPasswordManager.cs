using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPasswordManager
    {
        bool ComparePassword(User userToVerify, string rawPassword);
        string HashPassword(string rawPassword);
    }
}
