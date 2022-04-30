// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

#nullable enable
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Structures
{
    public class BeatmapCompactArray : BaseStructure
    {
        [JsonProperty("beatmaps")]
        public BeatmapCompact[] Beatmaps;
    }

    public class BeatmapCompact : BaseStructure
    {
        [JsonProperty("beatmapset_id")]
        public int BeatmapsetId;

        [JsonProperty("difficulty_rating")]
        public float DifficultyRating;

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("mode")]
        public GameMode Mode;

        [JsonProperty("status")]
        public RankStatus Status;

        [JsonProperty("total_length")]
        public int TotalLength;

        [JsonProperty("user_id")]
        public int UserId;

        [JsonProperty("version")]
        public string Version;

        public Task<Beatmapset?> GetBeatmapsetAsync()
        {
            return OsuClient.GetBeatmapsetAsync(BeatmapsetId.ToString());
        }
    }

    public class Beatmap : BeatmapCompact
    {
        [JsonProperty("deleted_at")]
        private string? _deletedAt;

        [JsonProperty("accuracy")]
        public float Accuracy;

        [JsonProperty("ar")]
        public float ApproachRate;

        [JsonProperty("bpm")]
        public float Bpm;

        [JsonProperty("count_circles")]
        public int CircleCount;

        [JsonProperty("cs")]
        public float CircleSize;

        [JsonProperty("convert")]
        public bool Convert;

        [JsonProperty("drain")]
        public float Drain;

        [JsonProperty("hit_length")]
        public int HitLength;

        [JsonProperty("is_scoreable")]
        public bool IsScoreable;

        [JsonProperty("last_updated")]
        public string LastUpdated;

        [JsonProperty("mode_int")]
        public int ModeInt;

        [JsonProperty("passcount")]
        public int PassCount;

        [JsonProperty("playcount")]
        public int PlayCount;

        [JsonProperty("ranked")]
        public RankStatus Ranked;

        [JsonProperty("count_sliders")]
        public int SliderCount;

        [JsonProperty("count_spinners")]
        public int SpinnerCount;

        [JsonProperty("url")]
        public string Url;

        [JsonIgnore]
        public DateTime? DeletedAt => Parser.ParseOsuTimestampNullable(_deletedAt);
    }
}