﻿// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using Newtonsoft.Json;

namespace volcanicarts.osu.NET.Structures;

public class Covers
{
    [JsonProperty("cover")]
    public string Cover { get; private set; }

    [JsonProperty("cover@2x")]
    public string CoverAt2X { get; private set; }

    [JsonProperty("card")]
    public string Card { get; private set; }

    [JsonProperty("card@2x")]
    public string CardAt2X { get; private set; }

    [JsonProperty("list")]
    public string List { get; private set; }

    [JsonProperty("list@2x")]
    public string ListAt2X { get; private set; }

    [JsonProperty("slimcover")]
    public string SlimCover { get; private set; }

    [JsonProperty("slimcover@2x")]
    public string SlimCoverAt2X { get; private set; }
}