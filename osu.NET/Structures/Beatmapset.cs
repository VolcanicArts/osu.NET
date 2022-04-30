// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

#nullable enable
using System;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Structures;

public class BeatmapsetCompact : BaseStructure
{
    [JsonProperty("artist")]
    public string Artist;

    [JsonProperty("artist_unicode")]
    public string ArtistUnicode;

    [JsonProperty("beatmaps")]
    public Beatmap[] Beatmaps;

    [JsonProperty("covers")]
    public Covers Covers;

    [JsonProperty("creator")]
    public string Creator;

    [JsonProperty("favourite_count")]
    public int FavouriteCount;

    [JsonProperty("has_favourited")]
    public bool HasFavourited;

    [JsonProperty("id")]
    public int Id;

    [JsonProperty("nsfw")]
    public bool Nsfw;

    [JsonProperty("play_count")]
    public int PlayCount;

    [JsonProperty("preview_url")]
    public string PreviewUrl;

    [JsonProperty("source")]
    public string Source;

    [JsonProperty("title")]
    public string Title;

    [JsonProperty("title_unicode")]
    public string TitleUnicode;

    [JsonProperty("user_id")]
    public int UserId;

    [JsonProperty("video")]
    public bool Video;
}

public class Beatmapset : BeatmapsetCompact
{
    [JsonProperty("bpm")]
    public float Bpm;

    [JsonProperty("can_be_hyped")]
    public bool CanBeHyped;

    [JsonProperty("hype.current")]
    public int CurrentHype;

    [JsonProperty("nominations.current")]
    public int CurrentNominations;

    [JsonProperty("discussion_enabled")]
    public bool DiscussionEnabled;

    [JsonProperty("discussion_locked")]
    public bool DiscussionLocked;

    [JsonProperty("availability.download_disabled")]
    public bool IsDownloadDisabled;

    [JsonProperty("is_scoreable")]
    public bool IsScoreable;

    [JsonProperty("last_updated")]
    public string LastUpdated;

    [JsonProperty("legacy_thread_url")]
    public string? LegacyThreadUrl;

    [JsonProperty("availability.more_information")]
    public string? MoreInformation;

    [JsonProperty("ranked")]
    public RankStatus Ranked;

    [JsonProperty("ranked_date")]
    public string? RankedDate;

    [JsonProperty("hype.required")]
    public int RequiredHype;

    [JsonProperty("nominations.required")]
    public int RequiredNominations;

    [JsonProperty("storyboard")]
    public bool Storyboard;

    [JsonProperty("submitted_date")]
    public string? SubmittedDate;

    [JsonProperty("tags")]
    public string Tags;

    [JsonIgnore]
    public DateTime LastUpdatedDateTime => Parser.ParseOsuTimestamp(LastUpdated);

    [JsonIgnore]
    public DateTime? RankedDateDateTime => Parser.ParseOsuTimestampNullable(RankedDate);

    [JsonIgnore]
    public DateTime? SubmittedDateDateTime => Parser.ParseOsuTimestampNullable(SubmittedDate);
}