using System;
using System.Threading.Tasks;
using NUnit.Framework;
using volcanicarts.osu.NET.Client;

namespace osu.NET.Tests
{
    public class TestBeatmapsRequest
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
        public async Task TestNoBeatmaps()
        {
            var beatmaps = await osuClient.GetBeatmapsAsync(Array.Empty<string>());
            
            Assert.NotNull(beatmaps);
            Assert.Zero(beatmaps.Count);
        }

        [Test]
        public async Task TestOneBeatmaps()
        {
            var beatmapIds = new[] { "569636" };
            var beatmaps = await osuClient.GetBeatmapsAsync(beatmapIds);
            
            Assert.NotNull(beatmaps);
            Assert.That(beatmaps.Count == 1);
            Assert.That(beatmaps[0].Id.ToString().Equals(beatmapIds[0]));
        }

        [Test]
        public async Task TestMaximumOfSameBeatmap()
        {
            const int size = 50;

            var beatmapIds = new string[size];
            for (var i = 0; i < size; i++) beatmapIds[i] = "569636";

            var beatmaps = await osuClient.GetBeatmapsAsync(beatmapIds);
            
            Assert.NotNull(beatmaps);
            Assert.That(beatmaps.Count == 1);
            Assert.That(beatmaps[0].Id.ToString().Equals(beatmapIds[0]));
        }

        [Test]
        public Task TestTooManyBeatmaps()
        {
            const int size = 51;
            Assert.ThrowsAsync<ArgumentException>(async () => await osuClient.GetBeatmapsAsync(new string[size]));
            return Task.CompletedTask;
        }
    }
}