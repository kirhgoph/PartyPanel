using System;

namespace PartyPanel.Shared.Models
{
    [Serializable]
    public class PPPreviewBeatmapLevel
    {
        // -- Unloaded levels have the following:
        public string LevelId { get; set; }
        public string SongAuthorName { get; set; }
        public string Name { get; set; }
        public string SongSubname { get; set; }
        public byte[] CoverImage { get; set; }
        public PPCollection CollectionType { get; set; }
        public string PackId { get; set; }
        
        // -- Only Loaded levels will have the following:
        public PPCharacteristic[] Characteristics { get; set; }

        public bool Loaded { get; set; } = false;
    }
}
