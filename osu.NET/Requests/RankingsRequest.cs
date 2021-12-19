using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Requests
{
    public class RankingsRequest : BaseRequest<Rankings>
    {
        private readonly GameMode _gameMode;
        private readonly RankingType _rankingType;

        public RankingsRequest(OsuClientLoginData loginData, GameMode gameMode, RankingType rankingType) :
            base(loginData)
        {
            _gameMode = gameMode;
            _rankingType = rankingType;
        }

        protected override string RequestUrl =>
            $"{Endpoints.Api}/rankings/{_gameMode.ToString().ToLower()}/{_rankingType.ToString().ToLower()}";
    }
}