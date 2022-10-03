using JinnDev.Twitter.Data.Entities;

namespace JinnDev.Twitter.Data.Core
{
    public interface ITweetRepo
    {
        Task AddTweet(TweetEntity tweet);
        Task<List<string>> GetTopHashtags();
        Task<int> GetTweetCount();
    }
}