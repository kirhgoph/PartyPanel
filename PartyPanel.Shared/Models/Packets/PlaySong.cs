using System;

namespace PartyPanel.Shared.Models.Packets
{
    [Serializable]
    public class PlaySong
    {
        public string levelId;
        public PPCharacteristic ppCharacteristic;
        public PPCharacteristic.BeatmapDifficulty difficulty;
        public PPPlayerSpecificSettings ppPlayerSettings;
        public PPGameplayModifiers ppGameplayModifiers;
    }
}
