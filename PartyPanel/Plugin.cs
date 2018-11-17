﻿using IllusionPlugin;
using SongLoaderPlugin;
using SongLoaderPlugin.OverrideClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine.SceneManagement;

/*
 * Created by Moon on 11/12/2018
 * 
 * If, god forbid, anyone should get their hands on this code, I want it to be known
 * that I HAVE NEVER, AND WILL NEVER USE THIS FOR MALICIOUS PURPOSES.
 * BEAT SABER IS A WONDERFUL GAME THAT SHOULD BE ENJOYED AS IT IS.
 * I WOULD NEVER DARE TO RUIN IT BY CHEATING.
 * (I have been accused of cheating, which prompted this message)
 * 
 * This plugin is designed to provide a user interface to interact with songs
 * and other tweaks in-game, as I develop them
 */

namespace PartyPanel
{
    public class Plugin : IPlugin
    {
        public string Name => "Moon's Private Debug Tools";
        public string Version => "0.0.1";
        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;

            ControlPanel panel = new ControlPanel();
            panel.Show();

            SongLoader.SongsLoadedEvent += (SongLoader sender, List<CustomLevel> loadedSongs) =>
            {
                SharedCoroutineStarter.instance.StartCoroutine(PopulateControlPanel(panel, loadedSongs));
            };
        }

        //Load song list into the control panel without freezing the game
        private IEnumerator PopulateControlPanel(ControlPanel panel, List<CustomLevel> loadedSongs)
        {
            panel.g_songList.Enabled = false;
            foreach (CustomLevel x in loadedSongs)
            {
                try
                {
                    var songIcon = Image.FromFile($"{x.customSongInfo.path}/{x.customSongInfo.coverImagePath}");
                    panel.g_songList.SmallImageList.Images.Add(x.levelID, songIcon);
                    panel.g_songList.LargeImageList.Images.Add(x.levelID, songIcon);
                }
                catch { }
                yield return panel.g_songList.Items.Add(x.levelID, x.songName, x.levelID);
            }
            panel.masterLevelList = loadedSongs;
            panel.g_songList.Enabled = true;
            panel.g_searchBox.Visible = true;
            panel.g_searchLabel.Text = "Search:";
        }

        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
        }

        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public void OnLevelWasLoaded(int level)
        {

        }

        public void OnLevelWasInitialized(int level)
        {
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }
    }
}