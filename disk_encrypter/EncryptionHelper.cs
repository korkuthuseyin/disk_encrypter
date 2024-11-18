using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace YourNamespace
{
    public class EncryptionHelper
    {
        private static string passphrase = "your-secure-passphrase"; // Set a secure passphrase

        // Generate a key from the passphrase
        private static Aes CreateAesCipher()
        {
            Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(passphrase.PadRight(32)); // Ensure 32-byte key
            aesAlg.IV = new byte[16]; // Use a fixed 16-byte IV for testing
            return aesAlg;
        }

        // Encrypt the serial number
        public static string Encrypt(string plainText)
        {
            using (Aes aesAlg = CreateAesCipher())
            {
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        // Decrypt the encrypted serial number
        public static string Decrypt(string cipherText)
        {
            using (Aes aesAlg = CreateAesCipher())
            {
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
