namespace JinnDev.Twitter.SDK
{
    /// <summary>
    /// Mockable SDK interface to set the contract of consuming the TwitterStreamController API endpoints
    /// </summary>
    public interface ITwitterSDK
    {
        /// <summary>
        /// Contacts the Jinn Studios Twitter API to retrieve the Count.
        /// </summary>
        /// <returns>The running total of how many tweets have been processed by the API</returns>
        Task<int> GetCount();

        /// <summary>
        /// Contacts the Jinn Studios Twitter API to retrieve the Top 10 Hashtags.
        /// </summary>
        /// <returns>a list of strings of the top 10 hashtags trending on twitter</returns>
        Task<List<string>> GetTopHashtags();
    }
}