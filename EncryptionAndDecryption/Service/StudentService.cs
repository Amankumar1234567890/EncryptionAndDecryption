using EncryptionAndDecryption.Model;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionAndDecryption.Service
{
    public static class StudentService
    {
        /// <summary>
        /// Using AES for encryption and Decryption of Data
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// 

        #region 

        #endregion
        public static string StudentDataEncrytion(String email)
        {
            string encryptionKey = "MAKV2SPBNI99212";
       
           
            byte[] clearBytes = Encoding.Unicode.GetBytes(email);
            using (System.Security.Cryptography.Aes encryptor = System.Security.Cryptography.Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    email = Convert.ToBase64String(ms.ToArray());
                }
            }

            return email;
            
          
        }
        public static string StudentDataDecryption(String email)
        {
            string encryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(email);
            using (System.Security.Cryptography.Aes encryptor = System.Security.Cryptography.Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    email = Encoding.Unicode.GetString(ms.ToArray());
                }
            }

            return email;


        }
    }
}
