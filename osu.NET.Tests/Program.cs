using System;
using System.Threading.Tasks;
using volcanicarts.osu.NET.Client;

namespace volcanicarts.osu.NET.Tests
{
    internal static class Program
    {
        private static OsuClient _osuClient;

        private static async Task Main(string[] args)
        {
            const string clientId = "";
            const string clientSecret = "";

            var osuClientCredentials = new OsuClientCredentials(clientId, clientSecret);
            _osuClient = new OsuClient(osuClientCredentials);

            await _osuClient.LoginAsync();
            var beatmap = await _osuClient.GetBeatmapAsync("221777");
            var beatmaps = await _osuClient.GetBeatmapsAsync(new[] {"221777", "229180"});
            Console.WriteLine(beatmaps.Length);
        }
    }
}