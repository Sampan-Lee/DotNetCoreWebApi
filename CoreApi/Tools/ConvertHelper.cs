using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CoreApi.Tools
{
    public static class ConvertHelper
    {
        #region 字符串转换

        /// <summary>
        ///     转换为字符串
        /// </summary>
        /// <param name="data">数据</param>
        public static string ToString(this object data)
        {
            return data == null ? string.Empty : data.ToString().Trim();
        }

        #endregion 字符串转换

        #region 通用转换

        /// <summary>
        ///     泛型转换
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="data">数据</param>
        public static T To<T>(this object data)
        {
            if (data == null || string.IsNullOrWhiteSpace(data.ToString()))
                return default(T);

            Type type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            try
            {
                if (type.Name.ToLower() == "guid")
                    return (T)(object)new Guid(data.ToString());
                if (data is IConvertible)
                    return (T)Convert.ChangeType(data, type);
                return (T)data;
            }
            catch
            {
                return default(T);
            }
        }

        #endregion 通用转换

        /// <summary>
        ///     转化为JSON字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToJson(this object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        ///     json字符串反序列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T To<T>(this string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        ///     json字符串反序列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this string json) where T : class
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        #region 数值转换

        /// <summary>
        ///     转换为整型
        /// </summary>
        /// <param name="data">数据</param>
        public static int ToInt(this object data)
        {
            if (data == null)
                return 0;
            int result;
            var success = int.TryParse(data.ToString(), out result);
            if (success)
                return result;
            try
            {
                return Convert.ToInt32(ToDouble(data, 0));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static long ToLong(this object data)
        {
            if (data == null)
                return 0;
            long result;
            var success = long.TryParse(data.ToString(), out result);
            if (success)
                return result;
            try
            {
                return long.Parse(ToDouble(data, 0).ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        ///     转换为可空整型
        /// </summary>
        /// <param name="data">数据</param>
        public static int? ToIntOrNull(this object data)
        {
            if (data == null)
                return null;
            int result;
            bool isValid = int.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        ///     转换为双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static double ToDouble(this object data)
        {
            if (data == null)
                return 0;

            double result;
            return double.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        ///     转换为双精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static double ToDouble(this object data, int digits)
        {
            return Math.Round(ToDouble(data), digits);
        }

        /// <summary>
        ///     转换为可空双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static double? ToDoubleOrNull(this object data)
        {
            if (data == null)
                return null;

            double result;
            bool isValid = double.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        ///     转换为高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal ToDecimal(this object data)
        {
            if (data == null)
                return 0;

            decimal result;
            return decimal.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        ///     转换为高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal ToDecimal(this object data, int digits)
        {
            return Math.Round(ToDecimal(data), digits);
        }

        /// <summary>
        ///     decimal保留两位小数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="digits">小数点位数</param>
        /// <returns></returns>
        public static decimal ToDecimal(this decimal data, int digits)
        {
            switch (digits)
            {
                case 2:
                    data = ToDecimal(data.ToString("#0.00"));
                    break; ;
            }
            return data;
        }

        /// <summary>
        ///     转换为可空高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal? ToDecimalOrNull(this object data)
        {
            if (data == null)
                return null;
            decimal result;
            bool isValid = decimal.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        ///     转换为可空高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal? ToDecimalOrNull(this object data, int digits)
        {
            var result = ToDecimalOrNull(data);
            if (result == null)
                return null;
            return Math.Round(result.Value, digits);
        }

        #endregion 数值转换

        #region Guid转换

        /// <summary>
        ///     转换为Guid
        /// </summary>
        /// <param name="data">数据</param>
        public static Guid ToGuid(this object data)
        {
            if (data == null)
                return Guid.Empty;
            Guid result;
            return Guid.TryParse(data.ToString(), out result) ? result : Guid.Empty;
        }

        /// <summary>
        ///     转换为可空Guid
        /// </summary>
        /// <param name="data">数据</param>
        public static Guid? ToGuidOrNull(this object data)
        {
            if (data == null)
                return null;
            Guid result;
            bool isValid = Guid.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        ///     转换为Guid集合
        /// </summary>
        /// <param name="guid">guid集合字符串，范例:83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A</param>
        public static List<Guid> ToGuidList(this string guid)
        {
            var listGuid = new List<Guid>();
            if (string.IsNullOrWhiteSpace(guid))
                return listGuid;
            var arrayGuid = guid.Split(',');
            listGuid.AddRange(from each in arrayGuid where !string.IsNullOrWhiteSpace(each) select new Guid(each));
            return listGuid;
        }

        #endregion Guid转换

        #region 日期转换

        /// <summary>
        ///     转换为日期
        /// </summary>
        /// <param name="data">数据</param>
        public static DateTime ToDate(this object data)
        {
            if (data == null)
                return DateTime.MinValue;
            DateTime result;
            return DateTime.TryParse(data.ToString(), out result) ? result : DateTime.MinValue;
        }

        /// <summary>
        ///     转换为可空日期
        /// </summary>
        /// <param name="data">数据</param>
        public static DateTime? ToDateOrNull(this object data)
        {
            if (data == null)
                return null;
            DateTime result;
            bool isValid = DateTime.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        #region 时间戳 微信

        public static DateTime BaseTime = new DateTime(1970, 1, 1);//Unix起始时间

        /// <summary>
        /// 转换微信DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromXml(this long dateTimeFromXml)
        {
            return BaseTime.AddTicks((dateTimeFromXml + 8 * 60 * 60) * 10000000);
        }

        /// <summary>
        /// 转换微信DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromXml(this string dateTimeFromXml)
        {
            return GetDateTimeFromXml(long.Parse(dateTimeFromXml));
        }

        /// <summary>
        /// 获取微信DateTime（UNIX时间戳）
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static long GetWeixinDateTime(this DateTime dateTime)
        {
            return (dateTime.Ticks - BaseTime.Ticks) / 10000000 - 8 * 60 * 60;
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimestamp()
        {
            TimeSpan ts = DateTime.UtcNow - BaseTime;
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        #endregion 时间戳 微信

        #endregion 日期转换

        #region 布尔转换

        /// <summary>
        ///     转换为布尔值
        /// </summary>
        /// <param name="data">数据</param>
        public static bool ToBool(this object data)
        {
            if (data == null)
                return false;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool result;
            return bool.TryParse(data.ToString(), out result) && result;
        }

        /// <summary>
        ///     获取布尔值
        /// </summary>
        private static bool? GetBool(this object data)
        {
            switch (data.ToString().Trim().ToLower())
            {
                case "0":
                    return false;

                case "1":
                    return true;

                case "是":
                    return true;

                case "否":
                    return false;

                case "yes":
                    return true;

                case "no":
                    return false;

                default:
                    return null;
            }
        }

        /// <summary>
        ///     转换为可空布尔值
        /// </summary>
        /// <param name="data">数据</param>
        public static bool? ToBoolOrNull(this object data)
        {
            if (data == null)
                return null;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool result;
            bool isValid = bool.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        #endregion 布尔转换
    }
}