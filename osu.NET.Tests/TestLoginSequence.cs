using System;
using System.Threading.Tasks;
using NUnit.Framework;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Exceptions;

namespace osu.NET.Tests
{
    public class TestLoginSequence
    {
        private string ValidClientId;
        private string ValidClientSecret;

        [SetUp]
        public void SetUp()
        {
            ValidClientId = Environment.GetEnvironmentVariable("clientId");
            ValidClientSecret = Environment.GetEnvironmentVariable("clientSecret");
        }

        [Test]
        public Task TestNoProvidedCredentials()
        {
            var osuClient = new OsuClient();
            
            Assert.ThrowsAsync<InvalidOsuClientCredentialsException>(async () => await osuClient.LoginAsync());
            
            return Task.CompletedTask;
        }


        [Test]
        public Task TestEmptyLoginCredentials()
        {
            var osuClientCredentials = new OsuClientCredentials();
            var osuClient = new OsuClient(osuClientCredentials);
            
            Assert.ThrowsAsync<InvalidOsuClientCredentialsException>(async () => await osuClient.LoginAsync());
            
            return Task.CompletedTask;
        }

        [Test]
        public Task TestEmptyPassedLoginCredentials()
        {
            var clientId = string.Empty;
            var clientSecret = string.Empty;
            var osuClientCredentials = new OsuClientCredentials(clientId, clientSecret);
            var osuClient = new OsuClient(osuClientCredentials);
            
            Assert.ThrowsAsync<InvalidOsuClientCredentialsException>(async () => await osuClient.LoginAsync());
            
            return Task.CompletedTask;
        }

        [Test]
        public Task TestInvalidLoginCredentials()
        {
            const string clientId = "123456789";
            const string clientSecret = "123456789";
            var osuClientCredentials = new OsuClientCredentials(clientId, clientSecret);
            var osuClient = new OsuClient(osuClientCredentials);
            
            Assert.ThrowsAsync<InvalidOsuClientCredentialsException>(async () => await osuClient.LoginAsync());
            
            return Task.CompletedTask;
        }

        [Test]
        public Task TestValidLoginCredentials()
        {
            var osuClientCredentials = new OsuClientCredentials(ValidClientId, ValidClientSecret);
            var osuClient = new OsuClient(osuClientCredentials);
            
            Assert.DoesNotThrowAsync(async () => await osuClient.LoginAsync());
            
            return Task.CompletedTask;
        }
    }
}