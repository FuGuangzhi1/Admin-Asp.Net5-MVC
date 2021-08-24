using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Common.ConvertTpye
{
    public static class ConvertExtension
    {

        /// <summary>
        /// string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStr<T>(this T value)
        {
            try
            {
                return value.ToString().Trim();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// int
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32<T>(this T value)
        {
            if (value == null) return 0;

            int result = 0;

            if (!Int32.TryParse(value.ToStr(), out result))
                return 0;

            return result;
        }

        /// <summary>
        /// float
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ToFloat<T>(this T value)
        {
            if (value == null) return 0;

            float result = 0;

            if (!float.TryParse(value.ToStr(), out result))
                return 0;

            return result;
        }

        /// <summary>
        /// double
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble<T>(this T value)
        {
            if (value == null) return 0;

            double result = 0;

            if (!double.TryParse(value.ToStr(), out result))
                return 0;

            return result;
        }

        /// <summary>
        /// decimal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal<T>(this T value)
        {
            if (value == null) return 0;

            decimal result = 0;

            if (!decimal.TryParse(value.ToStr(), out result))
                return 0;

            return result;
        }

        /// <summary>
        /// Guid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid<T>(this T value)
        {
            if (value == null) return Guid.Empty;

            Guid result = Guid.Empty;

            if (!Guid.TryParse(value.ToStr(), out result))
                return Guid.Empty;

            return result;
        }

        /// <summary>
        /// Guid?
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid? ToGuidNull<T>(this T value)
        {
            if (value == null) return null;

            Guid result = Guid.Empty;

            if (!Guid.TryParse(value.ToStr(), out result))
                return null;

            return result;
        }

        /// <summary>
        /// GuidString
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToGuidStr<T>(this T value)
        {
            return value.ToGuid().ToStr();
        }

        /// <summary>
        /// DateTime
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime<T>(this T value)
        {
            if (value == null) return DateTime.MinValue;

            DateTime result = DateTime.MinValue;

            if (!DateTime.TryParse(value.ToStr(), out result))
                return DateTime.MinValue;

            return result;
        }

        /// <summary>
        /// DateTime?
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNull<T>(this T value)
        {
            if (value == null) return null;

            DateTime result = DateTime.MinValue;

            if (!DateTime.TryParse(value.ToStr(), out result))
                return null;

            return result;
        }

        /// <summary>
        /// 格式的 时间 字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="FormatStr"></param>
        /// <returns></returns>
        public static string ToDateTimeFormat<T>(this T value, string FormatStr = "yyyy-MM-dd")
        {
            var datetime = value.ToDateTime();
            if (datetime.ToShortDateString() == DateTime.MinValue.ToShortDateString())
                return String.Empty;
            else
                return datetime.ToString(FormatStr);
        }

        /// <summary>
        /// bool
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool<T>(this T value)
        {
            if (value == null) return false;

            bool result = false;

            if (!bool.TryParse(value.ToStr(), out result))
                return false;

            return result;
        }

        /// <summary>
        /// byte[]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToBytes<T>(this T value)
        {
            try
            {
                return value as byte[];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name=”timeStamp”></param>
        /// <returns></returns>
        public static DateTime ToTime<T>(this int timeStamp)
        {
            var dtStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name=”time”></param>
        /// <returns></returns>
        public static int ToTimeInt<T>(this DateTime time)
        {
            var startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            return (int)((time) - startTime).TotalSeconds;
        }

        public static T IsTypeNull<T>(T type, T type1)
        {
            if (type == null)
            {
                type = type1;
            }
            return type;
        } 

        public  static void IsTypeNull<T,T1>(T type, T1 type1) where T:T1
        {
            if (type1 == null)
            {
                type1=type;
            }
        }
    }
}
