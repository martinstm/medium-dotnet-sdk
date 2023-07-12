using Medium.Domain.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Medium.Domain.User
{
    public sealed class UserPublications
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("publications")]
        public IEnumerable<string> Publications { get; set; }
    }
}
