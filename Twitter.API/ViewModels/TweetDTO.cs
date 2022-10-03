#pragma warning disable IDE1006 // DTO's don't follow the same naming conventions
namespace JinnDev.Twitter.API
{
    public record TweetDTO
    {
        public string? id { get; set; }
        public List<string>? edit_history_tweet_ids { get; set; }
        public string? text { get; set; }
    }
}