#pragma warning disable IDE1006 // DTO's don't follow the same naming conventions
namespace JinnDev.Twitter.API
{
    public record TweetDataDTO
    {
        public TweetDTO? data { get; set; }
    }
}