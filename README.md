# TwitterStream

A requested sample of a basic API with a few basic requirements; to connect to the Twitter 1% stream and evaluate the incoming tweet data.

# Solution Setup

This sln is configured with the "Solution Items" at the top of the configuration, and as the `Twitter.API` project as the first actual project.  That will make it the startup project for anybody on a fresh clone.

# Required Configuration

The `Twitter.API` project has one environment variable: `TwitterToken`.  This is essentially empty, but uses the ASP.NET User Secrets file, with a GUID of `d1a24467-f2f5-4095-aea4-06e0aa0a7b4b`.

You can configure your User Secrets for this project by right-clicking the `Twitter.API` project and selecting "Manage User Secrets".  Copy the structure of the `appsettings.json` file, and fill in your key.

# API Documentation

By default, the local LaunchSettings of this project are configured to the base URL: https://localhost:65520

There are two API Endpoints defined:

[GET] api/count
    - Contacts this "Twitter Stream API" to retrieve the Count of tweets this API has processed since startup.

[GET] api/tophashtags
    - Contacts this "Twitter Stream API" to retrieve a list of the Top 10 hashtags processed by this API since startup.

# Architecture

This solution was architected with a number of principles and patterns.  

Foremost, `Separation of Concerns`, as discussed in my FreeCodeCamp video: https://www.youtube.com/watch?v=2rlcMq2sgnk

Second, and just as important: `Imperative Shell, Functional Core`.  Another way I put this is; Separating the Procedural code and Guard Clauses away from the "Conditional Transformations".  This allows you to easily Unit Test the `Functional Core`, and just as easily determine how to write [automated]* integration tests.

# Other Resources

View more of my videos here: https://www.youtube.com/c/Techlahoma/search?query=Fletch and here: https://www.youtube.com/channel/UC2X0eu3YE5S-cYsQSwlGrWQ/videos