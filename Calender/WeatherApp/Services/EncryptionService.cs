using System.Security.Cryptography;
using System.Text;

namespace WeatherApp.Services
{
    public class EncryptionService
    {
        // Encryption function: Encrypt coordinates using IP as the key
        public static string EncryptCoordinate(string coordinate, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GenerateKeyFromIp(key);
                aesAlg.IV = new byte[16]; // Initialization Vector (set to zero for simplicity)

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] coordinateBytes = Encoding.UTF8.GetBytes(coordinate);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(coordinateBytes, 0, coordinateBytes.Length);

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        // Decryption function: Decrypt coordinates using IP as the key
        public static string DecryptCoordinate(string encryptedCoordinate, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GenerateKeyFromIp(key);
                aesAlg.IV = new byte[16]; // Initialization Vector (set to zero for simplicity)

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] encryptedBytes = Convert.FromBase64String(encryptedCoordinate);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        // Generate a Key from the IP (you may want to improve this for real-world use)
        public static byte[] GenerateKeyFromIp(string ip)
        {
            // Convert IP to a byte array and hash it to make a 256-bit key
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] ipBytes = Encoding.UTF8.GetBytes(ip);
                return sha256.ComputeHash(ipBytes);
            }
        }
    }
}
