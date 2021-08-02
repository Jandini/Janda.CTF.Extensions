using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Janda.CTF
{
    public static class CryptoExtensions
    {

        public static byte[] Decrypt(this byte[] combined, string key, PaddingMode padding = PaddingMode.None)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have valid value.", nameof(key));

            var buffer = new byte[combined.Length];
            var provider = new SHA512CryptoServiceProvider();
            var aesKey = new byte[24];

            var hash = provider.ComputeHash(Encoding.UTF8.GetBytes(key));

            Buffer.BlockCopy(hash, 0, aesKey, 0, aesKey.Length);

            using var aes = Aes.Create();

            if (aes == null)
                throw new ArgumentException("Parameter must not be null.", nameof(aes));

            aes.Key = aesKey;
            aes.Padding = padding;

            var iv = new byte[aes.IV.Length];
            var ciphertext = new byte[buffer.Length - iv.Length];

            Array.ConstrainedCopy(combined, 0, iv, 0, iv.Length);
            Array.ConstrainedCopy(combined, iv.Length, ciphertext, 0, ciphertext.Length);

            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var resultStream = new MemoryStream();
            using (var aesStream = new CryptoStream(resultStream, decryptor, CryptoStreamMode.Write))
            using (var plainStream = new MemoryStream(ciphertext))
            {
                plainStream.CopyTo(aesStream);
            }

            return resultStream.ToArray();
        }
    }
}
