using JinnDev.Twitter.Models;

namespace JinnDev.Twitter.Core
{
    public interface ITweetService
    {
        Task ProcessTweet(TweetModel tweet);
        Task<List<string>> GetTopHashtags();
        Task<int> GetTweetCount();
    }
}