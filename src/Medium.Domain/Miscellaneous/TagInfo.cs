using Newtonsoft.Json;

namespace Medium.Domain.Miscellaneous
{
    public sealed class TagInfo
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }
        
        [JsonProperty("latest_authors_count")]
        public int LatestAuthorsCount { get; set; }
        
        [JsonProperty("latest_articles_count")]
        public int LatestArticlesCount { get; set; }

        [JsonProperty("authors_count")]
        public int AuthorsCount { get; set; }

        [JsonProperty("articles_count")]
        public int ArticlesCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }
    }
}
