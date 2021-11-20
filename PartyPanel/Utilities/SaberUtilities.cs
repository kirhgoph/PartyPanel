using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PartyPanel.Shared;
using PartyPanel.Shared.Models;
using UnityEngine;

namespace PartyPanel.Utilities
{
    class SaberUtilities
    {
        private static CancellationTokenSource getLevelCancellationTokenSource;
        private static CancellationTokenSource getStatusCancellationTokenSource;
    
        public static async void PlaySong(IPreviewBeatmapLevel level, BeatmapCharacteristicSO characteristic, BeatmapDifficulty difficulty, GameplayModifiers gameplayModifiers = null, PlayerSpecificSettings playerSettings = null)
        {
            Action<IBeatmapLevel> SongLoaded = (loadedLevel) =>
            {
                MenuTransitionsHelper _menuSceneSetupData = Resources.FindObjectsOfTypeAll<MenuTransitionsHelper>().First();
                _menuSceneSetupData.StartStandardLevel(
                    "Single",
                    loadedLevel.beatmapLevelData.GetDifficultyBeatmap(characteristic, difficulty),
                    level,
                    null,
                    null,
                    gameplayModifiers ?? new GameplayModifiers(),
                    playerSettings ?? new PlayerSpecificSettings(),
                    null,
                    "Menu",
                    false,
                    null,
                    null
                );
            };
        
             // if ((level is PreviewBeatmapLevelSO && await HasDLCLevel(level.levelID)) ||
             //             level is CustomPreviewBeatmapLevel)
              if (level is CustomPreviewBeatmapLevel)
             {
                 Shared.PPLogger.Debug("Loading DLC/Custom level...");
                 var result = await GetLevelFromPreview(level);
                 if (result != null && !(result?.isError == true))
                 {
                     SongLoaded(result?.beatmapLevel);
                 }
             }
            else if (level is BeatmapLevelSO)
            {
                PPLogger.Debug("Reading OST data without songloader...");
                SongLoaded(level as IBeatmapLevel);
            }
            else
            {
                PPLogger.Debug($"Skipping unowned DLC ({level.songName})");
            }
        }
    
        public static void ReturnToMenu()
        {
            //Resources.FindObjectsOfTypeAll<StandardLevelScenesTransitionSetupDataSO>().FirstOrDefault()?.PopScenes(0.35f);
            Resources.FindObjectsOfTypeAll<StandardLevelReturnToMenuController>().FirstOrDefault()?.ReturnToMenu();
        }
    
        //Returns the closest difficulty to the one provided, preferring lower difficulties first if any exist
        // public static IDifficultyBeatmap GetClosestDifficultyPreferLower(IBeatmapLevel level, Characteristic.BeatmapDifficulty difficulty, BeatmapCharacteristicSO characteristic = null)
        // {
        //     //First, look at the characteristic parameter. If there's something useful in there, we try to use it, but fall back to Standard
        //     var desiredCharacteristic = level.beatmapLevelData.difficultyBeatmapSets.FirstOrDefault(x => x.beatmapCharacteristic.serializedName == (characteristic?.serializedName ?? "Standard")) ?? level.beatmapLevelData.difficultyBeatmapSets.First();
        //
        //     IDifficultyBeatmap[] availableMaps =
        //         level
        //         .beatmapLevelData
        //         .difficultyBeatmapSets
        //         .FirstOrDefault(x => x.beatmapCharacteristic.serializedName == desiredCharacteristic.beatmapCharacteristic.serializedName)
        //         .difficultyBeatmaps
        //         .OrderBy(x => x.difficulty)
        //         .ToArray();
        //
        //     IDifficultyBeatmap ret = availableMaps.FirstOrDefault(x => x.difficulty == difficulty);
        //
        //     if (ret is CustomDifficultyBeatmap)
        //     {
        //         var extras = Collections.RetrieveExtraSongData(ret.level.levelID);
        //         var requirements = extras?._difficulties.First(x => x._difficulty == ret.difficulty).additionalDifficultyData._requirements;
        //         if (
        //             (requirements?.Count() > 0) &&
        //             (!requirements?.ToList().All(x => Collections.capabilities.Contains(x)) ?? false)
        //         ) ret = null;
        //     }
        //
        //     if (ret == null)
        //     {
        //         ret = GetLowerDifficulty(availableMaps, difficulty, desiredCharacteristic);
        //     }
        //     if (ret == null)
        //     {
        //         ret = GetHigherDifficulty(availableMaps, difficulty, desiredCharacteristic);
        //     }
        //
        //     return ret;
        // }
    
        //Returns the next-lowest difficulty to the one provided
        // private static IDifficultyBeatmap GetLowerDifficulty(IDifficultyBeatmap[] availableMaps, Characteristic.BeatmapDifficulty difficulty, BeatmapCharacteristicSO characteristic)
        // {
        //     var ret = availableMaps.TakeWhile(x => x.difficulty < difficulty).LastOrDefault();
        //     if (ret is CustomDifficultyBeatmap)
        //     {
        //         var extras = Collections.RetrieveExtraSongData(ret.level.levelID);
        //         var requirements = extras?._difficulties.First(x => x._difficulty == ret.difficulty).additionalDifficultyData._requirements;
        //         if (
        //             (requirements?.Count() > 0) &&
        //             (!requirements?.ToList().All(x => Collections.capabilities.Contains(x)) ?? false)
        //         ) ret = null;
        //     }
        //     return ret;
        // }
    
        //Returns the next-highest difficulty to the one provided
        // private static IDifficultyBeatmap GetHigherDifficulty(IDifficultyBeatmap[] availableMaps, Characteristic.BeatmapDifficulty difficulty, BeatmapCharacteristicSO characteristic)
        // {
        //     var ret = availableMaps.SkipWhile(x => x.difficulty < difficulty).FirstOrDefault();
        //     if (ret is CustomDifficultyBeatmap)
        //     {
        //         var extras = Collections.RetrieveExtraSongData(ret.level.levelID);
        //         var requirements = extras?._difficulties.First(x => x._difficulty == ret.difficulty).additionalDifficultyData._requirements;
        //         if (
        //             (requirements?.Count() > 0) &&
        //             (!requirements?.ToList().All(x => Collections.capabilities.Contains(x)) ?? false)
        //         ) ret = null;
        //     }
        //     return ret;
        // }
    
        // public static async Task<bool> HasDLCLevel(string levelId)
        // {
        //     additionalContentModel = additionalContentModel ?? Resources.FindObjectsOfTypeAll<AdditionalContentModelSO>().FirstOrDefault();
        //     var additionalContentHandler = additionalContentModel?.GetField<IPlatformAdditionalContentHandler>("_platformAdditionalContentHandler");
        //
        //     if (additionalContentHandler != null)
        //     {
        //         getStatusCancellationTokenSource?.Cancel();
        //         getStatusCancellationTokenSource = new CancellationTokenSource();
        //
        //         var token = getStatusCancellationTokenSource.Token;
        //         return await additionalContentHandler.GetLevelEntitlementStatusAsync(levelId, token) == AdditionalContentModelSO.EntitlementStatus.Owned;
        //     }
        //
        //     return false;
        // }
    
        public static async Task<BeatmapLevelsModel.GetBeatmapLevelResult?> GetLevelFromPreview(IPreviewBeatmapLevel level, BeatmapLevelsModel beatmapLevelsModel = null)
        {
            beatmapLevelsModel = beatmapLevelsModel ?? Resources.FindObjectsOfTypeAll<BeatmapLevelsModel>().FirstOrDefault();
        
            if (beatmapLevelsModel != null)
            {
                getLevelCancellationTokenSource?.Cancel();
                getLevelCancellationTokenSource = new CancellationTokenSource();
        
                var token = getLevelCancellationTokenSource.Token;
        
                BeatmapLevelsModel.GetBeatmapLevelResult? result = null;
                try
                {
                    result = await beatmapLevelsModel.GetBeatmapLevelAsync(level.levelID, token);
                }
                catch (OperationCanceledException) { }
                if (result?.isError == true || result?.beatmapLevel == null) return null; //Null out entirely in case of error
                return result;
            }
            return null;
        }
    }
}
