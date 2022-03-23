﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Exceptions;
using volcanicarts.osu.NET.Requests;
using volcanicarts.osu.NET.Structures;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Client
{
    public class OsuClient
    {
        private readonly HttpClient _httpClient = new();

        private readonly OsuClientCredentials _osuClientCredentials;
        private OsuClientLoginData? _loginData;

        public OsuClient(OsuClientCredentials osuClientCredentials = null!)
        {
            _osuClientCredentials = osuClientCredentials;
        }

        public async Task LoginAsync()
        {
            var requestBody = CreateRequestBodyForLogin();
            var responseMessage = await _httpClient.PostAsync(Endpoints.Token, requestBody);
            var response = await responseMessage.Content.ReadAsStringAsync();
            try
            {
                _loginData = JsonConvert.DeserializeObject<OsuClientLoginData>(response)!;
            }
            catch (JsonReaderException e)
            {
                throw new InvalidOsuClientCredentialsException("Unable to deserialise login data. Provided client credentials are invalid");
            }
        }

        private StringContent CreateRequestBodyForLogin()
        {
            var clientSerialized = JsonConvert.SerializeObject(_osuClientCredentials);
            return new StringContent(clientSerialized, Encoding.UTF8, "application/json");
        }

        private void CheckLoginData()
        {
            if (_loginData == null)
                throw new InvalidOperationException("Please call LoginAsync before making a request");
        }

        public async Task<Beatmap?> GetBeatmapAsync(string beatmapId)
        {
            CheckLoginData();
            var beatmapRequest = new BeatmapRequest(_loginData!, beatmapId);
            return await beatmapRequest.QueueAsync(this, _httpClient);
        }

        public async Task<IReadOnlyList<BeatmapCompact>?> GetBeatmapsAsync(string[] beatmapIds)
        {
            CheckLoginData();
            var beatmapsRequest = new BeatmapsRequest(_loginData!, beatmapIds);
            var beatmapsetsArray = await beatmapsRequest.QueueAsync(this, _httpClient);
            return beatmapsetsArray?.Beatmaps;
        }

        public async Task<Beatmapset?> GetBeatmapsetAsync(string beatmapsetId)
        {
            CheckLoginData();
            var beatmapsetRequest = new BeatmapsetRequest(_loginData!, beatmapsetId);
            return await beatmapsetRequest.QueueAsync(this, _httpClient);
        }

        public async Task<IReadOnlyList<BeatmapScore>?> GetBeatmapScoresAsync(string beatmapId, GameMode gameMode)
        {
            CheckLoginData();
            var beatmapScoresRequest = new BeatmapScoresRequest(_loginData!, beatmapId, gameMode);
            var scoresArray = await beatmapScoresRequest.QueueAsync(this, _httpClient);
            return scoresArray?.Scores;
        }

        public async Task<Rankings?> GetRankingsAsync(GameMode gameMode, RankingType rankingType)
        {
            CheckLoginData();
            var rankingsRequest = new RankingsRequest(_loginData!, gameMode, rankingType);
            return await rankingsRequest.QueueAsync(this, _httpClient);
        }
    }
}