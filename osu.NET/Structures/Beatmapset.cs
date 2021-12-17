using System;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Structures
{
     public class BeatmapsetCompact
    {
        [JsonProperty("artist")]
        public string Artist { get; private set; }

        [JsonProperty("artist_unicode")]
        public string ArtistUnicode { get; private set; }

        [JsonProperty("covers")]
        public Covers Covers { get; private set; }

        [JsonProperty("creator")]
        public string Creator { get; private set; }

        [JsonProperty("favourite_count")]
        public int FavouriteCount { get; private set; }

        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; private set; }

        [JsonProperty("play_count")]
        public int PlayCount { get; private set; }

        [JsonProperty("preview_url")]
        private string _previewUrl;

        [JsonIgnore]
        public string PreviewUrl => $"https:{_previewUrl}";

        [JsonProperty("source")]
        public string Source { get; private set; }

        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("title_unicode")]
        public string TitleUnicode { get; private set; }

        [JsonProperty("user_id")]
        public int UserId { get; private set; }

        [JsonProperty("video")]
        public bool Video { get; private set; }

        [JsonProperty("beatmaps")]
        public Beatmap[] Beatmaps { get; private set; }

        [JsonProperty("has_favourited")]
        public bool HasFavourited { get; private set; }
    }

    public class Beatmapset : BeatmapsetCompact
    {
        [JsonProperty("last_updated")]
        private string _lastUpdated;

        [JsonProperty("ranked")]
        private int _ranked;

        [JsonProperty("ranked_date")]
        private string? _rankedDate;

        [JsonProperty("submitted_date")]
        private string? _submittedDate;

        [JsonProperty("storyboard")]
        public bool Storyboard;

        [JsonProperty("tags")]
        public string Tags;

        [JsonProperty("availability.download_disabled")]
        public bool IsDownloadDisabled { get; private set; }

        [JsonProperty("availability.more_information")]
        public string? MoreInformation { get; private set; }

        [JsonProperty("bpm")]
        public float Bpm { get; private set; }

        [JsonProperty("can_be_hyped")]
        public bool CanBeHyped { get; private set; }

        [JsonProperty("discussion_enabled")]
        public bool DiscussionEnabled { get; private set; }

        [JsonProperty("discussion_locked")]
        public bool DiscussionLocked { get; private set; }

        [JsonProperty("hype.current")]
        public int CurrentHype { get; private set; }

        [JsonProperty("hype.required")]
        public int RequiredHype { get; private set; }

        [JsonProperty("is_scoreable")]
        public bool IsScoreable { get; private set; }

        [JsonIgnore]
        public DateTime LastUpdated => Parser.ParseOsuTimestamp(_lastUpdated);

        [JsonProperty("legacy_thread_url")]
        public string? LegacyThreadUrl { get; private set; }

        [JsonProperty("nominations.current")]
        public int CurrentNominations { get; private set; }

        [JsonProperty("nominations.required")]
        public int RequiredNominations { get; private set; }

        [JsonIgnore]
        public RankStatus Ranked => (RankStatus) _ranked;

        [JsonIgnore]
        public DateTime? RankedDate => Parser.ParseOsuTimestampNullable(_rankedDate);

        [JsonIgnore]
        public DateTime? SubmittedDate => Parser.ParseOsuTimestampNullable(_submittedDate);
    }
}