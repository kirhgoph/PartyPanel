using PartyPanelUI.Network;
using System.Linq;
using PartyPanel.Shared;
using PartyPanel.Shared.Models.Packets;
using WpfApp2;

namespace PartyPanelUI
{
    public class PartyPanel
    {
        private MainWindow _mainWindow;
        private Network.Server server;

        public PartyPanel(MainWindow panelUi)
        {
            this._mainWindow = panelUi;
        }

        public void Start()
        {
            server = new Network.Server(10155);
            _mainWindow.SetServer(server);
            server.PacketRecieved += Server_PacketRecieved;
            server.PlayerConnected += Server_PlayerConnected;
            server.PlayerDisconnected += Server_PlayerDisconnected;
            server.Start();
        }

        private void Server_PlayerDisconnected(NetworkPlayer obj)
        {
            PPLogger.Debug("Player Disconnected!");
            _mainWindow.DisableSongList();
        }

        private void Server_PlayerConnected(NetworkPlayer obj)
        {
            PPLogger.Debug("Player Connected!");
        }

        private void Server_PacketRecieved(NetworkPlayer player, Packet packet)
        {
            if (packet.Type == PacketType.SongList)
            {
                SongList masterLevelCollection = packet.SpecificPacket as SongList;
                _mainWindow.PopulatePartyPanel(masterLevelCollection.LevelPacksCollection[0].LevelPacks.SelectMany(x => x.Levels).ToList());
            }
            else if (packet.Type == PacketType.LoadedSong)
            {
                LoadedSong loadedSong = packet.SpecificPacket as LoadedSong;
                _mainWindow.SongLoaded(loadedSong.level);
            }
        }
    }
}
