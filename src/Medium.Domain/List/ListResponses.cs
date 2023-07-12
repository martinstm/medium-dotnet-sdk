using Medium.Domain.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Medium.Domain.List
{
    public sealed class ListResponses
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("responses")]
        public IEnumerable<string> Responses { get; set; }
    }
}
