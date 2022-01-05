using System;
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
        private OsuClientLoginData _loginData;

        public OsuClient(OsuClientCredentials osuClientCredentials = null)
        {
            _osuClientCredentials = osuClientCredentials;
        }

        public async Task LoginAsync()
        {
            var requestBody = CreateRequestBodyForLogin();
            var responseMessage = await _httpClient.PostAsync(Endpoints.Token, requestBody);
            var response = await responseMessage.Content.ReadAsStringAsync();
            _loginData = JsonConvert.DeserializeObject<OsuClientLoginData>(response);
        }

        private StringContent CreateRequestBodyForLogin()
        {
            if (_osuClientCredentials == null) throw new InvalidOsuClientCredentialsException();
            var clientSerialized = JsonConvert.SerializeObject(_osuClientCredentials);
            return new StringContent(clientSerialized, Encoding.UTF8, "application/json");
        }

        public async Task<Beatmap> GetBeatmapAsync(string beatmapId)
        {
            if (_loginData == null)
                throw new InvalidOperationException("Please call LoginAsync before making a request");

            var beatmapRequest = new BeatmapRequest(_loginData, beatmapId);
            return await beatmapRequest.QueueAsync(this, _httpClient);
        }

        public async Task<BeatmapCompact[]> GetBeatmapsAsync(string[] beatmapIds)
        {
            if (_loginData == null)
                throw new InvalidOperationException("Please call LoginAsync before making a request");

            var beatmapsRequest = new BeatmapsRequest(_loginData, beatmapIds);
            return (await beatmapsRequest.QueueAsync(this, _httpClient)).Beatmaps;
        }

        public async Task<Beatmapset> GetBeatmapsetAsync(string beatmapsetId)
        {
            if (_loginData == null)
                throw new InvalidOperationException("Please call LoginAsync before making a request");

            var beatmapsetRequest = new BeatmapsetRequest(_loginData, beatmapsetId);
            return await beatmapsetRequest.QueueAsync(this, _httpClient);
        }

        public async Task<BeatmapScore[]> GetBeatmapScoresAsync(string beatmapId, GameMode gameMode)
        {
            if (_loginData == null)
                throw new InvalidOperationException("Please call LoginAsync before making a request");

            var beatmapScoresRequest = new BeatmapScoresRequest(_loginData, beatmapId, gameMode);
            return (await beatmapScoresRequest.QueueAsync(this, _httpClient)).Scores;
        }

        public async Task<Rankings> GetRankingsAsync(GameMode gameMode, RankingType rankingType)
        {
            if (_loginData == null)
                throw new InvalidOperationException("Please call LoginAsync before making a request");

            var rankingsRequest = new RankingsRequest(_loginData, gameMode, rankingType);
            return await rankingsRequest.QueueAsync(this, _httpClient);
        }
    }
}