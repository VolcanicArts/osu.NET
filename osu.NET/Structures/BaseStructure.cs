// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using Newtonsoft.Json;
using volcanicarts.osu.NET.Client;

namespace volcanicarts.osu.NET.Structures
{
    public class BaseStructure
    {
        [JsonIgnore]
        public OsuClient OsuClient;
    }
}