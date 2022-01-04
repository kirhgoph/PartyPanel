using System;
using System.Collections.Concurrent;
using IPA;
using SongCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using PartyPanel.Shared.Models;
using PartyPanel.Shared.Models.Packets;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Created by Moon on 11/12/2018
 * 
 * This plugin is designed to provide a user interface to launch songs
 * without being in the game
 */

namespace PartyPanel
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public string Name => "PartyPanel";
        public string Version => "0.0.1";
        
        public static List<PPPreviewBeatmapLevel> masterLevelList = new List<PPPreviewBeatmapLevel>();
        public static List<IPreviewBeatmapLevel> rawMasterLevelList = new List<IPreviewBeatmapLevel>();

        private Client client;

        [Init]
        public void OnApplicationStart()
        {
            client = new Client();
            client.Start();

            Loader.SongsLoadedEvent += (Loader l, ConcurrentDictionary<string, CustomPreviewBeatmapLevel> d) =>
            {
                var favoriteIds = Resources.FindObjectsOfTypeAll<PlayerDataModel>().FirstOrDefault()?.playerData
                    .favoritesLevelIds;
                var packsList = new List<LevelPack>();
                masterLevelList.AddRange(
                    Loader.BeatmapLevelsModelSO.ostAndExtrasPackCollection.beatmapLevelPacks.SelectMany(
                        x =>
                        {
                            packsList.Add(new LevelPack
                            {
                                PackId = x.packID,
                                PackName = x.packName,
                                CoverImage = x.coverImage.texture.EncodeToPNG()
                            });
                            return x.beatmapLevelCollection.ExtractLevels(PPCollection.OST, x.packID);
                        }));
                masterLevelList.AddRange(Loader.BeatmapLevelsModelSO.dlcBeatmapLevelPackCollection.beatmapLevelPacks.SelectMany(
                    x => x.beatmapLevelCollection.ExtractLevels(PPCollection.DLC, x.packID)));
                masterLevelList.AddRange(Loader.CustomLevelsCollection.ExtractLevels(PPCollection.Custom, ""));

                client.SendSongList(masterLevelList, packsList, favoriteIds);
            };
        }
    }

    public static class Extensions
    {
        public static IEnumerable<PPPreviewBeatmapLevel> ExtractLevels(this IBeatmapLevelCollection levelsCollection, PPCollection collectionType, string packId)
        {
            Plugin.rawMasterLevelList.AddRange(levelsCollection.beatmapLevels ?? new IPreviewBeatmapLevel[0]);
            return levelsCollection.beatmapLevels?
                .Select(
                    y => new PPPreviewBeatmapLevel
                    {
                        LevelId = y.levelID,
                        SongAuthorName = y.songAuthorName,
                        Name = y.songName,
                        SongSubname = y.songSubName,
                        CoverImage = y.GetCoverImageAsync(CancellationToken.None).Result.texture.EncodeToPNG(),
                        CollectionType = collectionType,
                        PackId = packId
                    }) ?? new PPPreviewBeatmapLevel[0];
        }
    }
}
