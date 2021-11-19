using System;

namespace PartyPanel.Shared.Models.Packets
{
    [Serializable]
    public class SongList
    {
        public PPPreviewBeatmapLevel[] Levels { get; set; }
    }
}
