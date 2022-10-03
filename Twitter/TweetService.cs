using JinnDev.Twitter.Core;
using JinnDev.Twitter.Models;
using System.Text.Json;
using JinnDev.Twitter.Data.Core;
using JinnDev.Twitter.Data.Entities;

namespace JinnDev.Twitter
{
    public partial class TweetService : ITweetService
    {
        private readonly ITweetRepo _repo;

        public TweetService(ITweetRepo repo)
        {
            _repo = repo;
        }

        public async Task ProcessTweet(TweetModel tweet)
        {
            var hashtags = GetValidHashtags(tweet.Content);
            var tweetEntity = new TweetEntity
            {
                Id = tweet.TweetID,
                Content = tweet.Content,
                Hashtags = JsonSerializer.Serialize(hashtags)
            };
            await _repo.AddTweet(tweetEntity);
        }

        public async Task<List<string>> GetTopHashtags()
            => await _repo.GetTopHashtags();

        public async Task<int> GetTweetCount()
            => await _repo.GetTweetCount();
    }
}