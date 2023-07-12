# Unofficial Medium API .NET SDK

This SDK was developed based on [Unofficial Medium API](https://mediumapi.com/). 

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

## Roadmap :airplane:

- Add in memory mock client implementation to simplify the development. With this, we can try the SDK without having Rapid API access.

- Add retry policy.


## Give me a star if you like it :star:



## License

[MIT](https://choosealicense.com/licenses/mit/)
