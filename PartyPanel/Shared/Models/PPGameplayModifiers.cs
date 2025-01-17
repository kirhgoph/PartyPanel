﻿using System;

namespace PartyPanel.Shared.Models
{
    [Serializable]
    public class PPGameplayModifiers
    {
        public enum SongSpeed
        {
            Normal,
            Faster,
            Slower
        }

        public bool noFail;
        public bool noBombs;
        public bool noObstacles;
        public bool instaFail;
        public bool failOnSaberClash;
        public bool batteryEnergy;
        public bool fastNotes;
        public SongSpeed songSpeed;
        public bool disappearingArrows;
        public bool ghostNotes;
    }
}
