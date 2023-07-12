using Medium.Domain.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Medium.Domain.User
{
    public sealed class UserLists
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("lists")]
        public IEnumerable<string> Lists { get; set; }
    }
}
