// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

#nullable enable
using Newtonsoft.Json;

namespace volcanicarts.osu.NET.Structures;

public class Rankings : BaseStructure
{
    [JsonProperty("beatmapsets")]
    public Beatmapset[] Beatmapsets;

    [JsonProperty("ranking")]
    public UserStatistics[] Ranking;

    [JsonProperty("spotlight")]
    public Spotlight? Spotlight;

    [JsonProperty("total")]
    public int Total;
}