using System.Runtime.Serialization;

namespace Medium.Domain.Enums
{
    /// <summary>
    /// Types of getting the feed information.
    /// </summary>
    public enum FeedMode
    {
        [EnumMember(Value = "hot")]
        HOT,
        [EnumMember(Value = "new")]
        NEW,
        [EnumMember(Value = "top_year")]
        TOP_YEAR,
        [EnumMember(Value = "top_month")]
        TOP_MONTH,
        [EnumMember(Value = "top_week")]
        TOP_WEEK,
        [EnumMember(Value = "top_all_time")]
        TOP_ALL_TIME
    }
}
