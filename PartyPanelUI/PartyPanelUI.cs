﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PartyPanel.Shared;
using PartyPanel.Shared.Models;
using PartyPanel.Shared.Models.Packets;

namespace PartyPanelUI
{
    public partial class PartyPanelUI : Form
    {
        public Label g_searchLabel;
        public TextBox g_searchBox;
        public ListView g_songList;
        public CheckBox g_artCheckBox;
        public List<PPPreviewBeatmapLevel> masterLevelList;

        private PPPreviewBeatmapLevel currentSelection;
        private Network.Server server;

        delegate void PopulatePartyPanelDelegate(List<PPPreviewBeatmapLevel> levels);
        delegate void SongLoadedDelegate(PPPreviewBeatmapLevel level);
        delegate void DisableSongListDelegate();

        public void SetServer(Network.Server server)
        {
            this.server = server;
        }

        public PartyPanelUI()
        {
            InitializeComponent();

            songListView.LargeImageList = new ImageList();
            songListView.SmallImageList = new ImageList();
            g_songList = songListView;
            g_songList.LargeImageList.ImageSize = new System.Drawing.Size(64, 64);
            g_searchLabel = searchLabel;
            g_searchBox = searchBox;
            g_artCheckBox = artBox;
        }

        public void PopulatePartyPanel(List<PPPreviewBeatmapLevel> levels)
        {
            //This is potentially being called from another thread
            if (InvokeRequired)
            {
                Invoke(new PopulatePartyPanelDelegate(PopulatePartyPanel), levels);
            }
            else
            {
                g_songList.Enabled = false;
                g_songList.Items.Clear();

                g_songList.Items.AddRange(levels.Select(x => new ListViewItem(x.Name, x.LevelId)).ToArray());

                masterLevelList = levels;
                g_songList.Enabled = true;
                g_searchBox.Visible = true;
                g_searchLabel.Text = "Search:";
            }
        }

        public void DisableSongList()
        {
            if (InvokeRequired)
            {
                Invoke(new DisableSongListDelegate(DisableSongList));
            }
            else
            {
                g_songList.Enabled = false;
                g_searchBox.Visible = false;
                g_searchLabel.Text = "Disconnected from Game";
            }
        }

        private void songListView_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            if (songListView.SelectedItems.Count >= 1)
            {
                var levelID = songListView.SelectedItems[0].ImageKey;
                PPPreviewBeatmapLevel level = masterLevelList.Where(x => x.LevelId == levelID).First();

                //Clear out old info
                characteristicDropdown.Items.Clear();
                difficultyDropdown.Items.Clear();

                //Load IBeatmapLevel
                if (!level.Loaded)
                {
                    var loadLevel = new LoadSong();
                    loadLevel.levelId = level.LevelId;
                    server.Send(new Packet(loadLevel).ToBytes());
                }
                else
                {
                    SongLoaded(level);
                }
            }
        }

        public void SongLoaded(PPPreviewBeatmapLevel level)
        {
            if (InvokeRequired)
            {
                Invoke(new SongLoadedDelegate(SongLoaded), level);
            }
            else
            {
                masterLevelList[masterLevelList.FindIndex(x => x.LevelId == level.LevelId)] = level;

                currentSelection = level;

                level.Characteristics.ToList().ForEach(x => characteristicDropdown.Items.Add(x.SerializedName));
                characteristicDropdown.SelectedIndex = 0;

                //We'll assume we've currently selected the 0th checkbox, since, well, we have
                difficultyDropdown.Items.Clear();
                level
                    .Characteristics.First()
                    .difficulties.ToList().ForEach(x => difficultyDropdown.Items.Add(x.ToString()));
                difficultyDropdown.SelectedIndex = difficultyDropdown.Items.Count - 1;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (songListView.SelectedItems.Count > 0 && difficultyDropdown.SelectedIndex >= 0)
            {
                var playerSettings = new PPPlayerSpecificSettings();
                playerSettings.leftHanded = mirrorCheckbox.Checked;
                playerSettings.staticLights = staticLightsCheckbox.Checked;
                playerSettings.noTextsAndHuds = noHudCheckbox.Checked;
                playerSettings.advancedHud = advancedHudCheckbox.Checked;
                playerSettings.reduceDebris = reduceDebrisCheckbox.Checked;
            
                var modifiers = new PPGameplayModifiers();
                modifiers.noFail = noFailCheckbox.Checked;
                modifiers.noBombs = noBombsCheckbox.Checked;
                modifiers.noObstacles = noWallsCheckbox.Checked;
                modifiers.instaFail = instaFailCheckbox.Checked && !modifiers.noFail;
                modifiers.failOnSaberClash = failOnClashCheckbox.Checked;
                modifiers.batteryEnergy = batteryEnergyCheckbox.Checked && !modifiers.noFail && !modifiers.instaFail;
                modifiers.fastNotes = fastNotesCheckbox.Checked;
                modifiers.songSpeed = fastSongCheckbox.Checked ?
                    PPGameplayModifiers.SongSpeed.Faster :
                    slowSongCheckbox.Checked ? 
                        PPGameplayModifiers.SongSpeed.Slower :
                        PPGameplayModifiers.SongSpeed.Normal;
                modifiers.disappearingArrows = disappearingArrowsCheckbox.Checked && !ghostNotesCheckbox.Checked;
                modifiers.ghostNotes = ghostNotesCheckbox.Checked;
            
                var characteristic = currentSelection.Characteristics.First(x => x.SerializedName == characteristicDropdown.SelectedItem as string);
            
                var playSong = new PlaySong();
                playSong.characteristic = new PPCharacteristic();
                playSong.characteristic.SerializedName = characteristic.SerializedName;
                playSong.difficulty = (PPCharacteristic.BeatmapDifficulty)Enum.Parse(typeof(PPCharacteristic.BeatmapDifficulty), difficultyDropdown.SelectedItem.ToString());
                playSong.gameplayModifiers = modifiers;
                playSong.playerSettings = playerSettings;
                playSong.levelId = currentSelection.LevelId;
            
                server.Send(new Packet(playSong).ToBytes());
            }
        }

        private void returnToMenuButton_Click(object sender, EventArgs e)
        {
            var command = new Command();
            command.commandType = Command.CommandType.ReturnToMenu;
            server.Send(new Packet(command).ToBytes());
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            songListView.Clear();
            if (searchBox.Text.Length <= 0)
            {
                songListView.Items.AddRange(
                masterLevelList
                    .Select(x => {
                        var item = new ListViewItem(x.Name, x.LevelId);
                        item.ImageKey = x.LevelId; //LevelID used for launching game. AKA `key` in the Items.Add parameters. `Name` is the key we passed in on creation. Weird naming scheme.
                        return item;
                    })
                    .ToArray()
                );
            }
            else
            {
                songListView.Items.AddRange(
                masterLevelList
                    .Where(x => x.Name.ToLower().Contains(searchBox.Text.ToLower()))
                    .Select(x => {
                        var item = new ListViewItem(x.Name, x.LevelId);
                        item.ImageKey = x.LevelId; //LevelID used for launching game. AKA `key` in the Items.Add parameters
                        return item;
                    })
                    .ToArray()
                );
            }
        }

        private void artBox_CheckedChanged(object sender, EventArgs e)
        {
            songListView.SmallImageList.Images.Clear();
            songListView.LargeImageList.Images.Clear();
        }

        private void CharacteristicDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            difficultyDropdown.Items.Clear();

            currentSelection
                .Characteristics.First(x => x.SerializedName == characteristicDropdown.SelectedItem as string)
                .difficulties.ToList().ForEach(x => difficultyDropdown.Items.Add(x.ToString()));

            difficultyDropdown.SelectedIndex = difficultyDropdown.Items.Count - 1;
        }

        private void PartyPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void PartyPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Shutdown();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
