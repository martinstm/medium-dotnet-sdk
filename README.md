[![NuGet](https://img.shields.io/badge/NuGet-blue?logo=NuGet)](https://www.nuget.org/packages/Medium.Client) 
![Version](https://img.shields.io/badge/dynamic/json?label=Version&query=data%5B0%5D.version&url=https%3A%2F%2Fazuresearch-usnc.nuget.org%2Fquery%3Fq%3Dpackageid%3Amedium.client)
![Downloads](https://img.shields.io/badge/dynamic/json?label=Downloads&query=data%5B0%5D.totalDownloads&url=https%3A%2F%2Fazuresearch-usnc.nuget.org%2Fquery%3Fq%3Dpackageid%3Amedium.client)


# Unofficial Medium API .NET SDK

This SDK was developed based on [Unofficial Medium API](https://mediumapi.com/). 

### Presentation Video

[![Watch the video](https://img.youtube.com/vi/gBCho5itKDI/hqdefault.jpg)](https://www.youtube.com/embed/gBCho5itKDI)

### Demonstration Video

[![Watch the video](https://img.youtube.com/vi/jAWJFdFEqVQ/hqdefault.jpg)](https://www.youtube.com/embed/jAWJFdFEqVQ)

## Installation

Install the package from NuGet.org [Medium.Client](https://www.nuget.org/packages/Medium.Client/).

## Assumptions

You need to have a Rapid API account and subscribe to the Medium API. 
Follow the steps from the official documentation [here](https://mediumapi.com/#:~:text=How%20can%20I,Steps%3A).

## Configuration

After installing the NuGet package in your project you just need to use the following extension method to add the medium client interfaces to your service collection.

```csharp
services.AddMediumClient();
```

Once you have the API Key from Rapid API, you just need to add it in the following variable in your settings file or as an environment variable.

```json
{
    "Medium": {
        "ApiKey": "your-key"
    }
}
```

## Supported API endpoints

[API Reference](https://docs.mediumapi.com/)

All the existing endpoints are supported by this SDK. 
There are some additional features to simplify the API calls. For example, the API provides an endpoint to get the user info based on the user identifier. This SDK has an additional method to get this info but is based on a username. This avoids having 2 method calls. However, in reality, the SDK will make that 2 API calls.

```csharp
// 2 method calls
var userId = await _mediumClient.Users.GetIdByUsernameAsync("username");
var userInfo = await _mediumClient.Users.GetInfoByIdAsync(userId);

// 1 method call
var userInfo2 = await _mediumClient.Users.GetInfoByUsernameAsync("username");
```

## How to use it?

In your class, you have 2 options to use the Medium client functionalities.

- Option 1 (using the main IMediumClient interface)

```csharp
public class MyService
{
    private readonly IMediumClient _mediumClient;

    public Worker(IMediumClient mediumClient)
    {
        _mediumClient = mediumClient;
    }

    public async Task ExecuteAsync()
    {
        var user = await _mediumClient.Users.GetListsByUserIdAsync("user-id");
        var article = await _mediumClient.Articles.GetResponsesAsync("article-id");
    }
}
```

- Option 2 (using the specific interface)

```csharp
public class MyService
{
    private readonly IUserClient _userClient;

    public Worker(IUserClient userClient)
    {
        _userClient = userClient;
    }

    public async Task ExecuteAsync()
    {
        var user = await _userClient.GetListsByUserIdAsync("user-id");
    }
}
```

## How to use the default retry policy?

```
services.AddMediumClient(defaultRetryPolicy: true);
```

Retry Policy definition: Handle transient HTTP errors and NotFound status code. There will be 5 retries with a decorrelated  Jitter backoff. 

## How to use a custom retry policy?

```
services.AddMediumClient()
    .WithRetryPolicy(m =>
    {
        // your retry logic here
    });
```


## Roadmap :airplane:

- Add in memory mock client implementation to simplify the development. With this, we can try the SDK without having Rapid API access.
- .NET 8 upgrade


## Give me a star if you like it :star:



## License

[MIT](https://choosealicense.com/licenses/mit/)
