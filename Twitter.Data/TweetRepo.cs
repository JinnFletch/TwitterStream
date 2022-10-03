using JinnDev.Twitter.Data.Core;
using JinnDev.Twitter.Data.Entities;
using System.Collections.Concurrent;
using System.Text.Json;

namespace JinnDev.Twitter.Data
{
    public class TweetRepo : ITweetRepo
    {
        private static int _tweetsReceived;
        private static readonly ConcurrentDictionary<string, int> _topHashtags = new();

        public Task AddTweet(TweetEntity tweet)
        {
            Interlocked.Increment(ref _tweetsReceived);
            if (tweet.Hashtags != null)
            {
                var hashtags = JsonSerializer.Deserialize<List<string>>(tweet.Hashtags)!;
                for (var i = 0; i < hashtags.Count; i++)
                    _topHashtags.AddOrUpdate(hashtags[i], 0, (y, z) => z + 1);
            }
            return Task.CompletedTask;
        }

        public Task<List<string>> GetTopHashtags()
            => Task.FromResult(_topHashtags.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key).ToList());

        public Task<int> GetTweetCount()
            => Task.FromResult(_tweetsReceived);
    }
}