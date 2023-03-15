using System.Security.Cryptography;
using System.Text;

namespace Travel_Library.Recursos
{
    public class Utilidades
    {
        //Clase para encriptar la contraseñas a formato SHA256 para el inicio de sesión
        public static string EncriptarPassword(string password)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(password));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
