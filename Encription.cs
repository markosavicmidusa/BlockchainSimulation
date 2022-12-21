using System;
using System.Security.Cryptography;
using System.Text;

namespace BlockchainSimulation
{
    internal class Encription
    {

        public static string SHA256Encription(string sourceMessage) {

            byte[] sourceMessageEncoded = null;
            byte[] hashMessageByteArray = null;
         

            // Encoding to byte[]
            sourceMessageEncoded = Encoding.ASCII.GetBytes(sourceMessage);

            // SHA256 Encription
            SHA256CryptoServiceProvider sha256CryptoServiceProvider = new SHA256CryptoServiceProvider();
            hashMessageByteArray = sha256CryptoServiceProvider.ComputeHash(sourceMessageEncoded);

            return  BitConverter.ToString(hashMessageByteArray).Replace("-", string.Empty);

        }

        public static string GenerateAccountNumberSHA256(string username, string password, string jmbg, DateTime createdAt)
        {
            
            string sourceMessage = String.Join(",", username, password, jmbg, createdAt.ToString());
            var hashMessageString = SHA256Encription(sourceMessage);

            return "0x" + hashMessageString;
        }

        public static string SHA1Encription(string password)
        {

            byte[] passwordByteArray = null;
            byte[] passwordEncripted = null;

            passwordByteArray = Encoding.ASCII.GetBytes(password);

            SHA1CryptoServiceProvider sha1CryptoServiceProvider = new SHA1CryptoServiceProvider();
            passwordEncripted = sha1CryptoServiceProvider.ComputeHash(passwordByteArray);

            return BitConverter.ToString(passwordEncripted).Replace("-", string.Empty);
        }
    }
}
