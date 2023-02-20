using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONEConverter.Context;
using ONEConverter.Helper;
using ONEConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ONEConverter.Extension
{
    public static class Extensions
    {
        internal static string HashData(this string value)
        {
            value = value.Replace("@", "").Replace(" ", "").ToUpperInvariant();
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(value));
                var sb = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
        internal static string ColorCode(this string value)
        {
            return value.Substring(3, value.Length - 3);
        }
        
    }
}
