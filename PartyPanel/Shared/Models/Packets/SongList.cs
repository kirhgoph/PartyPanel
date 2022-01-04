using System;
using System.Collections.Generic;
using UnityEngine;

namespace PartyPanel.Shared.Models.Packets
{
    [Serializable]
    public class SongList
    {
        public HashSet<string> FavoriteIds { get; set; }
        
        public PPLevelPacksCollection[] LevelPacksCollection { get; set; }
    }

    [Serializable]
    public class PPLevelPacksCollection
    {
        public int Number { get; set; }
        
        public LevelPack[] LevelPacks { get; set; }
    }

    [Serializable]
    public class LevelPack
    {
        public string PackId { get; set; }
        
        public string PackName { get; set; }
        
        public byte[] CoverImage { get; set; }
    }
}
