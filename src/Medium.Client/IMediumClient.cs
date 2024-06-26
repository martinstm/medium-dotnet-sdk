﻿using Medium.Client.Abstractions;

namespace Medium.Client
{
    /// <summary>
    /// Interface to provide the multiple client methods.
    /// </summary>
    public interface IMediumClient
    {
        IUserClient Users { get; }
        IArticleClient Articles { get; }
        IPublicationClient Publications { get; }
        IListClient Lists { get; }
        IPlatformClient Platform { get; }
        ISearchClient Search { get; }
    }
}