using System.Security.Cryptography;
using System.Text;

namespace BdVWebProject.Project.Base
{
    public class Encrypt
    {

        public static string EncriptarMD5(string valor)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] originalBytes = ASCIIEncoding.Default.GetBytes(valor);
            byte[] encodedBytes = md5.ComputeHash(originalBytes);
            StringBuilder result = new StringBuilder();
            
            for (int i = 0; i < encodedBytes.Length; i++)
            {
                result.Append(encodedBytes[i].ToString("x2"));
            }
            return result.ToString();
        }
    }
}
