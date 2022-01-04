using System;

namespace PartyPanel.Shared.Models.Packets
{
    [Serializable]
    public class Command
    {
        public enum CommandType
        {
            Heartbeat,
            ReturnToMenu,
            RefreshSongs
        }

        public CommandType commandType;
    }
}
