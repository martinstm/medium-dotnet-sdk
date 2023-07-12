using Medium.Domain.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Medium.Domain.Publication
{
    public sealed class PublicationInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tagline")]
        public string TagLine { get; set; }

        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("instagram_username")]
        public string InstagramUsername { get; set; }

        [JsonProperty("facebook_pagename")]
        public string FacebookPageName { get; set; }

        [JsonProperty("twitter_username")]
        public string TwitterUsername { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("creator")]
        public string CreatorId { get; set; }

        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("editors")]
        public IEnumerable<string> Editors { get; set; }
    }
}
