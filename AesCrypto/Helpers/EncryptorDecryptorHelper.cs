using System.Text;
using System.Security.Cryptography;
using AesCrypto.Models;

namespace AesCrypto.Helpers
{
    public static class EncryptorDecryptorHelper
    {
        private static readonly string salt = "salt1234";
        private static readonly string password = "password1234";

        public static AesModel CreateAesKeyAndIV()
        {
            byte[] saltBytes = Encoding.ASCII.GetBytes(salt);
            var key = new Rfc2898DeriveBytes(password, saltBytes);
            key.IterationCount = 2000;

            var model = new AesModel();
            model.AesKey = key.GetBytes(256 / 8);
            model.AesIV = key.GetBytes(128 / 8);

            return model;   
        }
    }
}
