using PracticaPersonalSGEE.Models;

namespace PracticaPersonalSGEE.DTOs
{
    public class UserDTO
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string PasswordHash { get; set; }

        public required string Role { get; set; }

    }
}
