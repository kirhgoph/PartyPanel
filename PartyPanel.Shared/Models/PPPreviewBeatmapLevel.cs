using System;

namespace PartyPanel.Shared.Models
{
    [Serializable]
    public class PPPreviewBeatmapLevel
    {
        // -- Unloaded levels have the following:
        public string LevelId { get; set; }
        public string Name { get; set; }

        // -- Only Loaded levels will have the following:
        public PPCharacteristic[] Characteristics { get; set; }

        public bool Loaded { get; set; } = false;
    }
}
