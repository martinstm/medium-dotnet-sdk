using Medium.Domain.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Medium.Domain.Article
{
    public sealed class ArticleInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }

        [JsonProperty("claps")]
        public int Claps { get; set; }

        [JsonProperty("last_modified_at")]
        public DateTime LastModifiedDate { get; set; }

        [JsonProperty("published_at")]
        public DateTime PublishedDate { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("publication_id")]
        public string PublicationId { get; set; }

        [JsonProperty("word_count")]
        public int WordCount { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("reading_time")]
        public double ReadingTime { get; set; }

        [JsonProperty("responses_count")]
        public int ResponsesCount { get; set; }

        [JsonProperty("voters")]
        public int Voters { get; set; }

        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("topics")]
        public IEnumerable<string> Topics { get; set; }

        [JsonProperty("author")]
        public string AuthorId { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }
    }
}
