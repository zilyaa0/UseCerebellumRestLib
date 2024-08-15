using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Helpers
{
    public static class StringExtensions
    {
        public static string JsonEscape(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            var res = JsonConvert.SerializeObject(s);
            return res.Substring(1, res.Length - 2);
        }
    }
}
