using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Desktop.Common
{
    internal class Utility
    {
        public static bool ConvertStatusToBoolean(int status)
        {
            return status == Constants.STATUS_ENABLED_INT;
        }

        public static int ConvertBooleanToStatus(bool status)
        {
            return status ? Constants.STATUS_ENABLED_INT : Constants.STATUS_DISABLED_INT;
        }

        public static string ConvertStatusToString(int status)
        {
            if(status == Constants.STATUS_ENABLED_INT)
                return Constants.STATUS_ENABLED_STRING;

            else if(status == Constants.STATUS_DISABLED_INT)
                return Constants.STATUS_DISABLED_STRING;

            else
                return Constants.STATUS_DELETION_STRING;
        }

        public static string EncryptPassowrd(string password)
        {
            if (string.IsNullOrEmpty(password))
                return password;

            byte[] data = UTF8Encoding.UTF8.GetBytes(password);
            using(MD5CryptoServiceProvider md5 =new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Constants.HASH));
                using(TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode =CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(result, 0, result.Length);
                }
            }
        }

        public static string DescryptPassowrd(string password)
        {
            if (string.IsNullOrEmpty(password))
                return password;

            byte[] data = Convert.FromBase64String(password);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Constants.HASH));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(result);
                }
            }
        }
    }
}
