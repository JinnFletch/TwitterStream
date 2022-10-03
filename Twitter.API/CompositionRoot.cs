using JinnDev.Twitter.Core;
using JinnDev.Twitter.Data;
using JinnDev.Twitter.Data.Core;

namespace JinnDev.Twitter.API
{
    public class CompositionRoot
    {
        public static void Compose(IServiceCollection sc, IConfigurationRoot config)
        {
            sc.AddTransient<ITweetService>(x => new TweetService(x.GetRequiredService<ITweetRepo>()));
            sc.AddTransient<ITweetRepo>(x => new TweetRepo());

            sc.AddHttpClient(nameof(TwitterStreamService), client =>
            {
                var token = config.GetValue<string>("TwitterToken");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
            });

            sc.AddHostedService(x =>
            {
                var factory = x.GetRequiredService<IHttpClientFactory>();
                var client = factory.CreateClient(nameof(TwitterStreamService));
                return new TwitterStreamService(x.GetRequiredService<ITweetService>(), client, x.GetRequiredService<ILogger<TwitterStreamService>>());
            });
        }
    }
}