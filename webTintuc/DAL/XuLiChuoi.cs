using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace webTintuc.DAL
{
    public class XuLiChuoi
    {
        private static Regex _compiledUnicodeRegex = new Regex(@"[^\u0000-\u007F]", RegexOptions.Compiled);

        public static String StripUnicodeCharactersFromString(string inputValue)
        {
            return _compiledUnicodeRegex.Replace(inputValue, String.Empty);
        }
        public static string xoaKhoangTrang(string s)
        {
            s = StripUnicodeCharactersFromString(s);
            
            return s.Replace(" ",string.Empty);
        }
    }
}