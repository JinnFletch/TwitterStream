using JinnDev.Twitter.Core;
using Microsoft.AspNetCore.Mvc;

namespace JinnDev.Twitter.API
{
    [Route("api")]
    public class TwitterStreamController : ControllerBase
    {
        private readonly ITweetService _svc;

        public TwitterStreamController(ITweetService svc)
        {
            _svc = svc;
        }

        [HttpGet("count")]
        public async Task<int> GetTweetCount()
            => await _svc.GetTweetCount();

        [HttpGet("tophashtags")]
        public async Task<List<string>> GetTopHashtags()
            => await _svc.GetTopHashtags();
    }
}