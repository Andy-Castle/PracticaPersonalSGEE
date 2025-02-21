using Dapper;
using PracticaPersonalSGEE.DTOs;
using PracticaPersonalSGEE.Helpers;
using PracticaPersonalSGEE.Models;
using System.Data;

namespace PracticaPersonalSGEE.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IDbConnection _connection;
        private readonly PasswordHelper _passwordHelper;

        public UserRepository(IDbConnection connection, PasswordHelper passwordHelper)
        {
            _connection = connection;

            _passwordHelper = passwordHelper;
          
        }

        public async Task<bool> EmailExists(string email)
        {
            var query = "SELECT COUNT(1) FROM Users WHERE Email = @Email";

            int count = await _connection.ExecuteScalarAsync<int>(query, new {Email = email});

            return count > 0;
        }

        public async Task<Users> UserLogin(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<Users> UserRegister(UserDTO userDTO)
        {
            string hashedPassword = _passwordHelper.HashPassword(userDTO.PasswordHash);

            var query = @"INSERT INTO Users(Name, Email, PasswordHash, Role) values (@Name, @Email, @PasswordHash, @Role); SELECT * FROM Users Where Id = SCOPE_IDENTITY();";

            var user = new
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                PasswordHash = hashedPassword,
                Role = userDTO.Role,

            };

            return await _connection.QuerySingleAsync<Users>(query, user);
        }
    }
}
