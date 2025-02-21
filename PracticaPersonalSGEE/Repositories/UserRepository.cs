using PracticaPersonalSGEE.DTOs;
using PracticaPersonalSGEE.Models;
using System.Data;

namespace PracticaPersonalSGEE.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public Task<Users> UserLogin(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Users> UserRegister(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
