using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibMgmtSys.Utils
{
    public static class Utils
    {
        /// <summary>
        /// 获取MD5加密字符串
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetMd5(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return content;
            }
            
            using (var md5 = MD5.Create())
            {
               var bytes = md5.ComputeHash(Encoding.Default.GetBytes(content));
                var sb = new StringBuilder();
                for (byte i = 0; i < bytes.Length; i++)
                {
                    sb.Append(i.ToString("X2"));
                }

                return sb.ToString();
            }
        }

    }
}
