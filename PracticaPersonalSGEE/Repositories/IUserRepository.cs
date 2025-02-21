using PracticaPersonalSGEE.DTOs;
using PracticaPersonalSGEE.Models;

namespace PracticaPersonalSGEE.Repositories
{
    public interface IUserRepository
    {
        Task<Users> UserLogin(UserDTO userDTO);

        Task<Users> UserRegister(UserDTO userDTO);
    }
}
