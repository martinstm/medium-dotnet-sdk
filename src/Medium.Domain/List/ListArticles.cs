using Medium.Domain.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Medium.Domain.List
{
    public sealed class ListArticles
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("list_articles")]
        public IEnumerable<string> Articles { get; set; }
    }
}
