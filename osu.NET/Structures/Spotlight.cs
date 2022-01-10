using System;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Structures
{
    public class Spotlight
    {
        [JsonProperty("end_date")]
        public string EndDate;

        [JsonProperty("id")]
        public long Id;

        [JsonProperty("mode_specific")]
        public bool ModeSpecific;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("participant_count")]
        public int ParticipantCount;

        [JsonProperty("start_date")]
        public string StartDate;

        [JsonProperty("type")]
        public string Type;

        [JsonIgnore]
        public DateTime EndDateDateTime => Parser.ParseOsuTimestamp(EndDate);

        [JsonIgnore]
        public DateTime StartDateDateTime => Parser.ParseOsuTimestamp(StartDate);
    }
}