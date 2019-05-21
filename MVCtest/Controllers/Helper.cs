using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MVCtest.Controllers
{
    public class Helper
    {
        //public static string EncodePassword(string pass, string salt) //encrypt password    
        //{
        //    byte[] bytes = Encoding.Unicode.GetBytes(pass);
        //    byte[] src = Encoding.Unicode.GetBytes(salt);
        //    byte[] dst = new byte[src.Length + bytes.Length];
        //    System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
        //    System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
        //    HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
        //    byte[] inArray = algorithm.ComputeHash(dst);
        //    return Convert.ToBase64String(inArray);
        //    return EncodePasswordMd5(Convert.ToBase64String(inArray));
        //}
        public static int ID;

        public static string EncodePassword(string pass) //Encrypt using MD5    
        {
            //System.Text.
            SHA256 sha256 = new SHA256CryptoServiceProvider();//建立一個SHA256
            byte[] source = Encoding.Default.GetBytes(pass);//將字串轉為Byte[]
            byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
            string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
            return result;
        }

        public static bool CheckSession(HttpContextBase context)
        {
            if (context.Session["id"] != null)
            {
                ID = (int)context.Session["id"];
                return true;
            }
            else return false;


        }
    }
}