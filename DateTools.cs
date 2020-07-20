using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JG.Application
{
    public static class DateTools
    {
        public static List<int> LeapYears => new List<int> {1399, 1403, 1408, 1412, 1416};
        private static readonly PersianCalendar Pcal = new PersianCalendar();

        public static string ToPersianDate(this DateTime date)
        {
            var result = Pcal.GetYear(date) + "/" +
                         (Pcal.GetMonth(date) < 10
                             ? "0" + Pcal.GetMonth(date)
                             : Pcal.GetMonth(date).ToString()) + "/" +
                         (Pcal.GetDayOfMonth(date) < 10
                             ? "0" + Pcal.GetDayOfMonth(date)
                             : Pcal.GetDayOfMonth(date).ToString());
            return result;
        }

        public static DateTime ToPersianDate(this string date)
        {
            if (date.Length < 10) date = FixDateTo10Character(date);
            var persiandate = date.Split(Convert.ToChar("/"));
            if (persiandate.Length < 3) throw new Exception("Date Foramt invalid.");
            var perDate = new DateTime(persiandate[0].ToInt(), persiandate[1].ToInt(), persiandate[2].ToInt(), new PersianCalendar());
            return perDate;
        }

        public static string GregorianToPersianDate(this string date)
        {
            return string.IsNullOrWhiteSpace(date) ? date : Convert.ToDateTime(date).ToPersianDate();
        }

        public static string GregorianToPersianDateTime(this string date)
        {
            return string.IsNullOrWhiteSpace(date) ? date : Convert.ToDateTime(date).ToPersianDate() + " " + Convert.ToDateTime(date).GetTimeWithSecond();
        }

        public static int ToPersianYear(this DateTime date)
        {
            return Pcal.GetYear(date);
        }

        public static DateTime ToGregorianDate(this string date,string time="00:00:00")
        {
            if (date == null) throw new Exception("Date Is Null.");
            if (date.Length < 10) throw new Exception("Date Foramt invalid.");
            var pDate = date.Split(Convert.ToChar("/"));
            if (pDate.Length < 3) throw new Exception("Date Foramt invalid.");

            var pTime = time.Split(Convert.ToChar(":"));

            var year = pDate[0].ToInt();
            var day = pDate[2].ToInt();

            var isLeap = LeapYears.FirstOrDefault(a => a == year);
            if (isLeap == 0 && day > 29)
                day = 29;

            var gregDate = new DateTime(year, pDate[1].ToInt(), day,
                pTime[0].ToInt(), pTime[1].ToInt(), pTime[2].ToInt(), new PersianCalendar());
            return gregDate;
        }

        public static string GetPersianDayName(this DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday: return "جمعه";
                case DayOfWeek.Monday: return "دوشنبه";
                case DayOfWeek.Saturday: return "شنبه";
                case DayOfWeek.Sunday: return "یکشنبه";
                case DayOfWeek.Thursday: return "پنج شنبه";
                case DayOfWeek.Wednesday: return "چهارشنبه";
                case DayOfWeek.Tuesday: return "سه شنبه";
            }
            return "";
        }

        public static int GetPersianDayOfWeek(this DayOfWeek dayOfWeek)
        {
            var result = (int) dayOfWeek;
            return result == 6 ? 0 : result + 1;
        }
        public static int GetPersianDayOfWeek(this string persianDate)
        {
            return persianDate.ToGregorianDate().DayOfWeek.GetPersianDayOfWeek();
        }
        public static string GetPersianDayName(this int dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case 0: return "شنبه";
                case 1: return "یکشنبه";
                case 2: return "دوشنبه";
                case 3: return "سه شنبه";
                case 4: return "چهارشنبه";
                case 5: return "پنج شنبه";
                case 6: return "جمعه";
            }
            return "";
        }

        public static string GetPersianDayName(this string date)
        {
            return date.Length != 10 ? "" : ToGregorianDate(date).ToPersianDayName();
        }

        public static int ToPersianDay(this DateTime date)
        {
            return Pcal.GetDayOfMonth(date);
        }

        public static int ToPersianDayOfWeek(this DateTime date)
        {
            //return (int)Pcal.GetDayOfWeek(date) + 1;
            return (int)Pcal.GetDayOfWeek(date);
        }

        public static string ToPersianDayName(this DateTime date)
        {
            return GetPersianDayName(Pcal.GetDayOfWeek(date));
        }

        public static int ToPersianMonth(this DateTime date)
        {
            return Pcal.GetMonth(date);
        }
        
        public static string FixDateTo10Character(this string date)
        {
            if (date.Length != 6) return date;
            return "13" + date.Insert(2, "/").Insert(5, "/");
        }

        public static string DateTo6Character(this string date)
        {
            if (date.Length != 10) return date;
            return date.Replace("/", "").Substring(2,6);
        }

        public static string ToPersianMonthName(this DateTime date)
        {
            return MonthName(Pcal.GetMonth(date));
        }

        private static string MonthName(int mon)
        {
            switch (mon)
            {
                case 1: return "فروردین";
                case 2: return "اردیبهست";
                case 3: return "خرداد";
                case 4: return "تیر";
                case 5: return "مرداد";
                case 6: return "شهریور";
                case 7: return "مهر";
                case 8: return "آبان";
                case 9: return "آذر";
                case 10: return "دی";
                case 11: return "بهمن";
                case 12: return "اسفند";
            }
            return "";
        }
    }
}
