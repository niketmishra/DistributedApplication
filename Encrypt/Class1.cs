using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

//Niket Mishra //nmishr26@asu.edu

//Here I have implemented a logic for encryption and decrypyion of a plain text/cipher text according to the key 


namespace Encrypt
{
    public class Class1
    {
        private static readonly Encoding encoding = Encoding.UTF8;
        public static string Encrypt(string plainString)
        { //The plain string will be encrypted using encoding method of c#
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(plainString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    plainString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return plainString;

        }

        public static string Decrypt(string encryptedString)
        {//The encypted string will be decrypted using encoding method of c#..if the string is not decryptable then exception is handled
            try
            {
                //string decrypted = "";
                string EncryptionKey = "abc123";
                encryptedString = encryptedString.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(encryptedString);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        encryptedString = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch { encryptedString = "invalid encrypted string"; } //excpetion handling
            return encryptedString;
        }

    }
}
