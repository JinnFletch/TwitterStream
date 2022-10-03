using System.Text.Json;

namespace JinnDev.Twitter.SDK
{
    /// <summary>
    /// SDK for consuming the TwitterStreamController's API Endpoints
    /// </summary>
    public class TwitterSDK : ITwitterSDK
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Construct the SDK with your favorite HttpClient!
        /// </summary>
        /// <param name="client">HTTP Client with a required configuration of the BaseAddress</param>
        public TwitterSDK(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Contacts the Jinn Studios Twitter API to retrieve the Top 10 Hashtags.
        /// </summary>
        /// <returns>a list of strings of the top 10 hashtags trending on twitter</returns>
        public async Task<List<string>> GetTopHashtags()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/tophashtags");
            var result = await _client.SendAsync(request);
            var data = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<string>>(data)!;
        }

        /// <summary>
        /// Contacts the Jinn Studios Twitter API to retrieve the Count.
        /// </summary>
        /// <returns>The running total of how many tweets have been processed by the API</returns>
        public async Task<int> GetCount()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/count");
            var result = await _client.SendAsync(request);
            var data = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<int>(data)!;
        }
    }
}