// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using volcanicarts.osu.NET.Requests;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Client;

public class OsuClient
{
    private readonly OsuClientCredentials osuClientCredentials;
    internal OsuClientLoginData? loginData;

    public OsuClient(OsuClientCredentials osuClientCredentials = null!)
    {
        this.osuClientCredentials = osuClientCredentials;
    }

    public async Task LoginAsync()
    {
        var loginRequest = new LoginWebRequest(osuClientCredentials);
        var response = await loginRequest.PerformAsync();
        loginData = response ??
                    throw new InvalidCredentialException("Unable to deserialize login data. Provided client credentials are invalid");
    }

    private void AssertLoginData()
    {
        if (loginData == null) throw new InvalidOperationException("Please call LoginAsync before making a request");
    }

    public async Task<Beatmap?> GetBeatmapAsync(string beatmapId)
    {
        AssertLoginData();

        var beatmapRequest = new BeatmapRequest(this, beatmapId);
        return await beatmapRequest.PerformAsync();
    }

    public async Task<IReadOnlyList<BeatmapCompact>?> GetBeatmapsAsync(string[] beatmapIds)
    {
        AssertLoginData();

        var beatmapsRequest = new BeatmapsRequest(this, beatmapIds);
        var beatmapsetsArray = await beatmapsRequest.PerformAsync();
        return beatmapsetsArray?.Beatmaps;
    }

    public async Task<Beatmapset?> GetBeatmapsetAsync(string beatmapsetId)
    {
        AssertLoginData();

        var beatmapsetRequest = new BeatmapsetRequest(this, beatmapsetId);
        return await beatmapsetRequest.PerformAsync();
    }

    public async Task<IReadOnlyList<BeatmapScore>?> GetBeatmapScoresAsync(string beatmapId, GameMode gameMode)
    {
        AssertLoginData();

        var beatmapScoresRequest = new BeatmapScoresRequest(this, beatmapId, gameMode);
        var scoresArray = await beatmapScoresRequest.PerformAsync();
        return scoresArray?.Scores;
    }

    public async Task<Rankings?> GetRankingsAsync(GameMode gameMode, RankingType rankingType)
    {
        AssertLoginData();

        var rankingsRequest = new RankingsRequest(this, gameMode, rankingType);
        return await rankingsRequest.PerformAsync();
    }
}