using System;

namespace PartyPanel.Shared.Models
{
    [Serializable]
    public class PPCharacteristic
    {
        public enum BeatmapDifficulty
        {
            Easy,
            Normal,
            Hard,
            Expert,
            ExpertPlus
        }

        public string SerializedName { get; set; }

        public BeatmapDifficulty[] difficulties { get; set; }
    }
}
