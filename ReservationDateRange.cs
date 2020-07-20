using System;

namespace JG.Application
{
    public static class ReservationDateRange
    {
        public static Tuple<string, string, DateTime> Generate(string lastdate, int navigation)
        {
            var now = lastdate?.ToGregorianDate() ?? DateTime.Now;
            if (navigation != 0) now = now.AddDays(navigation);
            var addday = 0;
            switch (now.DayOfWeek)
            {
                case DayOfWeek.Saturday: { addday = 6; break; }
                case DayOfWeek.Sunday: { addday = 5; break; }
                case DayOfWeek.Monday: { addday = 4; break; }
                case DayOfWeek.Tuesday: { addday = 3; break; }
                case DayOfWeek.Wednesday: { addday = 2; break; }
                case DayOfWeek.Thursday: { addday = 1; break; }
                case DayOfWeek.Friday: { addday = 0; break; }
            }
            var fromdategeo = now.AddDays(addday - 6);
            return new Tuple<string, string, DateTime>(fromdategeo.ToPersianDate(), now.AddDays(addday).ToPersianDate(), fromdategeo);
        }

        public static Tuple<string, string, DateTime, DateTime> WeekDateRange(string persianDate)
        {
            var now = persianDate?.ToGregorianDate() ?? DateTime.Now;
            var addday = 0;
            switch (now.DayOfWeek)
            {
                case DayOfWeek.Saturday: { addday = 6; break; }
                case DayOfWeek.Sunday: { addday = 5; break; }
                case DayOfWeek.Monday: { addday = 4; break; }
                case DayOfWeek.Tuesday: { addday = 3; break; }
                case DayOfWeek.Wednesday: { addday = 2; break; }
                case DayOfWeek.Thursday: { addday = 1; break; }
                case DayOfWeek.Friday: { addday = 0; break; }
            }
            var fromGre = now.AddDays(addday - 6);
            var toGre = now.AddDays(addday);
            return new Tuple<string, string, DateTime, DateTime>(fromGre.ToPersianDate(), toGre.ToPersianDate(), fromGre, toGre);
        }
    }
}
