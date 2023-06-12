using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;

namespace Masterwatch
{
    public class MenuPanel : IDisposable
    {
        private readonly Panel panel;
        private readonly Game game;
        private readonly SettingsScreen settingsScreen;
        private readonly GameManager gameManager;

        public MenuPanel(Game game, string versionNumber)
        {
            this.game = game;

            gameManager = new GameManager(game);

            // Create a panel and position it in the center
            panel = new Panel(new Vector2(250, 400), PanelSkin.Simple, Anchor.Center);
            UserInterface.Active.AddEntity(panel);

            // Add menu buttons
            Button playButton = new("Play", ButtonSkin.Default, Anchor.AutoCenter, size: new Vector2(170, 50));
            playButton.OnClick = (entity) =>
            {
                gameManager.StartGame(); // Delegate the game startup logic to the GameManager class
            };
            panel.AddChild(playButton);

            Button loadButton = new("Load", ButtonSkin.Default, Anchor.AutoCenter, size: new Vector2(170, 50));
            loadButton.OnClick = (entity) =>
            {

            };
            panel.AddChild(loadButton);

            Button settingsButton = new("Settings", ButtonSkin.Default, Anchor.AutoCenter, size: new Vector2(170, 50));
            settingsButton.OnClick = (entity) =>
            {
                ShowSettingsScreen();
            };
            panel.AddChild(settingsButton);

            Button exitButton = new("Exit", ButtonSkin.Default, Anchor.AutoCenter, size: new Vector2(170, 50));
            exitButton.OnClick = (entity) =>
            {
                game.Exit();
            };
            panel.AddChild(exitButton);

            // Add more buttons if needed (may need to extend panel size)


            // Add paragraph with version number in the bottom left, version number is passed as a string "Version x.x.x".
            Label versionLabel = new(versionNumber, Anchor.BottomLeft);
            panel.AddChild(versionLabel);

            // Create the settings screen and make it hidden on creation
            settingsScreen = new SettingsScreen();
            settingsScreen.Hide();
        }

        private void ShowSettingsScreen()
        {
            settingsScreen.Show();
        }

        public void Dispose()
        {
            panel.Dispose();
            settingsScreen.Dispose();
        }
    }
}