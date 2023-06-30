using System.Security.Cryptography;
using System.Text;

namespace Biblioteca.Utility
{
    public class Security
    {
        #region Encriptacion
        private static string contrasegnia = "@Sistemas";
        // Crea la llave y el vector de inicialización para la 
        // contraseña de protección del contenido a 
        // encriptar o desencriptar usando un algoritmo basado en TripleDES:
        private static TripleDES CrearDES(string clave)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(clave));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }
        // Encripta una cadena de caracteres usando una contraseña personalizada:
        public static string EncriptarCadenaDeCaracteres(string textoPlano)
        {
            // Primero debemos convertir el texto plano en `textoPlano` 
            // en un arreglo de bytes:
            byte[] textoPlanoBytes = Encoding.Unicode.GetBytes(textoPlano);
            // Uso de un flujo de memoria para la contención de los bytes:
            MemoryStream flujoMemoria = new MemoryStream();
            // Creación de la clave de protección y el vector de inicialización:
            TripleDES des = CrearDES(contrasegnia);
            // Creación del codificador para la escritura al flujo de memoria:
            CryptoStream flujoEncriptacion = new CryptoStream(flujoMemoria, des.CreateEncryptor(), CryptoStreamMode.Write);
            // Escritura del arreglo de bytes sobre el flujo de memoria:
            flujoEncriptacion.Write(textoPlanoBytes, 0, textoPlanoBytes.Length);
            flujoEncriptacion.FlushFinalBlock();
            // Retorna representación legible de la cadena encriptada:
            return Convert.ToBase64String(flujoMemoria.ToArray());
        }
        // Descripta una cadena encriptada usando una contraseña de protección:
        public static string DesencriptarCadenaDeCaracteres(string textoEncriptado)
        {
            // Primero debemos convertir el texto plano en `textoPlano` 
            // en un arreglo de bytes:
            byte[] bytesEncriptados = Convert.FromBase64String(textoEncriptado);
            // Uso de un flujo de memoria para la contención de los bytes:
            MemoryStream flujoMemoria = new MemoryStream();
            // Creación de la clave de protección y el vector de inicialización:
            TripleDES des = CrearDES(contrasegnia);
            // Creación de decodificador:
            CryptoStream flujoDesencriptacion = new CryptoStream(flujoMemoria, des.CreateDecryptor(), CryptoStreamMode.Write);
            // Escritura del arreglo de bytes sobre el flujo de memoria:
            flujoDesencriptacion.Write(bytesEncriptados, 0, bytesEncriptados.Length);
            flujoDesencriptacion.FlushFinalBlock();
            // Conversión del flujo de datos en una cadena de caracteres:
            return Encoding.Unicode.GetString(flujoMemoria.ToArray());
        }
        #endregion
        #region Contraseña
        //Generar Contraseña Random
        // Instantiate random number generator.
        // It is better to keep a single Random instance
        // and keep using Next on the same instance.
        private static readonly Random _random = new Random();
        // Generates a random number within a range.
        private static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        // Generates a random string with a given size.
        private static string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.
            // char is a single Unicode character
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26
            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        // Generates a random password.
        // 4-LowerCase + 4-Digits + 2-UpperCase
        public static string RandomPassword()
        {
            var passwordBuilder = new StringBuilder();
            // 4-Letters lower case
            passwordBuilder.Append(RandomString(4, true));
            // 4-Digits between 1000 and 9999
            passwordBuilder.Append(RandomNumber(1000, 9999));
            // 2-Letters upper case
            passwordBuilder.Append(RandomString(2));
            return passwordBuilder.ToString();
        }
        #endregion
    }
}
