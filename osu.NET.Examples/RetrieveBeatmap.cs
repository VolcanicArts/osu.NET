using volcanicarts.osu.NET.Client;

var clientId = string.Empty; // your client id here
var clientSecret = string.Empty; // your client secret here
var osuClientCredentials = new OsuClientCredentials(clientId, clientSecret);

var osuClient = new OsuClient(osuClientCredentials);
await osuClient.LoginAsync();

var beatmapId = string.Empty; // your beatmap Id here

// method one
var beatmapOne = await osuClient.GetBeatmapAsync(beatmapId);
if (beatmapOne != null)
{
    Console.WriteLine(beatmapOne.Id);
}

// method two
if (osuClient.TryGetBeatmap(beatmapId, out var beatmapTwo))
{
    Console.WriteLine(beatmapTwo.Id);
}