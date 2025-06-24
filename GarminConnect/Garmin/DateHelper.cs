using System.Globalization;

namespace GarminConnect
{
    /// <summary>
    /// 日期帮助类
    /// </summary>
    public static class DateHelper
    {
        /// <summary>
        /// 将 DateTime 转换为 yyyy-MM-dd 格式的字符串，调整时区偏移
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToDateString(DateTime date)
        {
            // 将日期转换成本地时间（如果传入的是 UTC 时间）
            DateTime localDate = date.Kind == DateTimeKind.Utc ? date.ToLocalTime() : date;

            // 只取年月日部分，格式化成字符串
            return localDate.ToString("yyyy-MM-dd");
        }

        // 计算两个时间戳（毫秒）之间的时间差，返回小时和分钟
        public static TimeDifference CalculateTimeDifference(long sleepStartTimestampGMT, long sleepEndTimestampGMT)
        {
            // 计算时间差，单位为秒
            double timeDifferenceInSeconds = (sleepEndTimestampGMT - sleepStartTimestampGMT) / 1000.0;

            int hours = (int)Math.Floor(timeDifferenceInSeconds / 3600);
            int minutes = (int)Math.Floor((timeDifferenceInSeconds % 3600) / 60);

            return new TimeDifference
            {
                Hours = hours,
                Minutes = minutes
            };
        }

        /// <summary>
        /// 根据指定时区获取本地时间戳，格式为 yyyy-MM-ddTHH:mm:ss.fff
        /// </summary>
        /// <param name="date">时间</param>
        /// <param name="timezone">时区</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GetLocalTimestamp(DateTime date, string timezone)
        {
            // 解析时区信息
            TimeZoneInfo tzInfo;
            try
            {
                tzInfo = TimeZoneInfo.FindSystemTimeZoneById(timezone);
            }
            catch (TimeZoneNotFoundException)
            {
                throw new ArgumentException("无效的时区标识");
            }
            catch (InvalidTimeZoneException)
            {
                throw new ArgumentException("无效的时区数据");
            }

            // 将输入时间转换成指定时区时间
            DateTime targetTime;

            if (date.Kind == DateTimeKind.Unspecified)
            {
                // 如果Kind是Unspecified，先假设是本地时间，再转换
                var localDate = DateTime.SpecifyKind(date, DateTimeKind.Local);
                targetTime = TimeZoneInfo.ConvertTime(localDate, tzInfo);
            }
            else
            {
                targetTime = TimeZoneInfo.ConvertTime(date, tzInfo);
            }

            // 格式化为 ISO 8601 格式，保留毫秒，去掉时区信息
            return targetTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
    }

    /// <summary>
    /// 时差
    /// </summary>
    public class TimeDifference
    {
        /// <summary>
        /// 小时
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// 分钟
        /// </summary>
        public int Minutes { get; set; }
    }
}
