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
        public async Task TestNoProvidedCredentials()
        {
            var osuClient = new OsuClient();
            try
            {
                await osuClient.LoginAsync();
                Assert.Fail();
            }
            catch (InvalidOsuClientCredentialsException)
            {
                Assert.Pass();
            }
        }
        
        [Test]
        public async Task TestEmptyLoginCredentials()
        {
            var osuClientCredentials = new OsuClientCredentials();
            var osuClient = new OsuClient(osuClientCredentials);
            try
            {
                await osuClient.LoginAsync();
                Assert.Fail();
            }
            catch (InvalidOsuClientCredentialsException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task TestEmptyPassedLoginCredentials()
        {
            var clientId = string.Empty;
            var clientSecret = string.Empty;
            var osuClientCredentials = new OsuClientCredentials(clientId, clientSecret);
            var osuClient = new OsuClient(osuClientCredentials);
            try
            {
                await osuClient.LoginAsync();
                Assert.Fail();
            }
            catch (InvalidOsuClientCredentialsException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task TestValidLoginCredentials()
        {
            var osuClientCredentials = new OsuClientCredentials(ValidClientId, ValidClientSecret);
            var osuClient = new OsuClient(osuClientCredentials);
            await osuClient.LoginAsync();
        }
    }
}
