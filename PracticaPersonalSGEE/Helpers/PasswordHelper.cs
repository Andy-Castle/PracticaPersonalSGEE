
using BCrypt.Net;

namespace PracticaPersonalSGEE.Helpers
{
    public class PasswordHelper
    {
        private const int WorkFactor = 12;

        //Genera un hash seguro de la contraseña
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
        }


        //Esta verifica la contraseña proporcionada coinicide con el hash almacenado
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        } 
    }
}
