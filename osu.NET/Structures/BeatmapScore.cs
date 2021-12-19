using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Structures
{
    public class BeatmapScores : BaseStructure
    {
        [JsonProperty("scores")]
        public BeatmapScore[] Scores;
    }

    public class ScoreStatistics
    {
        [JsonProperty("count_50")]
        public int Count50;

        [JsonProperty("count_100")]
        public int Count100;

        [JsonProperty("count_300")]
        public int Count300;

        [JsonProperty("count_geki")]
        public int CountGeki;

        [JsonProperty("count_katu")]
        public int CountKatu;

        [JsonProperty("count_miss")]
        public int CountMiss;
    }
    
    public class BeatmapScore
    {
        [JsonProperty("id")]
        public long Id;

        [JsonProperty("user_id")]
        public int UserId;

        [JsonProperty("accuracy")]
        public double Accuracy;

        // TODO: Decode mods into enum
        [JsonProperty("mods")]
        public string[] Mods;

        [JsonProperty("score")]
        public int Score;

        [JsonProperty("max_combo")]
        public int MaxCombo;

        [JsonProperty("passed")]
        public bool Passed;

        [JsonProperty("perfect")]
        public bool Perfect;

        [JsonProperty("statistics")]
        public ScoreStatistics Statistics;
        
        // TODO: Decode rank into enum
        [JsonProperty("rank")]
        public string Rank;

        [JsonProperty("created_at")]
        private string _createdAt;
        
        [JsonIgnore]
        public DateTime CreatedAt => Parser.ParseOsuTimestamp(_createdAt);

        [JsonProperty("best_id")]
        public long BestId;

        [JsonProperty("pp")]
        public float PP;
        
        [JsonProperty("mode")]
        public GameMode Mode;
        
        [JsonProperty("mode_int")]
        public int ModeInt;

        [JsonProperty("replay")]
        public bool Replay;
        
        // TODO: Add user
    }
}