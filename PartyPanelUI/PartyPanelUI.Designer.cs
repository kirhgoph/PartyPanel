﻿namespace PartyPanelUI
{
    partial class PartyPanelUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.songListView = new System.Windows.Forms.ListView();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.characteristicDropdown = new System.Windows.Forms.ComboBox();
            this.positiveModifierBox = new System.Windows.Forms.GroupBox();
            this.ghostNotesCheckbox = new System.Windows.Forms.CheckBox();
            this.disappearingArrowsCheckbox = new System.Windows.Forms.CheckBox();
            this.fastSongCheckbox = new System.Windows.Forms.CheckBox();
            this.fastNotesCheckbox = new System.Windows.Forms.CheckBox();
            this.batteryEnergyCheckbox = new System.Windows.Forms.CheckBox();
            this.failOnClashCheckbox = new System.Windows.Forms.CheckBox();
            this.instaFailCheckbox = new System.Windows.Forms.CheckBox();
            this.negativeModifiersBox = new System.Windows.Forms.GroupBox();
            this.slowSongCheckbox = new System.Windows.Forms.CheckBox();
            this.noWallsCheckbox = new System.Windows.Forms.CheckBox();
            this.noBombsCheckbox = new System.Windows.Forms.CheckBox();
            this.noFailCheckbox = new System.Windows.Forms.CheckBox();
            this.playerSettingsBox = new System.Windows.Forms.GroupBox();
            this.reduceDebrisCheckbox = new System.Windows.Forms.CheckBox();
            this.advancedHudCheckbox = new System.Windows.Forms.CheckBox();
            this.staticLightsCheckbox = new System.Windows.Forms.CheckBox();
            this.mirrorCheckbox = new System.Windows.Forms.CheckBox();
            this.noHudCheckbox = new System.Windows.Forms.CheckBox();
            this.returnToMenuButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.difficultyDropdown = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.artBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AllPage = new System.Windows.Forms.TabPage();
            this.OSTPage = new System.Windows.Forms.TabPage();
            this.DLCPage = new System.Windows.Forms.TabPage();
            this.CustomPage = new System.Windows.Forms.TabPage();
            this.groupBox.SuspendLayout();
            this.positiveModifierBox.SuspendLayout();
            this.negativeModifiersBox.SuspendLayout();
            this.playerSettingsBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // songListView
            // 
            this.songListView.HideSelection = false;
            this.songListView.Location = new System.Drawing.Point(110, 265);
            this.songListView.MultiSelect = false;
            this.songListView.Name = "songListView";
            this.songListView.Size = new System.Drawing.Size(391, 305);
            this.songListView.TabIndex = 0;
            this.songListView.UseCompatibleStateImageBehavior = false;
            this.songListView.SelectedIndexChanged += new System.EventHandler(this.songListView_SelectedIndexChangedAsync);
            this.songListView.DoubleClick += new System.EventHandler(this.playButton_Click);
            // 
            // groupBox
            // 
            this.groupBox.AutoSize = true;
            this.groupBox.Controls.Add(this.characteristicDropdown);
            this.groupBox.Controls.Add(this.positiveModifierBox);
            this.groupBox.Controls.Add(this.negativeModifiersBox);
            this.groupBox.Controls.Add(this.playerSettingsBox);
            this.groupBox.Controls.Add(this.returnToMenuButton);
            this.groupBox.Controls.Add(this.playButton);
            this.groupBox.Controls.Add(this.difficultyDropdown);
            this.groupBox.Location = new System.Drawing.Point(590, 15);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(186, 603);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Options";
            // 
            // characteristicDropdown
            // 
            this.characteristicDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.characteristicDropdown.FormattingEnabled = true;
            this.characteristicDropdown.Location = new System.Drawing.Point(5, 479);
            this.characteristicDropdown.Name = "characteristicDropdown";
            this.characteristicDropdown.Size = new System.Drawing.Size(174, 21);
            this.characteristicDropdown.TabIndex = 10;
            this.characteristicDropdown.SelectedIndexChanged += new System.EventHandler(this.CharacteristicDropdown_SelectedIndexChanged);
            // 
            // positiveModifierBox
            // 
            this.positiveModifierBox.Controls.Add(this.ghostNotesCheckbox);
            this.positiveModifierBox.Controls.Add(this.disappearingArrowsCheckbox);
            this.positiveModifierBox.Controls.Add(this.fastSongCheckbox);
            this.positiveModifierBox.Controls.Add(this.fastNotesCheckbox);
            this.positiveModifierBox.Controls.Add(this.batteryEnergyCheckbox);
            this.positiveModifierBox.Controls.Add(this.failOnClashCheckbox);
            this.positiveModifierBox.Controls.Add(this.instaFailCheckbox);
            this.positiveModifierBox.Location = new System.Drawing.Point(13, 267);
            this.positiveModifierBox.Margin = new System.Windows.Forms.Padding(2);
            this.positiveModifierBox.Name = "positiveModifierBox";
            this.positiveModifierBox.Padding = new System.Windows.Forms.Padding(2);
            this.positiveModifierBox.Size = new System.Drawing.Size(167, 174);
            this.positiveModifierBox.TabIndex = 9;
            this.positiveModifierBox.TabStop = false;
            this.positiveModifierBox.Text = "Positive Modifiers";
            // 
            // ghostNotesCheckbox
            // 
            this.ghostNotesCheckbox.AutoSize = true;
            this.ghostNotesCheckbox.Location = new System.Drawing.Point(5, 149);
            this.ghostNotesCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.ghostNotesCheckbox.Name = "ghostNotesCheckbox";
            this.ghostNotesCheckbox.Size = new System.Drawing.Size(85, 17);
            this.ghostNotesCheckbox.TabIndex = 18;
            this.ghostNotesCheckbox.Text = "Ghost Notes";
            this.ghostNotesCheckbox.UseVisualStyleBackColor = true;
            // 
            // disappearingArrowsCheckbox
            // 
            this.disappearingArrowsCheckbox.AutoSize = true;
            this.disappearingArrowsCheckbox.Location = new System.Drawing.Point(5, 127);
            this.disappearingArrowsCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.disappearingArrowsCheckbox.Name = "disappearingArrowsCheckbox";
            this.disappearingArrowsCheckbox.Size = new System.Drawing.Size(123, 17);
            this.disappearingArrowsCheckbox.TabIndex = 17;
            this.disappearingArrowsCheckbox.Text = "Disappearing Arrows";
            this.disappearingArrowsCheckbox.UseVisualStyleBackColor = true;
            // 
            // fastSongCheckbox
            // 
            this.fastSongCheckbox.AutoSize = true;
            this.fastSongCheckbox.Location = new System.Drawing.Point(5, 105);
            this.fastSongCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.fastSongCheckbox.Name = "fastSongCheckbox";
            this.fastSongCheckbox.Size = new System.Drawing.Size(74, 17);
            this.fastSongCheckbox.TabIndex = 16;
            this.fastSongCheckbox.Text = "Fast Song";
            this.fastSongCheckbox.UseVisualStyleBackColor = true;
            // 
            // fastNotesCheckbox
            // 
            this.fastNotesCheckbox.AutoSize = true;
            this.fastNotesCheckbox.Location = new System.Drawing.Point(5, 83);
            this.fastNotesCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.fastNotesCheckbox.Name = "fastNotesCheckbox";
            this.fastNotesCheckbox.Size = new System.Drawing.Size(77, 17);
            this.fastNotesCheckbox.TabIndex = 15;
            this.fastNotesCheckbox.Text = "Fast Notes";
            this.fastNotesCheckbox.UseVisualStyleBackColor = true;
            // 
            // batteryEnergyCheckbox
            // 
            this.batteryEnergyCheckbox.AutoSize = true;
            this.batteryEnergyCheckbox.Location = new System.Drawing.Point(5, 61);
            this.batteryEnergyCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.batteryEnergyCheckbox.Name = "batteryEnergyCheckbox";
            this.batteryEnergyCheckbox.Size = new System.Drawing.Size(95, 17);
            this.batteryEnergyCheckbox.TabIndex = 14;
            this.batteryEnergyCheckbox.Text = "Battery Energy";
            this.batteryEnergyCheckbox.UseVisualStyleBackColor = true;
            // 
            // failOnClashCheckbox
            // 
            this.failOnClashCheckbox.AutoSize = true;
            this.failOnClashCheckbox.Location = new System.Drawing.Point(5, 39);
            this.failOnClashCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.failOnClashCheckbox.Name = "failOnClashCheckbox";
            this.failOnClashCheckbox.Size = new System.Drawing.Size(119, 17);
            this.failOnClashCheckbox.TabIndex = 13;
            this.failOnClashCheckbox.Text = "Fail On Saber Clash";
            this.failOnClashCheckbox.UseVisualStyleBackColor = true;
            // 
            // instaFailCheckbox
            // 
            this.instaFailCheckbox.AutoSize = true;
            this.instaFailCheckbox.Location = new System.Drawing.Point(5, 17);
            this.instaFailCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.instaFailCheckbox.Name = "instaFailCheckbox";
            this.instaFailCheckbox.Size = new System.Drawing.Size(68, 17);
            this.instaFailCheckbox.TabIndex = 12;
            this.instaFailCheckbox.Text = "Insta Fail";
            this.instaFailCheckbox.UseVisualStyleBackColor = true;
            // 
            // negativeModifiersBox
            // 
            this.negativeModifiersBox.Controls.Add(this.slowSongCheckbox);
            this.negativeModifiersBox.Controls.Add(this.noWallsCheckbox);
            this.negativeModifiersBox.Controls.Add(this.noBombsCheckbox);
            this.negativeModifiersBox.Controls.Add(this.noFailCheckbox);
            this.negativeModifiersBox.Location = new System.Drawing.Point(13, 156);
            this.negativeModifiersBox.Margin = new System.Windows.Forms.Padding(2);
            this.negativeModifiersBox.Name = "negativeModifiersBox";
            this.negativeModifiersBox.Padding = new System.Windows.Forms.Padding(2);
            this.negativeModifiersBox.Size = new System.Drawing.Size(166, 106);
            this.negativeModifiersBox.TabIndex = 8;
            this.negativeModifiersBox.TabStop = false;
            this.negativeModifiersBox.Text = "Negative Modifiers";
            // 
            // slowSongCheckbox
            // 
            this.slowSongCheckbox.AutoSize = true;
            this.slowSongCheckbox.Location = new System.Drawing.Point(5, 84);
            this.slowSongCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.slowSongCheckbox.Name = "slowSongCheckbox";
            this.slowSongCheckbox.Size = new System.Drawing.Size(77, 17);
            this.slowSongCheckbox.TabIndex = 11;
            this.slowSongCheckbox.Text = "Slow Song";
            this.slowSongCheckbox.UseVisualStyleBackColor = true;
            // 
            // noWallsCheckbox
            // 
            this.noWallsCheckbox.AutoSize = true;
            this.noWallsCheckbox.Location = new System.Drawing.Point(5, 63);
            this.noWallsCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.noWallsCheckbox.Name = "noWallsCheckbox";
            this.noWallsCheckbox.Size = new System.Drawing.Size(69, 17);
            this.noWallsCheckbox.TabIndex = 10;
            this.noWallsCheckbox.Text = "No Walls";
            this.noWallsCheckbox.UseVisualStyleBackColor = true;
            // 
            // noBombsCheckbox
            // 
            this.noBombsCheckbox.AutoSize = true;
            this.noBombsCheckbox.Location = new System.Drawing.Point(5, 41);
            this.noBombsCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.noBombsCheckbox.Name = "noBombsCheckbox";
            this.noBombsCheckbox.Size = new System.Drawing.Size(75, 17);
            this.noBombsCheckbox.TabIndex = 9;
            this.noBombsCheckbox.Text = "No Bombs";
            this.noBombsCheckbox.UseVisualStyleBackColor = true;
            // 
            // noFailCheckbox
            // 
            this.noFailCheckbox.AutoSize = true;
            this.noFailCheckbox.Location = new System.Drawing.Point(5, 18);
            this.noFailCheckbox.Name = "noFailCheckbox";
            this.noFailCheckbox.Size = new System.Drawing.Size(59, 17);
            this.noFailCheckbox.TabIndex = 0;
            this.noFailCheckbox.Text = "No Fail";
            this.noFailCheckbox.UseVisualStyleBackColor = true;
            // 
            // playerSettingsBox
            // 
            this.playerSettingsBox.Controls.Add(this.reduceDebrisCheckbox);
            this.playerSettingsBox.Controls.Add(this.advancedHudCheckbox);
            this.playerSettingsBox.Controls.Add(this.staticLightsCheckbox);
            this.playerSettingsBox.Controls.Add(this.mirrorCheckbox);
            this.playerSettingsBox.Controls.Add(this.noHudCheckbox);
            this.playerSettingsBox.Location = new System.Drawing.Point(13, 18);
            this.playerSettingsBox.Margin = new System.Windows.Forms.Padding(2);
            this.playerSettingsBox.Name = "playerSettingsBox";
            this.playerSettingsBox.Padding = new System.Windows.Forms.Padding(2);
            this.playerSettingsBox.Size = new System.Drawing.Size(166, 133);
            this.playerSettingsBox.TabIndex = 7;
            this.playerSettingsBox.TabStop = false;
            this.playerSettingsBox.Text = "Player Settings";
            // 
            // reduceDebrisCheckbox
            // 
            this.reduceDebrisCheckbox.AutoSize = true;
            this.reduceDebrisCheckbox.Location = new System.Drawing.Point(5, 108);
            this.reduceDebrisCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.reduceDebrisCheckbox.Name = "reduceDebrisCheckbox";
            this.reduceDebrisCheckbox.Size = new System.Drawing.Size(97, 17);
            this.reduceDebrisCheckbox.TabIndex = 8;
            this.reduceDebrisCheckbox.Text = "Reduce Debris";
            this.reduceDebrisCheckbox.UseVisualStyleBackColor = true;
            // 
            // advancedHudCheckbox
            // 
            this.advancedHudCheckbox.AutoSize = true;
            this.advancedHudCheckbox.Location = new System.Drawing.Point(5, 86);
            this.advancedHudCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.advancedHudCheckbox.Name = "advancedHudCheckbox";
            this.advancedHudCheckbox.Size = new System.Drawing.Size(102, 17);
            this.advancedHudCheckbox.TabIndex = 7;
            this.advancedHudCheckbox.Text = "Advanced HUD";
            this.advancedHudCheckbox.UseVisualStyleBackColor = true;
            // 
            // staticLightsCheckbox
            // 
            this.staticLightsCheckbox.AutoSize = true;
            this.staticLightsCheckbox.Location = new System.Drawing.Point(5, 41);
            this.staticLightsCheckbox.Name = "staticLightsCheckbox";
            this.staticLightsCheckbox.Size = new System.Drawing.Size(84, 17);
            this.staticLightsCheckbox.TabIndex = 2;
            this.staticLightsCheckbox.Text = "Static Lights";
            this.staticLightsCheckbox.UseVisualStyleBackColor = true;
            // 
            // mirrorCheckbox
            // 
            this.mirrorCheckbox.AutoSize = true;
            this.mirrorCheckbox.Location = new System.Drawing.Point(5, 18);
            this.mirrorCheckbox.Name = "mirrorCheckbox";
            this.mirrorCheckbox.Size = new System.Drawing.Size(52, 17);
            this.mirrorCheckbox.TabIndex = 1;
            this.mirrorCheckbox.Text = "Mirror";
            this.mirrorCheckbox.UseVisualStyleBackColor = true;
            // 
            // noHudCheckbox
            // 
            this.noHudCheckbox.AutoSize = true;
            this.noHudCheckbox.Location = new System.Drawing.Point(5, 64);
            this.noHudCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.noHudCheckbox.Name = "noHudCheckbox";
            this.noHudCheckbox.Size = new System.Drawing.Size(67, 17);
            this.noHudCheckbox.TabIndex = 6;
            this.noHudCheckbox.Text = "No HUD";
            this.noHudCheckbox.UseVisualStyleBackColor = true;
            // 
            // returnToMenuButton
            // 
            this.returnToMenuButton.Location = new System.Drawing.Point(5, 561);
            this.returnToMenuButton.Name = "returnToMenuButton";
            this.returnToMenuButton.Size = new System.Drawing.Size(174, 23);
            this.returnToMenuButton.TabIndex = 5;
            this.returnToMenuButton.Text = "Return to Menu";
            this.returnToMenuButton.UseVisualStyleBackColor = true;
            this.returnToMenuButton.Click += new System.EventHandler(this.returnToMenuButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(5, 531);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(174, 23);
            this.playButton.TabIndex = 4;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // difficultyDropdown
            // 
            this.difficultyDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficultyDropdown.FormattingEnabled = true;
            this.difficultyDropdown.Location = new System.Drawing.Point(5, 505);
            this.difficultyDropdown.Name = "difficultyDropdown";
            this.difficultyDropdown.Size = new System.Drawing.Size(174, 21);
            this.difficultyDropdown.TabIndex = 3;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(62, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(172, 20);
            this.searchBox.TabIndex = 2;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(12, 15);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(133, 13);
            this.searchLabel.TabIndex = 3;
            this.searchLabel.Text = "Waiting for songs to load...";
            // 
            // artBox
            // 
            this.artBox.AutoSize = true;
            this.artBox.Enabled = false;
            this.artBox.Location = new System.Drawing.Point(239, 13);
            this.artBox.Margin = new System.Windows.Forms.Padding(2);
            this.artBox.Name = "artBox";
            this.artBox.Size = new System.Drawing.Size(323, 17);
            this.artBox.TabIndex = 4;
            this.artBox.Text = "Show Cover Art (Disabling helps with lag during song refreshes)";
            this.artBox.UseVisualStyleBackColor = true;
            this.artBox.CheckedChanged += new System.EventHandler(this.artBox_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AllPage);
            this.tabControl1.Controls.Add(this.OSTPage);
            this.tabControl1.Controls.Add(this.DLCPage);
            this.tabControl1.Controls.Add(this.CustomPage);
            this.tabControl1.Location = new System.Drawing.Point(15, 51);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(344, 212);
            this.tabControl1.TabIndex = 5;
            // 
            // AllPage
            // 
            this.AllPage.Controls.Add(songListView);
            this.AllPage.Location = new System.Drawing.Point(4, 22);
            this.AllPage.Name = "AllPage";
            this.AllPage.Padding = new System.Windows.Forms.Padding(3);
            this.AllPage.Size = new System.Drawing.Size(336, 186);
            this.AllPage.TabIndex = 0;
            this.AllPage.Text = "All";
            this.AllPage.UseVisualStyleBackColor = true;
            this.AllPage.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // OSTPage
            // 
            this.OSTPage.Controls.Add(songListView);
            this.OSTPage.Location = new System.Drawing.Point(4, 22);
            this.OSTPage.Name = "OSTPage";
            this.OSTPage.Padding = new System.Windows.Forms.Padding(3);
            this.OSTPage.Size = new System.Drawing.Size(336, 186);
            this.OSTPage.TabIndex = 1;
            this.OSTPage.Text = "OST";
            this.OSTPage.UseVisualStyleBackColor = true;
            // 
            // DLCPage
            // 
            this.DLCPage.Controls.Add(songListView);
            this.DLCPage.Location = new System.Drawing.Point(4, 22);
            this.DLCPage.Name = "DLCPage";
            this.DLCPage.Size = new System.Drawing.Size(336, 186);
            this.DLCPage.TabIndex = 2;
            this.DLCPage.Text = "DLC";
            this.DLCPage.UseVisualStyleBackColor = true;
            // 
            // CustomPage
            // 
            this.CustomPage.Controls.Add(songListView);
            this.CustomPage.Location = new System.Drawing.Point(4, 22);
            this.CustomPage.Name = "CustomPage";
            this.CustomPage.Size = new System.Drawing.Size(336, 186);
            this.CustomPage.TabIndex = 3;
            this.CustomPage.Text = "Custom";
            this.CustomPage.UseVisualStyleBackColor = true;
            // 
            // PartyPanelUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 613);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.artBox);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.songListView);
            this.Name = "PartyPanelUI";
            this.Text = "PartyPanel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PartyPanel_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PartyPanel_FormClosed);
            this.groupBox.ResumeLayout(false);
            this.positiveModifierBox.ResumeLayout(false);
            this.positiveModifierBox.PerformLayout();
            this.negativeModifiersBox.ResumeLayout(false);
            this.negativeModifiersBox.PerformLayout();
            this.playerSettingsBox.ResumeLayout(false);
            this.playerSettingsBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TabPage AllPage;

        #endregion

        private System.Windows.Forms.ListView songListView;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ComboBox difficultyDropdown;
        private System.Windows.Forms.CheckBox staticLightsCheckbox;
        private System.Windows.Forms.CheckBox mirrorCheckbox;
        private System.Windows.Forms.CheckBox noFailCheckbox;
        private System.Windows.Forms.Button returnToMenuButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.GroupBox playerSettingsBox;
        private System.Windows.Forms.CheckBox noHudCheckbox;
        private System.Windows.Forms.CheckBox advancedHudCheckbox;
        private System.Windows.Forms.CheckBox reduceDebrisCheckbox;
        private System.Windows.Forms.GroupBox negativeModifiersBox;
        private System.Windows.Forms.CheckBox noBombsCheckbox;
        private System.Windows.Forms.CheckBox noWallsCheckbox;
        private System.Windows.Forms.CheckBox slowSongCheckbox;
        private System.Windows.Forms.GroupBox positiveModifierBox;
        private System.Windows.Forms.CheckBox instaFailCheckbox;
        private System.Windows.Forms.CheckBox failOnClashCheckbox;
        private System.Windows.Forms.CheckBox batteryEnergyCheckbox;
        private System.Windows.Forms.CheckBox fastNotesCheckbox;
        private System.Windows.Forms.CheckBox fastSongCheckbox;
        private System.Windows.Forms.CheckBox disappearingArrowsCheckbox;
        private System.Windows.Forms.CheckBox artBox;
        private System.Windows.Forms.CheckBox ghostNotesCheckbox;
        private System.Windows.Forms.ComboBox characteristicDropdown;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage OSTPage;
        private System.Windows.Forms.TabPage DLCPage;
        private System.Windows.Forms.TabPage CustomPage;
    }
}