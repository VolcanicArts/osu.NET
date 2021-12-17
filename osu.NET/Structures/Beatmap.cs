using System;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Structures
{
    public class BeatmapCompact
    {
        [JsonProperty("mode")]
        private string _mode;

        [JsonProperty("status")]
        private string _status;

        [JsonProperty("beatmapset_id")]
        public int BeatmapsetId { get; private set; }

        [JsonProperty("difficulty_rating")]
        public float DifficultyRating { get; private set; }

        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonIgnore]
        public GameMode Mode => (GameMode) Enum.Parse(typeof(GameMode), _mode);

        [JsonIgnore]
        public RankStatus Status => (RankStatus) int.Parse(_status);

        [JsonProperty("total_length")]
        public int TotalLength { get; private set; }

        [JsonProperty("user_id")]
        public int UserId { get; private set; }

        [JsonProperty("version")]
        public string Version { get; private set; }
    }

    public class Beatmap : BeatmapCompact
    {
        [JsonProperty("deleted_at")]
        private string? _deletedAt;

        [JsonProperty("ranked")]
        private int _ranked;

        [JsonProperty("url")]
        public string Url { get; private set; }

        [JsonProperty("accuracy")]
        public float Accuracy { get; private set; }

        [JsonProperty("ar")]
        public float ApproachRate { get; private set; }

        [JsonProperty("bpm")]
        public float Bpm { get; private set; }

        [JsonProperty("convert")]
        public bool Convert { get; private set; }

        [JsonProperty("count_circles")]
        public int CircleCount { get; private set; }

        [JsonProperty("count_sliders")]
        public int SliderCount { get; private set; }

        [JsonProperty("count_spinners")]
        public int SpinnerCount { get; private set; }

        [JsonProperty("cs")]
        public float CircleSize { get; private set; }

        [JsonIgnore]
        public DateTime? DeletedAt => Parser.ParseOsuTimestampNullable(_deletedAt);

        [JsonProperty("drain")]
        public float Drain { get; private set; }

        [JsonProperty("hit_length")]
        public int HitLength { get; private set; }

        [JsonProperty("is_scoreable")]
        public bool IsScoreable { get; private set; }

        [JsonProperty("last_updated")]
        public string LastUpdated { get; private set; }

        [JsonProperty("mode_int")]
        public int ModeInt { get; private set; }

        [JsonProperty("passcount")]
        public int PassCount { get; private set; }

        [JsonProperty("playcount")]
        public int PlayCount { get; private set; }

        [JsonIgnore]
        public RankStatus Ranked => (RankStatus) _ranked;
    }
}