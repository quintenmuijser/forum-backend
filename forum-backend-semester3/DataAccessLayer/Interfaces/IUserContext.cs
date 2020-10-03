using DataAccessLayer.DataTransferObjects;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IUserContext
    {
        IReadOnlyList<UserDTO> GetAll();
        UserDTO Create(UserCreateDTO userCreateDTO);
        UserDTO GetById(int Id);
        UserDTO GetByUsername(string username);
        UserDTO Update(UserDTO user);
        UserDTO UserDTOFromMySqlDataReader(MySqlDataReader reader);
    }
}
