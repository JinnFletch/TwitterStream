namespace JinnDev.Twitter.Data.Entities
{
    public record TweetEntity
    {
        public string? Id { get; set; }
        public string? Content { get; set; }
        public string? Hashtags { get; set; }
    }
}