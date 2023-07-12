using Newtonsoft.Json;

namespace Medium.Domain.Publication
{
    public sealed class PublicationId
    {
        [JsonProperty("publication_id")]
        public string Id { get; set; }

        /// <summary>
        /// It's a lowercased hyphen-separated unique string alloted to each Medium Publication.
        /// </summary>
        [JsonProperty("publication_slug")]
        public string Slug { get; set; }
    }
}
