using Medium.Client.Abstractions;

namespace Medium.Client
{
    public class MediumClient : IMediumClient
    {
        public IUserClient Users { get; }
        public IArticleClient Articles { get; }
        public IPublicationClient Publications { get; }
        public IListClient Lists { get; }
        public IPlatformClient Platform { get; }
        public ISearchClient Search { get; }

        public MediumClient(IUserClient userClient, IArticleClient articles, IPublicationClient publications,
                            IListClient listClient, IPlatformClient platformClient, ISearchClient searchClient)
        {
            Users = userClient;
            Articles = articles;
            Publications = publications;
            Lists = listClient;
            Platform = platformClient;
            Search = searchClient;
        }
    }
}