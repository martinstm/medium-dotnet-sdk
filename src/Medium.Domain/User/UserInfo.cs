using Medium.Domain.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Medium.Domain.User
{
    public sealed class UserInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("following_count")]
        public int FollowingCount { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("twitter_username")]
        public string TwitterUsername { get; set; }

        [JsonProperty("medium_member_at")]
        public DateTime? MemberCreationDate { get; set; }

        [JsonProperty("is_writer_program_enrolled")]
        public bool IsWriterProgramEnrolled { get; set; }

        [JsonProperty("allow_notes")]
        public bool AllowNotes { get; set; }

        [JsonProperty("is_suspended")]
        public bool IsSuspended { get; set; }

        [JsonConverter(typeof(EmptyObjectToEmptyListConverter<string>))]
        [JsonProperty("top_writer_in")]
        public IEnumerable<string> TopWriterIn { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("bg_image_url")]
        public string BackgroundImageUrl { get; set; }

        [JsonProperty("logo_image_url")]
        public string LogoImageUrl { get; set; }

        [JsonProperty("has_list")]
        public bool HasList { get; set; }

        [JsonProperty("is_book_author")]
        public bool IsBookAuthor { get; set; }

        [JsonProperty("tipping_link")]
        public string TippingLink { get; set; }

        [JsonProperty("publication_following_count")]
        public int PublicationFollowingCount { get; set; }
    }
}