using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        public IReadOnlyList<User> GetAll()
        {
            IReadOnlyList<UserDTO> UserDTOs = _context.GetAll();
            List<User> users = new List<User>();
            foreach (UserDTO UserDTO in UserDTOs)
            {
                users.Add(UserFromUserDTO(UserDTO));
            }
            return users.AsReadOnly();
        }

        public User UserFromUserDTO(UserDTO userDTO)
        {
            User userFromDTO = new User();
            userFromDTO.UserId = userDTO.UserId;
            userFromDTO.Username = userDTO.Username;
            userFromDTO.Password = userDTO.Password;
            return userFromDTO;

        }

        public User GetByUsername(string username)
        {
            var userByUsername = _context.GetByUsername(username);
            if (userByUsername == null)
            {
                return null;
            }
            return UserFromUserDTO(userByUsername);
        }

        public User GetById(int id)
        {
            return UserFromUserDTO(_context.GetById(id));
        }

        public User Update(UserDTO userUpdate)
        {
            return UserFromUserDTO(_context.Update(userUpdate));
        }

        public User UserDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            return UserFromUserDTO(_context.UserDTOFromMySqlDataReader(reader));
        }

        public User Create(UserCreateDTO userCreateDTO)
        {
            return UserFromUserDTO(_context.Create(userCreateDTO));
        }

        public User GetByUsername(UserLoginDTO loginDTO)
        {
            return UserFromUserDTO(_context.GetByUsername(loginDTO.Username));
        }


    }
}
