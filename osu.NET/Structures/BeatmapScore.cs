// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System;
using Newtonsoft.Json;
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
        [JsonProperty("count_100")]
        public int Count100;

        [JsonProperty("count_300")]
        public int Count300;

        [JsonProperty("count_50")]
        public int Count50;

        [JsonProperty("count_geki")]
        public int CountGeki;

        [JsonProperty("count_katu")]
        public int CountKatu;

        [JsonProperty("count_miss")]
        public int CountMiss;
    }

    public enum ScoreRank
    {
        XH,
        SH,
        X,
        S,
        A,
        B,
        C,
        D
    }

    public class BeatmapScore
    {
        [JsonProperty("created_at")]
        private string _createdAt;

        [JsonProperty("accuracy")]
        public double Accuracy;

        [JsonProperty("best_id")]
        public long BestId;

        [JsonProperty("id")]
        public long Id;

        [JsonProperty("max_combo")]
        public int MaxCombo;

        [JsonProperty("mode")]
        public GameMode Mode;

        [JsonProperty("mode_int")]
        public int ModeInt;

        [JsonProperty("mods")]
        public Mods[] Mods;

        [JsonProperty("passed")]
        public bool Passed;

        [JsonProperty("perfect")]
        public bool Perfect;

        [JsonProperty("pp")]
        public float PP;

        [JsonProperty("rank")]
        public ScoreRank Rank;

        [JsonProperty("replay")]
        public bool Replay;

        [JsonProperty("score")]
        public int Score;

        [JsonProperty("statistics")]
        public ScoreStatistics Statistics;

        [JsonProperty("user")]
        public UserCompact User;

        [JsonProperty("user_id")]
        public int UserId;

        [JsonIgnore]
        public DateTime CreatedAt => Parser.ParseOsuTimestamp(_createdAt);
    }
}