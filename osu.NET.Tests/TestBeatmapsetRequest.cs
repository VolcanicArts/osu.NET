using System;
using System.Threading.Tasks;
using NUnit.Framework;
using volcanicarts.osu.NET.Client;

namespace osu.NET.Tests
{
    public class TestBeatmapsetRequest
    {
        private OsuClient osuClient;
        
        [SetUp]
        public async Task SetUp()
        {
            var clientId = Environment.GetEnvironmentVariable("clientId");
            var clientSecret = Environment.GetEnvironmentVariable("clientSecret");
            var osuClientCredentials = new OsuClientCredentials(clientId, clientSecret);
            osuClient = new OsuClient(osuClientCredentials);
            await osuClient.LoginAsync();
        }

        [Test]
        public async Task TestValidBeatmapsetIdRequest()
        {
            const string beatmapsetId = "236292";
            var beatmapset = await osuClient.GetBeatmapsetAsync(beatmapsetId);
            
            Assert.NotNull(beatmapset);
            Assert.That(beatmapset.Id.ToString(), Is.EqualTo(beatmapsetId));
        }

        [Test]
        public async Task TestInvalidBeatmapsetIdRequest()
        {
            const string beatmapsetId = "123456789";
            var beatmapset = await osuClient.GetBeatmapsetAsync(beatmapsetId);
            
            Assert.Null(beatmapset);
        }
    }
}