// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using Newtonsoft.Json;

namespace volcanicarts.osu.NET.Structures;

public struct GradeCounts
{
    [JsonProperty("a")]
    public int A;

    [JsonProperty("s")]
    public int S;

    [JsonProperty("sh")]
    public int SH;

    [JsonProperty("ss")]
    public int SS;

    [JsonProperty("ssh")]
    public int SSH;
}

public class UserStatistics
{
    [JsonProperty("level.current")]
    public int CurrentLevel;

    [JsonProperty("global_rank")]
    public long? GlobalRank;

    [JsonProperty("hit_accuracy")]
    public float HitAccuracy;

    [JsonProperty("is_ranked")]
    public bool IsRanked;

    [JsonProperty("level.progress")]
    public int LevelProgress;

    [JsonProperty("maximum_combo")]
    public int MaximumCombo;

    [JsonProperty("play_count")]
    public int PlayCount;

    [JsonProperty("play_time")]
    public long PlayTime;

    [JsonProperty("pp")]
    public float PP;

    [JsonProperty("ranked_score")]
    public long RankedScore;

    [JsonProperty("replays_watched_by_others")]
    public long ReplaysWatchedByOthers;

    [JsonProperty("total_hits")]
    public long TotalHits;

    [JsonProperty("total_scores")]
    public long TotalScore;

    [JsonProperty("user")]
    public UserCompact User;
}