using BusinessLogicLayer.Models;
using DataAccessLayer.DataTransferObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserRepository
    {
        IReadOnlyList<User> GetAll();
        User GetById(int Id);
        User Update(UserDTO user);
        User Create(UserCreateDTO userCreateDTO);
        User GetByUsername(UserLoginDTO loginDTO);
        User GetByUsername(string username);
        User UserDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
