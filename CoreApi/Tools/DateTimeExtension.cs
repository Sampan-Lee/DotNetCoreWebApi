using System;

namespace CoreApi.Tools
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 一个月的第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime FirstDayofMonth(this DateTime date)
        {
            return date.AddDays(-(date.Day) + 1);
        }

        /// <summary>
        /// 一个月的最后一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime LastDayofMonth(this DateTime date)
        {
            int tatoaldays = DateTime.DaysInMonth(date.Year, date.Month);
            int ts = tatoaldays - date.Day;
            return date.AddDays(ts);
        }

        /// <summary>
        /// 与指定日期相差几个月
        /// </summary>
        /// <param name="dt">小的日期</param>
        /// <param name="date">大的日期</param>
        /// <returns></returns>
        public static int IntervalMonths(this DateTime dt, DateTime date)
        {
            //return  (dt.Year - date.Year) * 12 + (dt.Month - date.Month);
            return (date.Year * 12 - (12 - date.Month)) - (dt.Year * 12 - (12 - dt.Month));
        }

        /// <summary>
        /// 当前季度月
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime CurrentQuarter(this DateTime date)
        {
            if (date.Month % 3 == 0)
                return date;

            var month = date.Month / 3 * 3 + 3;
            return date.AddMonths(month - date.Month).LastDayofMonth();
        }

        /// <summary>
        /// 上一个季度月
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime PrevQuarter(this DateTime date)
        {
            if (date.Month % 3 == 0)
                return date.AddMonths(-3);

            var month = date.Month / 3 * 3;
            return date.AddMonths(month - date.Month).LastDayofMonth();
        }
    }
}