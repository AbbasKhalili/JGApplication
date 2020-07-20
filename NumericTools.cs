using System;
using System.Collections.Generic;
using System.Linq;

namespace JG.Application
{
    public static class NumericTools
    {
        public static int ToInt(this string stringValue, int defaultValue=0)
        {
            stringValue = stringValue?.Replace(",", "");
            int number;
            return int.TryParse(stringValue, out number) ? number : defaultValue;
        }

        public static long ToLong(this string stringValue)
        {
            return long.Parse(stringValue);
        }

        public static double ToDouble(this string stringValue)
        {
            return double.Parse(stringValue);
        }

        public static List<int> ToListInt(this string str)
        {
            return string.IsNullOrEmpty(str.Trim()) ? null : str.Split(Convert.ToChar(",")).Select(int.Parse).ToList();
        }
    }
}
