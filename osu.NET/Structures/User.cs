﻿using System;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Util;

#nullable enable
namespace volcanicarts.osu.NET.Structures
{
    public class Cover
    {
        [JsonProperty("custom_url")]
        public string CustomUrl;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("url")]
        public string Url;
    }

    public enum ProfileSection
    {
        [JsonProperty("me")]
        Me,

        [JsonProperty("recent_activity")]
        RecentActivity,

        [JsonProperty("beatmaps")]
        Beatmaps,

        [JsonProperty("historical")]
        Historical,

        [JsonProperty("kudosu")]
        Kudosu,

        [JsonProperty("top_ranks")]
        TopRanks,

        [JsonProperty("medals")]
        Medals
    }

    public class Kudosu
    {
        [JsonProperty("available")]
        public long Available;

        [JsonProperty("total")]
        public long Total;
    }

    public class UserCompact
    {
        [JsonProperty("last_visit")]
        private string _lastVisit;

        [JsonProperty("avatar_url")]
        public string AvatarUrl;

        [JsonProperty("country_code")]
        public string CountryCode;

        [JsonProperty("cover")]
        public Cover Cover;

        [JsonProperty("default_group")]
        public string DefaultGroup;

        [JsonProperty("id")]
        public long Id;

        [JsonProperty("is_active")]
        public bool IsActive;

        [JsonProperty("is_bot")]
        public bool IsBot;

        [JsonProperty("is_deleted")]
        public bool IsDeleted;

        [JsonProperty("is_online")]
        public bool IsOnline;

        [JsonProperty("is_supporter")]
        public bool IsSupporter;

        [JsonProperty("pm_friends_only")]
        public bool PmFriendsOnly;

        [JsonProperty("profile_colour")]
        public string? ProfileColour;

        [JsonProperty("username")]
        public string Username;

        [JsonIgnore]
        public DateTime LastVisit => Parser.ParseOsuTimestamp(_lastVisit);
    }

    public class User : UserCompact
    {
        [JsonProperty("join_date")]
        private string _joinDate;

        [JsonProperty("discord")]
        public string Discord;

        [JsonProperty("has_supported")]
        public bool HasSupported;

        [JsonProperty("interests")]
        public string? Interests;

        [JsonProperty("kudosu")]
        public Kudosu? Kudosu;

        [JsonProperty("location")]
        public string? Location;

        [JsonProperty("max_blocks")]
        public long MaxBlocks;

        [JsonProperty("max_friends")]
        public long MaxFriends;

        [JsonProperty("occupation")]
        public string? Occupation;

        [JsonProperty("playmode")]
        public GameMode PlayMode;

        [JsonProperty("playstyle")]
        public string[] PlayStyle;

        [JsonProperty("post_count")]
        public long PostCount;

        [JsonProperty("profile_order")]
        public ProfileSection[] ProfileOrder;

        [JsonProperty("title")]
        public string? Title;

        [JsonProperty("title_url")]
        public string? TitleUrl;

        [JsonProperty("twitter")]
        public string? Twitter;

        [JsonProperty("website")]
        public string? Website;

        [JsonIgnore]
        public DateTime JoinDate => Parser.ParseOsuTimestamp(_joinDate);
    }
}