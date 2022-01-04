using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;
using PartyPanel.Shared;
using PartyPanel.Shared.Models;
using PartyPanel.Shared.Models.Packets;
using PartyPanel.Utilities;
using SongCore;
using Timer = System.Timers.Timer;

namespace PartyPanel
{
    class Client
    {
        private Network.Client client;
        private Timer heartbeatTimer = new Timer();

        public void Start()
        {
            heartbeatTimer.Interval = 10000;
            heartbeatTimer.Elapsed += HeartbeatTimer_Elapsed;
            heartbeatTimer.Start();
        }

        private void HeartbeatTimer_Elapsed(object _, ElapsedEventArgs __)
        {
            try
            {
                var command = new Command();
                command.commandType = Command.CommandType.Heartbeat;
                client.Send(new Packet(command).ToBytes());
            }
            catch (Exception e)
            {
                PPLogger.Debug("HEARTBEAT FAILED");
                PPLogger.Debug(e.ToString());

                ConnectToServer();
            }
        }

        private void ConnectToServer()
        {
            try
            {
                client = new Network.Client(10155);
                client.PacketRecieved += Client_PacketRecieved;
                client.ServerDisconnected += Client_ServerDisconnected;
                client.Start();

                //Send the server the master list if we can
                if (Plugin.masterLevelList != null)
                {
                    client.Send(new Packet(Plugin.masterLevelList).ToBytes());
                }
            }
            catch (Exception e)
            {
                PPLogger.Debug(e.ToString());
            }
        }

        private void Client_ServerDisconnected()
        {
            PPLogger.Debug("Server disconnected!");
        }

        public async Task SendSongList(List<PPPreviewBeatmapLevel> levels, List<LevelPack> packs, HashSet<string> favoriteIds)
        {
            if (client != null && client.Connected)
            {
                client.Send(new Packet((levels, packs, favoriteIds)).ToBytes());
            }
            else PPLogger.Debug("Skipped sending songs because there is no server connected");
        }

        private void Client_PacketRecieved(Packet packet)
        {
            if (packet.Type == PacketType.PlaySong)
            {
                PlaySong playSong = packet.SpecificPacket as PlaySong;
            
                var desiredLevel = Plugin.rawMasterLevelList.First(x => x.levelID == playSong.levelId);
                var desiredCharacteristic = Loader.beatmapCharacteristicCollection.beatmapCharacteristics.First(x => x.serializedName == playSong.characteristic.SerializedName);
                //var desiredCharacteristic = Loader.beatmapCharacteristicCollection.beatmapCharacteristics.First(x => x.serializedName == playSong.ppCharacteristic.SerializedName);
                var desiredDifficulty = (BeatmapDifficulty)playSong.difficulty;
            
                var playerSpecificSettings = new PlayerSpecificSettings();
                // playerSpecificSettings.advancedHud = playSong.playerSettings.advancedHud;
                // playerSpecificSettings.leftHanded = playSong.playerSettings.leftHanded;
                // playerSpecificSettings.noTextsAndHuds = playSong.playerSettings.noTextsAndHuds;
                // playerSpecificSettings.reduceDebris = playSong.playerSettings.reduceDebris;
                //playerSpecificSettings.staticLights = playSong.playerSettings.staticLights;

                var gameplayModifiers = new GameplayModifiers();
                // gameplayModifiers.batteryEnergy = playSong.gameplayModifiers.batteryEnergy;
                // gameplayModifiers.disappearingArrows = playSong.gameplayModifiers.disappearingArrows;
                // gameplayModifiers.failOnSaberClash = playSong.gameplayModifiers.failOnSaberClash;
                // gameplayModifiers.fastNotes = playSong.gameplayModifiers.fastNotes;
                // gameplayModifiers.ghostNotes = playSong.gameplayModifiers.ghostNotes;
                // gameplayModifiers.instaFail = playSong.gameplayModifiers.instaFail;
                // gameplayModifiers.noBombs = playSong.gameplayModifiers.noBombs;
                // gameplayModifiers.noFail = playSong.gameplayModifiers.noFail;
                // gameplayModifiers.noObstacles = playSong.gameplayModifiers.noObstacles;
                // gameplayModifiers.songSpeed = (GameplayModifiers.SongSpeed)playSong.gameplayModifiers.songSpeed;
            
                SaberUtilities.PlaySong(desiredLevel, desiredCharacteristic, desiredDifficulty, gameplayModifiers, playerSpecificSettings);
            }
            if (packet.Type == PacketType.LoadSong)
            {
                LoadSong loadSong = packet.SpecificPacket as LoadSong;
            
                Action<IBeatmapLevel> SongLoadedCallBack = (loadedLevel) =>
                {
                    var loadedSong = new LoadedSong();
                    var beatmapLevel = new PPPreviewBeatmapLevel();
                    beatmapLevel.Characteristics = loadedLevel.beatmapLevelData.difficultyBeatmapSets.Select(x => x.beatmapCharacteristic).Select(x => {
                        var characteristic = new PPCharacteristic();
                        characteristic.SerializedName = x.serializedName;
                        characteristic.difficulties =
                            loadedLevel.beatmapLevelData.difficultyBeatmapSets
                                .First(y => y.beatmapCharacteristic.serializedName == x.serializedName)
                                .difficultyBeatmaps.Select(y => (PPCharacteristic.BeatmapDifficulty)y.difficulty).ToArray();
            
                        return characteristic;
                    }).ToArray();
            
                    beatmapLevel.LevelId = loadedLevel.levelID;
                    beatmapLevel.Name = loadedLevel.songName;
                    beatmapLevel.Loaded = true;
            
                    loadedSong.level = beatmapLevel;
            
                    client.Send(new Packet(loadedSong).ToBytes());
                };
            
                LoadSong(loadSong.levelId, SongLoadedCallBack);
            }
            else if (packet.Type == PacketType.Command)
            {
                Command command = packet.SpecificPacket as Command;
                if (command.commandType == Command.CommandType.ReturnToMenu)
                {
                    SaberUtilities.ReturnToMenu();
                }
                if (command.commandType == Command.CommandType.RefreshSongs)
                {
                    Loader.Instance.RefreshSongs();
                }
            }
        }

        private async void LoadSong(string levelId, Action<IBeatmapLevel> loadedCallback)
        {
            IPreviewBeatmapLevel level = Plugin.rawMasterLevelList.First(x => x.levelID == levelId);
        
            //Load IBeatmapLevel
            if (level is PreviewBeatmapLevelSO || level is CustomPreviewBeatmapLevel)
            {
                // if (level is PreviewBeatmapLevelSO)
                // {
                //     if (!await SaberUtilities.HasDLCLevel(level.levelID)) return; //In the case of unowned DLC, just bail out and do nothing
                // }
            
                var map = ((CustomPreviewBeatmapLevel)level).standardLevelInfoSaveData.difficultyBeatmapSets.First().difficultyBeatmaps.First();
            
                var result = await SaberUtilities.GetLevelFromPreview(level);
                if (result != null && !(result?.isError == true))
                {
                    loadedCallback(result?.beatmapLevel);
                }
            }
            else if (level is BeatmapLevelSO)
            {
                loadedCallback(level as IBeatmapLevel);
            }
        }
    }
}
