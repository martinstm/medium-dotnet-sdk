using Medium.Domain.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Medium.Domain.Platform
{
    public sealed class RecommendedFeed
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("recommended_feed")]
        public IEnumerable<string> RecommendedArticles { get; set; }
    }
}
