﻿using System.Collections.Generic;
using System.Dynamic;

namespace ElasticSearch.Client.Utils
{
    public static class DictionaryStringObjectExtensions
    {
        public static void AddIfNotNull(this Dictionary<string, object> dictionary, string key, object value)
        {
            if (value != null)
            {
                dictionary.Add(key, value);
            }
        }


        public static void Add(this Dictionary<string, object> dictionary, string key, object value)
        {
            dictionary.Add(key, value);
        }
    }
}