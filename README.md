Trying to create friendly, yet functional __ElasticSearch C# Client__.

You can execute queries as simple as these

```cs
  ElasticSearchClient client = new ElasticSearchClient("http://localhost:9200/");

  QueryBuilder builder = new QueryBuilder();
  builder.SetQuery(new TermQuery("_type", "errors");

  ElasticSearchResult result = client.ExecuteQuery(builder);
```

Or as complex as these

```cs
  var rabbitIndex = new TimeStampedIndexDescriptor("RabbitMQ-", "yyyy.MM.dd", "@timestamp", IndexStep.Day);
  var securityIndex = new TimeStampedIndexDescriptor("Security-", "yyyy.MM.dd", "@timestamp", IndexStep.Day);
  ElasticSearchClient client = new ElasticSearchClient("http://localhost:9200/", rabbitIndex, securityIndex);

  QueryBuilder builder = new QueryBuilder();
  builder.SetQuery(new TermQuery("_type", "errors"));

  builder.Filtered.Queries.Add(QueryType.Should, new TermQuery("Level","ERROR"));
  builder.Filtered.Filters.Add(FilterType.Must, new MovingTimeRange("@timestamp", 86400));
  builder.Filtered.Filters.Add(FilterType.MustNot, new LuceneFilter("EventType:IrrelevantError"));
  ElasticSearchResult result = client.ExecuteQuery(builder);
```

An as of the result, Query like this will be generated:

```js
POST: http://localhost:9200/RabbitMQ-2015.03.21,RabbitMQ-2015.03.22,Security-2015.03.21,Security-2015.03.22/_search/_search 
{
  "query": {
    "filtered": {
      "query": {
        "bool": {
          "should": [
            {
              "term": {
                "Level": "ERROR"
              }
            }
          ]
        }
      },
      "filter": {
        "bool": {
          "must": [
            {
              "range": {
                "@timestamp": {
                  "from": "now-86400s",
                  "to": "now"
                }
              }
            }
          ],
          "must_not": [
            {
              "fquery": {
                "query": {
                  "query_string": {
                    "query": "EventType:IrrelevantError"
                  }
                },
                "_cache": true
              }
            }
          ]
        }
      }
    }
  },
  "size": 500
}
```

ElasticSearch query-wise is very feature-rich, so it takes a lot of work to represent it all in builder, so if you are missing a feature, contact me, or add it your self, and i'l be shure to merge it, when requested.
