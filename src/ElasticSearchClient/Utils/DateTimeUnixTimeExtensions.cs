﻿using System;

namespace ElasticSearchClient.Utils
{
    public static class DateTimeUnixTimeExtensions
    {
        public static DateTime UnixTimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public static long ToUnixTimeMs(this DateTime currentDateTime)
        {
            return (long)(currentDateTime - UnixTimeStart).TotalMilliseconds;
        }

        public static int ToUnixTime(this DateTime currentDateTime)
        {
            return (int)(currentDateTime - UnixTimeStart).TotalSeconds;
        }
       
    }
}