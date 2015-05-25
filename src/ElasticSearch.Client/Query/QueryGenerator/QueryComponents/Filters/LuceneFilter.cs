﻿using System;

namespace ElasticSearch.Client.Query.QueryGenerator.QueryComponents.Filters
{
    public class LuceneFilter : IFilterComponent
    {
        private readonly string _queryString;

        public LuceneFilter(string queryString)
        {
            if (queryString == null)
                throw new ArgumentNullException("queryString");

            _queryString = queryString;
        }

        public object BuildRequestComponent()
        {
            return new { fquery = new { query = new { query_string = new { query = _queryString } }, _cache = true } };
        }

        public QueryDate GetQueryDate()
        {
            return null;
        }
    }
}