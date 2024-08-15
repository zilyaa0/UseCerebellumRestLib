using System;

namespace CerebellumRestLib.Helpers
{
    public static class TimeExtensions
    {

        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long GetUnixTime(this DateTime winTime)
        {
            return new DateTimeOffset(winTime).ToUnixTimeSeconds();
        }
        public static long? GetUnixTime(this DateTime? winTime)
        {
            return winTime.HasValue ? new DateTimeOffset(winTime.Value).ToUnixTimeSeconds() : (long?)null;
        }

        public static DateTime ToLocalTime(this long seconds)
        {
            if (seconds < 1000000000000)
                return UnixEpoch.AddSeconds(seconds).ToLocalTime();
            else
                return UnixEpoch.AddMilliseconds(seconds).ToLocalTime();

        }
        public static DateTime? ToLocalTime(this long? seconds)
        {
            return seconds?.ToLocalTime();
        }
        public static DateTime ToLocalTimeFromMS(this long milliseconds)
        {
            return UnixEpoch.AddMilliseconds(milliseconds).ToLocalTime();
        }
        public static DateTime? ToLocalTimeFromMS(this long? milliseconds)
        {
            return milliseconds?.ToLocalTimeFromMS();
        }
    }
}
