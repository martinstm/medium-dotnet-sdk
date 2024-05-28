using Medium.Domain.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Medium.Domain.User
{
    public sealed class UserPublications
    {
        [JsonProperty("id")]
        public string UserId { get; set; }

        [JsonProperty("publications")]
        public Publications Publications { get; set; }
    }

    public sealed class Publications
    {
        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("admin_in")]
        public IEnumerable<string> AdminIn { get; set; }
        
        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("writer_in")]
        public IEnumerable<string> WriteIn { get; set; }
    }
}
