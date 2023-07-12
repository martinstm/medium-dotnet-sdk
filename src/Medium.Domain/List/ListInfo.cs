using Newtonsoft.Json;
using System;

namespace Medium.Domain.List
{
    public sealed class ListInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Number of articles in the list.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("author")]
        public string CreatorId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Date of the last item inserted in the list.
        /// </summary>
        [JsonProperty("last_item_inserted_at")]
        public DateTime LastInsertionDate { get; set; }

        [JsonProperty("claps")]
        public int Claps { get; set; }

        [JsonProperty("responses_count")]
        public int ResponsesCount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("voters")]
        public int Voters { get; set; }

        [JsonProperty("thumbnail")]
        public string ThumbnailUrl { get; set; }
    }
}
