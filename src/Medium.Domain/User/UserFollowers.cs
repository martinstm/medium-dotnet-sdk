using Medium.Domain.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Medium.Domain.User
{
    public sealed class UserFollowers
    {
        [JsonProperty("id")]
        public string UserId { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string NextPage { get; set; }
        
        [JsonProperty("total_followers")]
        public int TotalFollowers { get; set; }

        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("followers")]
        public IEnumerable<string> Followers { get; set; }
    }
}
