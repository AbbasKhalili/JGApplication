﻿using System.Collections.Generic;
using System.Linq;

namespace JG.Application
{
    public enum Language
    {
        English,
        Persian
    }

    public enum DigitGroup
    {
        Ones,
        Teens,
        Tens,
        Hundreds,
        Thousands
    }

    public class NumberWord
    {
        public DigitGroup Group { set; get; }
        public Language Language { set; get; }
        public IList<string> Names { set; get; }
    }
    public static class HumanReadableInteger
    {
        private static readonly IDictionary<Language, string> And = new Dictionary<Language, string>
                                                                    {
                                                                        {Language.English, " "},
                                                                        {Language.Persian, " و "}
                                                                    };
        private static readonly IList<NumberWord> NumberWords = new List<NumberWord>
  {
   new NumberWord { Group= DigitGroup.Ones, Language= Language.English, Names=
    new List<string> { string.Empty, "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" }},
   new NumberWord { Group= DigitGroup.Ones, Language= Language.Persian, Names=
    new List<string> { string.Empty, "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" }},

   new NumberWord { Group= DigitGroup.Teens, Language= Language.English, Names=
    new List<string> { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" }},
   new NumberWord { Group= DigitGroup.Teens, Language= Language.Persian, Names=
    new List<string> { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" }},

   new NumberWord { Group= DigitGroup.Tens, Language= Language.English, Names=
    new List<string> { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" }},
   new NumberWord { Group= DigitGroup.Tens, Language= Language.Persian, Names=
    new List<string> { "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" }},

   new NumberWord { Group= DigitGroup.Hundreds, Language= Language.English, Names=
    new List<string> {string.Empty, "One Hundred", "Two Hundred", "Three Hundred", "Four Hundred",
     "Five Hundred", "Six Hundred", "Seven Hundred", "Eight Hundred", "Nine Hundred" }},
   new NumberWord { Group= DigitGroup.Hundreds, Language= Language.Persian, Names=
    new List<string> {string.Empty, "یکصد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد" , "نهصد" }},

   new NumberWord { Group= DigitGroup.Thousands, Language= Language.English, Names=
     new List<string> { string.Empty, " Thousand", " Million", " Billion"," Trillion", " Quadrillion", " Quintillion", " Sextillian",
   " Septillion", " Octillion", " Nonillion", " Decillion", " Undecillion", " Duodecillion", " Tredecillion",
   " Quattuordecillion", " Quindecillion", " Sexdecillion", " Septendecillion", " Octodecillion", " Novemdecillion",
   " Vigintillion", " Unvigintillion", " Duovigintillion", " 10^72", " 10^75", " 10^78", " 10^81", " 10^84", " 10^87",
   " Vigintinonillion", " 10^93", " 10^96", " Duotrigintillion", " Trestrigintillion" }},
   new NumberWord { Group= DigitGroup.Thousands, Language= Language.Persian, Names=
     new List<string> { string.Empty, " هزار", " میلیون", " میلیارد"," تریلیون", " Quadrillion", " Quintillion", " Sextillian",
   " Septillion", " Octillion", " Nonillion", " Decillion", " Undecillion", " Duodecillion", " Tredecillion",
   " Quattuordecillion", " Quindecillion", " Sexdecillion", " Septendecillion", " Octodecillion", " Novemdecillion",
   " Vigintillion", " Unvigintillion", " Duovigintillion", " 10^72", " 10^75", " 10^78", " 10^81", " 10^84", " 10^87",
   " Vigintinonillion", " 10^93", " 10^96", " Duotrigintillion", " Trestrigintillion" }},
  };
        private static readonly IDictionary<Language, string> Negative = new Dictionary<Language, string>
  {
   { Language.English, "Negative " },
   { Language.Persian, "منهای " }
  };
        private static readonly IDictionary<Language, string> Zero = new Dictionary<Language, string>
  {
   { Language.English, "Zero" },
   { Language.Persian, "صفر" }
  };

        public static string NumberToText(this int number, Language language)
        {
            return NumberToText((long)number, language);
        }

        public static string NumberToText(this uint number, Language language)
        {
            return NumberToText((long)number, language);
        }

        public static string NumberToText(this byte number, Language language)
        {
            return NumberToText((long)number, language);
        }

        public static string NumberToText(this decimal number, Language language)
        {
            return NumberToText((long)number, language);
        }

        public static string NumberToText(this double number, Language language)
        {
            return NumberToText((long)number, language);
        }

        public static string NumberToText(this long number, Language language)
        {
            if (number == 0)
            {
                return Zero[language];
            }

            if (number < 0)
            {
                return Negative[language] + NumberToText(-number, language);
            }

            return Wordify(number, language, string.Empty, 0);
        }

        private static string GetName(int idx, Language language, DigitGroup group)
        {
            return NumberWords.First(x => x.Group == group && x.Language == language).Names[idx];
        }

        private static string Wordify(long number, Language language, string leftDigitsText, int thousands)
        {
            if (number == 0)
            {
                return leftDigitsText;
            }

            var wordValue = leftDigitsText;
            if (wordValue.Length > 0)
            {
                wordValue += And[language];
            }

            if (number < 10)
            {
                wordValue += GetName((int)number, language, DigitGroup.Ones);
            }
            else if (number < 20)
            {
                wordValue += GetName((int)(number - 10), language, DigitGroup.Teens);
            }
            else if (number < 100)
            {
                wordValue += Wordify(number % 10, language, GetName((int)(number / 10 - 2), language, DigitGroup.Tens), 0);
            }
            else if (number < 1000)
            {
                wordValue += Wordify(number % 100, language, GetName((int)(number / 100), language, DigitGroup.Hundreds), 0);
            }
            else
            {
                wordValue += Wordify(number % 1000, language, Wordify(number / 1000, language, string.Empty, thousands + 1), 0);
            }

            if (number % 1000 == 0) return wordValue;
            return wordValue + GetName(thousands, language, DigitGroup.Thousands);
        }
    }
}
