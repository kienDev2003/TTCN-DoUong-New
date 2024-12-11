using System.Collections.Generic;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace QLBH_TTCN_DoUong
{
    public class Common
    {
        public static string MD5_Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                // Băm chuỗi thành mảng byte
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Chuyển mảng byte thành chuỗi hex
                StringBuilder sb = new StringBuilder();
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2"));  // "x2" giúp hiển thị dưới dạng hex
                }

                return sb.ToString();  // Trả về kết quả là chuỗi MD5
            }
        }
    }
}