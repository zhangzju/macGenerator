using System;
using System.Collections.Generic;
using System.Text;

namespace macGenerator
{
    public class Converter
    {
        private static String keys = "0123456789ABCDEF";
        private static int exponent = keys.Length;

        public static string Long2Str(long value)
        {
            string result = string.Empty;
            do
            {
                long index = value % exponent;
                result = keys[(int)index] + result;
                value = (value - index) / exponent;
            }
            while (value > 0);
            result = result.PadLeft(12, '0');
            List<string> listArr = new List<string>();
            for (var i = 0; i <= 11; i++)
            {
                listArr.Add(result[i].ToString());
                if (i < 11 && i % 2 == 1)
                {
                    listArr.Add("");
                }
            }
            return string.Join("", listArr.ToArray());
        }

        public static long Str2Long(string value)
        {
            value = value.Replace("-", "");
            long result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                int x = value.Length - i - 1;
                result += keys.IndexOf(value[i]) * Pow(exponent, x);
            }
            return result;
        }
        /// <summary>
        /// 一个数据的N次方
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static long Pow(long baseNo, long x)
        {
            long value = 1;
            while (x > 0)
            {
                value = value * baseNo;
                x--;
            }
            return value;
        }
    }
}
