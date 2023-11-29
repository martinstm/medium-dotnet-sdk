using Medium.Domain.User;

namespace Medium.Client.MockClients
{
    internal class MockContext
    {
        public UserInfo User { get; }

        public MockContext()
        {
            User = GetUser();
        }

        private UserInfo GetUser()
        {
            return new UserInfo
            {
                Id = "12345678",
                Fullname = "User Test",
                Username = "usertest"
            };
        }
    }
}
