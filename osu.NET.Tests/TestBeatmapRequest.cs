using System;
using System.Threading.Tasks;
using NUnit.Framework;
using volcanicarts.osu.NET.Client;

namespace osu.NET.Tests
{
    public class TestBeatmapRequest
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
        public async Task TestValidBeatmapIdRequest()
        {
            const string beatmapId = "569636";
            var beatmap = await osuClient.GetBeatmapAsync(beatmapId);
            
            Assert.NotNull(beatmap);
            Assert.That(beatmap.Id.ToString(), Is.EqualTo(beatmapId));
        }

        [Test]
        public async Task TestInvalidBeatmapIdRequest()
        {
            const string beatmapId = "123456789";
            var beatmap = await osuClient.GetBeatmapAsync(beatmapId);
            
            Assert.Null(beatmap);
        }
    }
}