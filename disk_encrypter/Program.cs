using System;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Retrieve the disk serial number
            string diskSerial = DiskInfo.GetDiskSerialNumber();
            Console.WriteLine("Disk Serial Number: " + diskSerial);

            // Step 2: Encrypt the serial number
            string encryptedSerial = EncryptionHelper.Encrypt(diskSerial);
            Console.WriteLine("Encrypted Serial Number: " + encryptedSerial);

            // Step 3: Decrypt the serial number (for verification)
            string decryptedSerial = EncryptionHelper.Decrypt(encryptedSerial);
            Console.WriteLine("Decrypted Serial Number: " + decryptedSerial);

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
