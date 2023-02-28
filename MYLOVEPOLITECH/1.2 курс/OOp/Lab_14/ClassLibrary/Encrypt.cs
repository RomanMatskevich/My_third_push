using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Encrypt
    {
        public static byte[] EncryptFile(byte[] bytes, string Key)
        {
            byte[] key = Encoding.ASCII.GetBytes(Key);
            for (int i = 0; i < bytes.Length; i++)        
            {
                bytes[i] = (byte)(bytes[i] ^ key[i % key.Length]);
            }
            return bytes;
        }
        public static byte[] DecryptFile(byte[] bytes, string Key)
        {
            byte[] key = Encoding.ASCII.GetBytes(Key);
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)(bytes[i] ^ key[i % key.Length]);
            }
            return bytes;
        }
        public static string CheckEncrypted(string FileName)
        {
            if (FileName.EndsWith(".crypt"))
                return FileName;
            else
                return FileName + ".crypt";
        }
        public static string CheckDecrypted(string FileName)
        {
            if (FileName.EndsWith(".crypt"))
            {
                return FileName.Remove(FileName.LastIndexOf(".crypt"));
            }
            else
            {
                return FileName;
            }
        }
    }
}
