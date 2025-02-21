using PracticaPersonalSGEE.DTOs;
using PracticaPersonalSGEE.Models;
using PracticaPersonalSGEE.Repositories;
using System.Text.RegularExpressions;

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
            var validRoles = new List<string> { "Admin", "Teacher", "Student" };

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (await _userRepository.EmailExists(userDTO.Email))
            {
                throw new ArgumentException("El correo ya esta registrado");
            }

            if (!Regex.IsMatch(userDTO.Email, emailPattern))
            {
                throw new ArgumentException("Tiene que ser un correo valido");
            }

            if (!validRoles.Contains(userDTO.Role))
            {
                throw new ArgumentException("Ese Rol no existe");
            }

            return await _userRepository.UserRegister(userDTO);
        }
    }
}
