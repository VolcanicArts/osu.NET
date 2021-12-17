using System;
using System.Globalization;

namespace volcanicarts.osu.NET.Util
{
    public class Parser
    {
        public static DateTime? ParseOsuTimestampNullable(string? timestamp)
        {
            DateTime.TryParseExact(
                timestamp,
                @"yyyy-MM-dd\THH:mm:ss\Z",
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal,
                out var d);
            return d;
        }

        public static DateTime ParseOsuTimestamp(string timestamp)
        {
            DateTime.TryParseExact(
                timestamp,
                @"yyyy-MM-dd\THH:mm:ss\Z",
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal,
                out var d);
            return d;
        }
    }
}