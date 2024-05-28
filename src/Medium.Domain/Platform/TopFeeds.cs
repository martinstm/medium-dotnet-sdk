using Medium.Domain.Enums;
using Medium.Domain.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Domain.Platform
{
    public sealed class TopFeeds
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("mode")]
        public FeedMode Mode { get; set; }

        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("topfeeds")]
        public IEnumerable<string> Feeds { get; set; }
    }
}
