﻿using System;
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

        public async Task<OsuClientLoginData> LoginAsync()
        {
            var requestBody = CreateRequestBodyForLogin();
            var responseMessage = await _httpClient.PostAsync(Endpoints.Token, requestBody);
            var response = await responseMessage.Content.ReadAsStringAsync();
            _loginData = JsonConvert.DeserializeObject<OsuClientLoginData>(response);
            return _loginData;
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
            return await beatmapRequest.QueueAsync(_httpClient);
        }
    }
}