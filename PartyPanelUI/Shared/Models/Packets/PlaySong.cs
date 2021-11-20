using System;

namespace PartyPanel.Shared.Models.Packets
{
    [Serializable]
    public class PlaySong
    {
        public string levelId;
        public PPCharacteristic characteristic;
        public PPCharacteristic.BeatmapDifficulty difficulty;
        public PPPlayerSpecificSettings playerSettings;
        public PPGameplayModifiers gameplayModifiers;
    }
}
