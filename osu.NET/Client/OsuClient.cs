// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using volcanicarts.osu.NET.Requests;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Client;

/// <summary>
/// The client class to interface with osu!api V2
/// </summary>
public class OsuClient
{
    private readonly OsuClientCredentials osuClientCredentials;
    internal OsuClientLoginData? loginData;

    public OsuClient(OsuClientCredentials osuClientCredentials = null!)
    {
        this.osuClientCredentials = osuClientCredentials;
    }

    /// <summary>
    /// Attempts to login using the provided <see cref="OsuClientCredentials"/> on construction
    /// </summary>
    /// <exception cref="InvalidCredentialException">Thrown when the client credentials are invalid</exception>
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

    /// <summary>
    /// A synchronous method of retrieving a beatmap from the API
    /// </summary>
    /// <param name="beatmapId">The beatmap Id of the beatmap you want to retrieve</param>
    /// <param name="beatmap">The resulting <see cref="Beatmap"/> of the query</param>
    /// <returns>True if the beatmap exists, false if not</returns>
    public bool TryGetBeatmap(string beatmapId, out Beatmap? beatmap)
    {
        beatmap = GetBeatmapAsync(beatmapId).Result;
        return beatmap != null;
    }

    /// <summary>
    /// An asynchronous method of retrieving a beatmap from the API
    /// </summary>
    /// <param name="beatmapId">The beatmap Id of the beatmap you want to retrieve</param>
    /// <returns>A Task containing a possibly null <see cref="Beatmap"/></returns>
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