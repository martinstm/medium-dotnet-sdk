using Medium.Domain.User;

namespace Medium.Client.MockClients
{
    internal class Context
    {
        public UserInfo User { get; }

        public Context()
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
