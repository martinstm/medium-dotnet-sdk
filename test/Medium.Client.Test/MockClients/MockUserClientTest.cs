﻿using FluentAssertions;
using Medium.Client.MockClients;
using System.Threading.Tasks;
using Xunit;

namespace Medium.Client.Test.MockClients
{
    public class MockUserClientTest
    {
        private readonly Context _context;

        public MockUserClientTest()
        {
            _context = new Context();
        }

        [Fact]
        public async Task GetInfoByIdAsync_SuccessAsync()
        {
            MockUserClient usersClient = new MockUserClient(_context);

            var result = await usersClient.GetInfoByIdAsync("");

            Assert.NotNull(result);
            result.Should().BeEquivalentTo(_context.User);
        }
    }
}
