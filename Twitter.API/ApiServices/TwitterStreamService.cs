using JinnDev.Twitter.Core;
using JinnDev.Twitter.Models;
using JinnDev.Utilities;
using System.Text.Json;

namespace JinnDev.Twitter.API
{
    public partial class TwitterStreamService : BackgroundService
    {
        const int TWEET_LEN_X2 = 560;

        private readonly ITweetService _svc;
        private readonly HttpClient _client;
        private readonly string _streamEndpoint;
        private readonly ILogger _logger;

        public TwitterStreamService(ITweetService svc, HttpClient client, string streamEndpoint, ILogger<TwitterStreamService> logger)
        {
            _svc = svc;
            _client = client;
            _streamEndpoint = streamEndpoint;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                try
                {
                    using var response = await _client.GetAsync(_streamEndpoint, HttpCompletionOption.ResponseHeadersRead, stoppingToken);
                    using var responseStream = await response.Content.ReadAsStreamAsync(stoppingToken);
                    using var reader = new StreamReader(responseStream);
                    while (false == reader.EndOfStream)
                    {
                        var maybeTweet = DeserializeTweet(reader.ReadLine());
                        if (null != maybeTweet.Exception)
                            _logger.LogError(maybeTweet.Exception, "Error with Deserialization: {msg}", maybeTweet.Message);
                        else if (false == maybeTweet.HasValue)
                            _logger.LogError("Error with Deserialization: {msg}", maybeTweet.Message);
                        else
                            await _svc.ProcessTweet(maybeTweet.Value);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error with twitter stream");
                }
            }
        }

        public static Maybe<TweetModel> DeserializeTweet(string? line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return Maybe<TweetModel>.None("Line was empty");

            try
            {
                var tweetData = JsonSerializer.Deserialize<TweetDataDTO>(line);
                if (tweetData == null || tweetData.data == null || tweetData.data.text == null || tweetData.data.id == null)
                    return Maybe<TweetModel>.None("Received a line with data, but data was null: " + line.Truncate(TWEET_LEN_X2));

                return Maybe<TweetModel>.Some(new TweetModel(tweetData.data.id, tweetData.data.text));
            }
            catch (Exception ex)
            {
                return Maybe<TweetModel>.None(ex, "Error getting Tweet from Stream: " + line.Truncate(TWEET_LEN_X2));
            }
        }
    }
}