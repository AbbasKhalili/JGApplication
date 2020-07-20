using System;
using System.Linq;

namespace JG.Application
{
    public static class TimeTools
    {
        public static string GetTime(this DateTime inputtime)
        {
            var hour = inputtime.Hour;
            var minute = inputtime.Minute;
            var time = hour < 10 ? "0" + hour : hour.ToString();
            time += ":" + (minute < 10 ? "0" + minute : minute.ToString());
            return time;
        }

        public static int GetTimeToInt(this DateTime inputtime)
        {
            var hour = inputtime.Hour;
            var minute = inputtime.Minute;
            var time = hour + (minute < 10 ? "0" + minute : minute.ToString());
            return time.ToInt();
        }

        public static int GetTimeToInt(this string inputtime)
        {
            var input = inputtime.Split(':').ToArray();
            var hour = input[0].ToInt();
            var minute = input[1].ToInt();
            var time = hour + (minute < 10 ? "0" + minute : minute.ToString());
            return time.ToInt();
        }


        public static string GetTimeWithSecond(this DateTime inputtime)
        {
            var hour = inputtime.Hour;
            var minute = inputtime.Minute;
            var second = inputtime.Second;
            var time = hour < 10 ? "0" + hour : hour.ToString();
            time += ":" + (minute < 10 ? "0" + minute : minute.ToString());
            time += ":" + (second < 10 ? "0" + second : second.ToString());
            return time;
        }
    }
}