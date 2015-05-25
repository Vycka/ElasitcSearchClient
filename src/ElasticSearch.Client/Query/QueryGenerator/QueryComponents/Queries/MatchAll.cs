﻿using System;
using System.Dynamic;
using ElasticSearch.Client.Utils;

namespace ElasticSearch.Client.Query.QueryGenerator.QueryComponents.Queries
{
    public class MatchAll : IQueryComponent
    {
        private readonly string _key;
        private readonly object _value;

        public MatchAll(string key, object value)
        {
            if (key == null) throw new ArgumentNullException("key");

            _key = key;
            _value = value;
        }

        public MatchAll()
        {
        }

        public object BuildRequestComponent()
        {
            ExpandoObject matchAllValue = new ExpandoObject();

            matchAllValue.AddIfNotNull(_key, _value);

            return new { match_all = matchAllValue };
        }
    }
}