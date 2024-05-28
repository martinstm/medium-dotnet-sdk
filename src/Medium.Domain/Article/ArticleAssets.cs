using Newtonsoft.Json;
using System.Collections.Generic;

namespace Medium.Domain.Article
{
    public class ArticleAssets
    {
        [JsonProperty("id")]
        public string ArticleId { get; set; }

        [JsonProperty("images")]
        public IEnumerable<string> Images { get; set; }

        [JsonProperty("github_gists")]
        public IEnumerable<string> GithubGists { get; set; }

        /// <summary>
        /// Llist of embedded YouTube videos.
        /// </summary>
        [JsonProperty("youtube")]
        public IEnumerable<YoutubeLink> YoutubeLinks { get; set; }

        /// <summary>
        /// Hyperlinks to other pages.
        /// </summary>
        [JsonProperty("anchors")]
        public IEnumerable<GenericHyperlink> GenericHyperlinks { get; set; }

        [JsonProperty("other_embeds")]
        public Dictionary<string, IEnumerable<OtherEmbed>> OtherEmbeds { get; set; }
    }

    public class YoutubeLink
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("href")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class GenericHyperlink
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("href")]
        public string Url { get; set; }
    }

    public class OtherEmbed
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("href")]
        public string Url { get; set; }
    }
}
