using System;
using System.IO;
using System.Security.Cryptography;
using AesCrypto.Helpers;

namespace AesCrypto
{
    public static class EncryptorDecryptor
    {
        public static string Encrypt(string plainText)
        {
            var model = EncryptorDecryptorHelper.CreateAesKeyAndIV();

            using (var aesAlg = new AesManaged())
            {
                var encryptor = aesAlg.CreateEncryptor(model.AesKey, model.AesIV);
                byte[] encrypted;

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        encrypted = ms.ToArray();
                    }
                }

                return Convert.ToBase64String(encrypted);
            }
        }

        public static string Decrypt(string cipherText)
        {
            var model = EncryptorDecryptorHelper.CreateAesKeyAndIV();

            using (var aesAlg = new AesManaged())
            {
                var decryptor = aesAlg.CreateDecryptor(model.AesKey, model.AesIV);
                var encrypted = Convert.FromBase64String(cipherText);
                string plainText = string.Empty;

                using (var ms = new MemoryStream(encrypted))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs))
                        {
                            plainText = sr.ReadToEnd();
                        }
                    }
                }

                return plainText;
            }
        }
    }
}
