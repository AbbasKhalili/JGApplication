using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Security.Application;

namespace JG.Application
{
    public static class StringTools
    {
        public static string SubString(this string str,int from, int to)
        {
            return str?.Substring(from, str.Length > to ? to : str.Length) ?? "";
        }

        public static List<string> ToListString(this string str)
        {
            return string.IsNullOrEmpty(str.Trim()) ? null : str.Split(Convert.ToChar(",")).ToList();
        }
        public static string ToCommaSeperate<T>(this List<T> list)
        {
            return "'" + string.Join("','", list.Select(itm => itm).ToList()) + "'";
        }

        public static string Sanitizing(this string str)
        {
            return Sanitizer.GetSafeHtmlFragment(str);
        }


        //TODO : Refactor to 'Interpreter' design pattern
        public static string ToEagleString(this string source)
        {
            byte[,] arr =
            {
                {32 , 32 , 145, 000, 147, 151, 153, 155, 154, 159, 158, 161, 160, 168, 170, 172}, //0
                {128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 174, 228, 227, 226, 232, 231}, //1
                {000,  33,  34,  35,  36,  37,  38,  39,  40,  41,  42,  43,  44,  45,  46,  46}, //2
                {48 ,  49,  50,  51,  52,  53,  54,  55,  56,  57,  58,  59,  60,  61,  62,  63}, //3
                {000,  65,  66,  67,  68,  69,  70,  71,  72,  73,  74,  75,  76,  77,  78,  79}, //4
                {80 ,  81,  82,  83,  84,  85,  86,  87,  88,  89,  90,  91,  92,  93,  94,  95}, //5
                {96 ,  97,  98,  99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111}, //6
                {112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 230}, //7
                {234, 148, 000, 236, 000, 000, 000, 000, 000, 000, 236,  60, 238, 156, 166, 247}, //8
                {239, 000, 000, 000, 000, 000, 196, 196, 249, 000, 254,  62, 253, 000, 000, 249}, //9
                {253, 000, 142, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000}, //A
                {000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000, 000}, //B
                {000, 000, 141, 141, 248, 000, 252, 144, 146, 000, 150, 152, 154, 158, 160, 162}, //C
                {163, 164, 165, 167, 169, 171, 173, 000, 175, 224, 225, 229, 196, 233, 235, 237}, //D
                {000, 241, 000, 244, 246, 249, 248, 249, 149, 157, 156, 239, 252, 253, 243, 245}, //E
                {000, 000, 000, 000, 251, 000, 000, 000, 000, 234, 000, 000, 000, 000, 000, 000}, //F
            };

            if (string.IsNullOrEmpty(source)) return ((char)arr[0, 0]).ToString();

            char[] oneChar = { 'و', 'ر', 'ز', 'د', 'ذ', 'ا', ' ' };
            var target = new List<byte>();
            for (var i = 0; i < source.Length; i++)
            {
                var first = false;
                var last = false;
                var one = false;
                var mid = false;

                if (i == 0 || oneChar.Any(a => a == source[i]))
                    first = true;
                if (i == source.Length - 1)
                    last = true;
                if (last && first)
                    one = true;
                if (!last && !first)
                    mid = true;

                switch (source[i])
                {
                    case 'ب':
                    {
                        if (one)
                            target.Add(arr[12, 8]);
                            else if (mid)
                                target.Add(arr[0, 4]);
                            else if (first)
                                target.Add(arr[0, 4]);
                            else if (last)
                                target.Add(arr[12, 8]);
                            break;
                        }
                    case 'ت':
                        {
                            if (one)
                                target.Add(arr[12, 10]);
                            else if (mid)
                                target.Add(arr[0, 5]);
                            else if (first)
                                target.Add(arr[0, 5]);
                            else if (last)
                                target.Add(arr[12, 10]);
                            break;
                        }
                    case 'ث':
                        {
                            if (one)
                                target.Add(arr[12, 11]);
                            else if (mid)
                                target.Add(arr[0, 6]);
                            else if (first)
                                target.Add(arr[0, 6]);
                            else if (last)
                                target.Add(arr[12, 11]);
                            break;
                        }
                    case 'ج':
                        {
                            if (one)
                                target.Add(arr[12, 12]);
                            else if (mid)
                                target.Add(arr[0, 7]);
                            else if (first)
                                target.Add(arr[0, 7]);
                            else if (last)
                                target.Add(arr[0, 8]);
                            break;
                        }
                    case 'ح':
                        {
                            if (one)
                                target.Add(arr[12, 13]);
                            else if (mid)
                                target.Add(arr[0, 9]);
                            else if (first)
                                target.Add(arr[0, 9]);
                            else if (last)
                                target.Add(arr[0, 10]);
                            break;
                        }
                    case 'خ':
                        {
                            if (one)
                                target.Add(arr[12, 14]);
                            else if (mid)
                                target.Add(arr[0, 11]);
                            else if (first)
                                target.Add(arr[0, 11]);
                            else if (last)
                                target.Add(arr[0, 13]);
                            break;
                        }
                    case 'س':
                        {
                            if (one)
                                target.Add(arr[13, 3]);
                            else if (mid)
                                target.Add(arr[0, 13]);
                            else if (first)
                                target.Add(arr[0, 13]);
                            else if (last)
                                target.Add(arr[13, 3]);
                            break;
                        }
                    case 'ش':
                        {
                            if (one)
                                target.Add(arr[13, 4]);
                            else if (mid)
                                target.Add(arr[0, 14]);
                            else if (first)
                                target.Add(arr[0, 14]);
                            else if (last)
                                target.Add(arr[13, 4]);
                            break;
                        }
                    case 'ص':
                        {
                            if (one)
                                target.Add(arr[13, 5]);
                            else if (mid)
                                target.Add(arr[0, 15]);
                            else if (first)
                                target.Add(arr[0, 15]);
                            else if (last)
                                target.Add(arr[13, 5]);
                            break;
                        }
                    case 'ض':
                        {
                            if (one)
                                target.Add(arr[13, 6]);
                            else if (mid)
                                target.Add(arr[1, 10]);
                            else if (first)
                                target.Add(arr[1, 10]);
                            else if (last)
                                target.Add(arr[13, 6]);
                            break;
                        }
                    case 'ع':
                        {
                            if (one)
                                target.Add(arr[13, 10]);
                            else if (mid)
                                target.Add(arr[1, 12]);
                            else if (first)
                                target.Add(arr[1, 11]);
                            else if (last)
                                target.Add(arr[1, 13]);
                            break;
                        }
                    case 'غ':
                        {
                            if (one)
                                target.Add(arr[13, 11]);
                            else if (mid)
                                target.Add(arr[1, 15]);
                            else if (first)
                                target.Add(arr[1, 14]);
                            else if (last)
                                target.Add(arr[7, 15]);
                            break;
                        }
                    case 'ف':
                        {
                            if (one)
                                target.Add(arr[13, 13]);
                            else if (mid)
                                target.Add(arr[8, 0]);
                            else if (first)
                                target.Add(arr[8, 0]);
                            else if (last)
                                target.Add(arr[13, 13]);
                            break;
                        }
                    case 'پ':
                        {
                            if (one)
                                target.Add(arr[8, 1]);
                            else if (mid)
                                target.Add(arr[14, 8]);
                            else if (first)
                                target.Add(arr[14, 8]);
                            else if (last)
                                target.Add(arr[8, 1]);
                            break;
                        }
                    case 'ق':
                        {
                            if (one)
                                target.Add(arr[13, 14]);
                            else if (mid)
                                target.Add(arr[8, 3]);
                            else if (first)
                                target.Add(arr[8, 3]);
                            else if (last)
                                target.Add(arr[13, 14]);
                            break;
                        }
                    case 'چ':
                        {
                            if (one)
                                target.Add(arr[8, 13]);
                            else if (mid)
                                target.Add(arr[14, 9]);
                            else if (first)
                                target.Add(arr[14, 9]);
                            else if (last)
                                target.Add(arr[14, 10]);
                            break;
                        }
                    case 'ن':
                        {
                            if (one)
                                target.Add(arr[14, 4]);
                            else if (mid)
                                target.Add(arr[8, 15]);
                            else if (first)
                                target.Add(arr[8, 15]);
                            else if (last)
                                target.Add(arr[14, 4]);
                            break;
                        }
                    case 'گ':
                        {
                            if (one)
                                target.Add(arr[9, 0]);
                            else if (mid)
                                target.Add(arr[14, 11]);
                            else if (first)
                                target.Add(arr[14, 11]);
                            else if (last)
                                target.Add(arr[9, 0]);
                            break;
                        }
                    case 'ك':
                    case 'ک':
                        {
                            if (one)
                                target.Add(arr[13, 15]);
                            else if (mid)
                                target.Add(arr[8, 12]);
                            else if (first)
                                target.Add(arr[8, 12]);
                            else if (last)
                                target.Add(arr[13, 15]);
                            break;
                        }
                    case 'ه':
                        {
                            if (one)
                                target.Add(arr[14, 5]);
                            else if (mid)
                                target.Add(arr[15, 4]);
                            else if (first)
                                target.Add(arr[15, 4]);
                            else if (last)
                                target.Add(arr[9, 8]);
                            break;
                        }
                    case 'ی':
                    case 'ي':
                        {
                            if (one)
                                target.Add(arr[14, 13]);
                            else if (mid)
                                target.Add(arr[9, 10]);
                            else if (first)
                                target.Add(arr[9, 10]);
                            else if (last)
                                target.Add(arr[12, 6]);
                            break;
                        }
                    case 'ئ':
                        {
                            if (one)
                                target.Add(arr[14, 13]);
                            else if (mid)
                                target.Add(arr[12, 15]);
                            else if (first)
                                target.Add(arr[12, 15]);
                            else if (last)
                                target.Add(arr[12, 6]);
                            break;
                        }
                    case 'ا':
                        {
                            if (one)
                                target.Add(arr[12, 15]);
                            else if (mid)
                                target.Add(arr[0, 2]);
                            else if (first)
                                target.Add(arr[12, 15]);
                            else if (last)
                                target.Add(arr[0, 2]);
                            break;
                        }
                    case 'ل':
                        {
                            if (one)
                                target.Add(arr[14, 1]);
                            else if (mid)
                                target.Add(arr[14, 14]);
                            else if (first)
                                target.Add(arr[14, 14]);
                            else if (last)
                                target.Add(arr[14, 1]);
                            break;
                        }
                    case 'م':
                        {
                            if (one)
                                target.Add(arr[14, 3]);
                            else if (mid)
                                target.Add(arr[14, 15]);
                            else if (first)
                                target.Add(arr[14, 15]);
                            else if (last)
                                target.Add(arr[14, 3]);
                            break;
                        }
                    case 'د': { target.Add(arr[12, 15]); break; }
                    case 'ذ': { target.Add(arr[13, 0]); break; }
                    case 'ر': { target.Add(arr[13, 1]); break; }
                    case 'ز': { target.Add(arr[13, 2]); break; }
                    case 'ژ': { target.Add(arr[8, 14]); break; }
                    case 'ط': { target.Add(arr[13, 8]); break; }
                    case 'ظ': { target.Add(arr[13, 9]); break; }
                    case 'و': { target.Add(arr[14, 6]); break; }
                    case ' ': { target.Add(arr[0, 0]); break; }
                    case '0': { target.Add(arr[1, 0]); break; }
                    case '1': { target.Add(arr[1, 1]); break; }
                    case '2': { target.Add(arr[1, 2]); break; }
                    case '3': { target.Add(arr[1, 3]); break; }
                    case '4': { target.Add(arr[1, 4]); break; }
                    case '5': { target.Add(arr[1, 5]); break; }
                    case '6': { target.Add(arr[1, 6]); break; }
                    case '7': { target.Add(arr[1, 7]); break; }
                    case '8': { target.Add(arr[1, 8]); break; }
                    case '9': { target.Add(arr[1, 9]); break; }
                }
            }
            var result = "";
            for (var i = target.Count-1; i >= 0; i--)
            {
                result += (char)target[i];
            }
            return result;
        }
    }
}
