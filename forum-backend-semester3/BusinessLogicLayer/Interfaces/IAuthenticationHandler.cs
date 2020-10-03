using BusinessLogicLayer.Models;
using DataAccessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAuthenticationHandler
    {
        User CreateUser(UserCreateDTO createDTO);
        string LoginUser(UserLoginDTO loginDTO);
    }
}
