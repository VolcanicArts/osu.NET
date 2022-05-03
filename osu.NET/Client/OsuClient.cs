// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using volcanicarts.osu.NET.Requests;
using volcanicarts.osu.NET.Requests.Osu.API;
using volcanicarts.osu.NET.Requests.Osu.Login;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Client;

/// <summary>
/// The client class to interface with osu!api V2
/// </summary>
public class OsuClient
{
    private readonly OsuClientCredentials osuClientCredentials;
    internal OsuClientLoginData? loginData;

    public OsuClient(OsuClientCredentials osuClientCredentials)
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

    /// <summary>
    /// A synchronous method of retrieving multiple beatmaps from the API
    /// </summary>
    /// <param name="beatmapIds">The beatmap Ids of the beatmaps you want to retrieve</param>
    /// <param name="beatmaps">The resulting <see cref="BeatmapCompact"/> list of the query</param>
    /// <returns>True if the all beatmap Ids were resolved successfully, false if not</returns>
    public bool TryGetBeatmaps(IReadOnlyList<string> beatmapIds, out IReadOnlyList<BeatmapCompact> beatmaps)
    {
        beatmaps = GetBeatmapsAsync(beatmapIds).Result;
        foreach (var beatmapId in beatmapIds)
        {
            if (beatmaps.All(beatmap => beatmap.Id.ToString() != beatmapId)) return false;
        }

        return true;
    }

    /// <summary>
    /// An asynchronous method of retrieving multiple beatmaps from the API
    /// </summary>
    /// <param name="beatmapIds">The beatmap Ids of the beatmaps you want to retrieve</param>
    /// <returns>A Task containing a <see cref="BeatmapCompact"/> list</returns>
    public async Task<IReadOnlyList<BeatmapCompact>> GetBeatmapsAsync(IReadOnlyList<string> beatmapIds)
    {
        AssertLoginData();

        var beatmapsRequest = new BeatmapsRequest(this, beatmapIds);
        var beatmapsArray = await beatmapsRequest.PerformAsync();
        return beatmapsArray!.Beatmaps;
    }

    /// <summary>
    /// A synchronous method of retrieving a beatmapset from the API
    /// </summary>
    /// <param name="beatmapsetId">The beatmapset Id of the beatmapset you want to retrieve</param>
    /// <param name="beatmapset">The resulting <see cref="Beatmapset"/> of the query</param>
    /// <returns>True if the beatmapset exists, false if not</returns>
    public bool TryGetBeatmapset(string beatmapsetId, out Beatmapset? beatmapset)
    {
        beatmapset = GetBeatmapsetAsync(beatmapsetId).Result;
        return beatmapset != null;
    }
    
    /// <summary>
    /// An asynchronous method of retrieving a beatmapset from the API
    /// </summary>
    /// <param name="beatmapsetId">The beatmapset Id of the beatmapset you want to retrieve</param>
    /// <returns>A Task containing a possibly null <see cref="Beatmapset"/></returns>
    public async Task<Beatmapset?> GetBeatmapsetAsync(string beatmapsetId)
    {
        AssertLoginData();

        var beatmapsetRequest = new BeatmapsetRequest(this, beatmapsetId);
        return await beatmapsetRequest.PerformAsync();
    }

    /// <summary>
    /// A synchronous method of retrieving a beatmap score from the API
    /// </summary>
    /// <param name="beatmapId">The beatmap Id of the beatmap scores you want to retrieve</param>
    /// <param name="gameMode">The game mode of the beatmap score you want to retrieve</param>
    /// <param name="beatmapScores">The resulting possibly null <see cref="BeatmapScore"/> list of the query</param>
    /// <returns>True if the beatmap score exists, false if not</returns>
    public bool TryGetBeatmapScores(string beatmapId, GameMode gameMode, out IReadOnlyList<BeatmapScore>? beatmapScores)
    {
        beatmapScores = GetBeatmapScoresAsync(beatmapId, gameMode).Result;
        return beatmapScores != null;
    }

    /// <summary>
    /// An asynchronous method of retrieving a beatmap score from the API
    /// </summary>
    /// <param name="beatmapId">The beatmap Id of the beatmap scores you want to retrieve</param>
    /// <param name="gameMode">The game mode of the beatmap score you want to retrieve</param>
    /// <returns>A Task containing a possibly null <see cref="BeatmapScore"/> list</returns>
    public async Task<IReadOnlyList<BeatmapScore>?> GetBeatmapScoresAsync(string beatmapId, GameMode gameMode)
    {
        AssertLoginData();

        var beatmapScoresRequest = new BeatmapScoresRequest(this, beatmapId, gameMode);
        var scoresArray = await beatmapScoresRequest.PerformAsync();
        return scoresArray?.Scores;
    }

    /// <summary>
    /// A synchronous method of retrieving rankings from the API
    /// </summary>
    /// <param name="gameMode">The game mode of the rankings you want to retrieve</param>
    /// <param name="rankingType">The rankingType of the rankings you want to retrieve of the query</param>
    /// <param name="rankings">A possibly null <see cref="Rankings"/> object</param>
    /// <returns>True if the rankings exists, false if not</returns>
    public bool TryGetRankings(GameMode gameMode, RankingType rankingType, out Rankings? rankings)
    {
        rankings = GetRankingsAsync(gameMode, rankingType).Result;
        return rankings != null;
    }

    /// <summary>
    /// An asynchronous method of retrieving rankings from the API
    /// </summary>
    /// <param name="gameMode">The game mode of the rankings you want to retrieve</param>
    /// <param name="rankingType">The ranking type of the rankings you want to retrieve</param>
    /// <returns>A Task containing a possibly null <see cref="Rankings"/> object</returns>
    public async Task<Rankings?> GetRankingsAsync(GameMode gameMode, RankingType rankingType)
    {
        AssertLoginData();

        var rankingsRequest = new RankingsRequest(this, gameMode, rankingType);
        return await rankingsRequest.PerformAsync();
    }

    public async Task<User?> GetUserAsync(string userId, GameMode mode, UserLookup lookup = default)
    {
        AssertLoginData();
        
        var request = new UserModeRequest(this, userId, mode, lookup);
        return await request.PerformAsync();
    }

    public async Task<User?> GetUserAsync(string userId, UserLookup lookup = default)
    {
        AssertLoginData();

        var request = new UserRequest(this, userId, lookup);
        return await request.PerformAsync();
    }
}