using PracticaPersonalSGEE.DTOs;
using PracticaPersonalSGEE.Models;
using PracticaPersonalSGEE.Repositories;

namespace PracticaPersonalSGEE.Services
{
    public class UserService 
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
       
        }

        public async Task<Users> RegisterUser(UserDTO userDTO)
        {
            if (await _userRepository.EmailExists(userDTO.Email))
            {
                throw new InvalidOperationException("El correo ya esta registrado");
            }

            if (userDTO.Role == "Admin" || userDTO.Role == "Teacher" || userDTO.Role == "Student")
            {
                throw new InvalidOperationException("Ese Rol no existe");
            }

            return await _userRepository.UserRegister(userDTO);
        }
    }
}
