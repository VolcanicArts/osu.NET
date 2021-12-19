using System;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Structures
{
    public class Spotlight
    {
        [JsonProperty("end_date")]
        private string _endDate;

        [JsonProperty("start_date")]
        private string _startDate;

        [JsonProperty("id")]
        public long Id;

        [JsonProperty("mode_specific")]
        public bool ModeSpecific;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("participant_count")]
        public int ParticipantCount;

        [JsonProperty("type")]
        public string Type;

        [JsonIgnore]
        public DateTime EndDate => Parser.ParseOsuTimestamp(_endDate);

        [JsonIgnore]
        public DateTime StartDate => Parser.ParseOsuTimestamp(_startDate);
    }
}