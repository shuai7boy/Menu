using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MP.Common
{
    public static class Md5Helper
    {
        //将接收的字符串转换为MD5
        public static string GetMd5Str(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] buffer = Encoding.Default.GetBytes(str);
            byte[] md5Byte=md5.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5Byte.Length; i++)
            {
                sb.Append(md5Byte[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
