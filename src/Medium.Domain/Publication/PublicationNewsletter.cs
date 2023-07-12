using Newtonsoft.Json;

namespace Medium.Domain.Publication
{
    public sealed class PublicationNewsletter
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("subscribers")]
        public int Subscribers { get; set; }
        
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        [JsonProperty("creator_id")]
        public string CreatorId { get; set; }
        
        [JsonProperty("image")]
        public string ImageUrl { get; set; }
    }
}
