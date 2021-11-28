using System;
using System.Collections.Generic;
using UnityEngine;

namespace PartyPanel.Shared.Models.Packets
{
    [Serializable]
    public class SongList
    {
        public HashSet<string> FavoriteIds { get; set; }
        
        public LevelPack[] LevelPacks { get; set; }
    }

    [Serializable]
    public class LevelPack
    {
        public string PackName { get; set; }
        
        public string CoverImage { get; set; }
        
        public PPPreviewBeatmapLevel[] Levels { get; set; }
    }
}
