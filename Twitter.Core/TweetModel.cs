namespace JinnDev.Twitter.Models
{
    public record TweetModel
    {
        public string TweetID { get; init; }
        public string Content { get; init; }

        public TweetModel(string tweetID, string content)
        {
            TweetID = tweetID;
            Content = content;
        }
    }
}