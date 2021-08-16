using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Common
{
    public static partial class SecurityMgr
    {
        public static string ToMD5(this string str)
        {
            using var md5 = MD5.Create();
            var data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder builder = new StringBuilder();
            // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串 
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("X2"));
            }
            string result = builder.ToString();
            return result;
        }
    }
}

