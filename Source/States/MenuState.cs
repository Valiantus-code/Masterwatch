using GeonBit.UI;
using GeonBit.UI.Entities;
using Masterwatch.Source.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Masterwatch.Source.States
{
    public class MenuState : State
    {
        private readonly Texture2D gameName;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Init stuff
            _game.Window.Title = "Menu State";

            // Load textures, etc. here

            gameName = content.Load<Texture2D>("Misc/GameName");

            _userInterface.Clear(); // Clear the current UI

            // Build the UI here
            #region Menu base Panel

            Panel menuBase = new Panel(new Vector2(800, 650), PanelSkin.None, Anchor.TopCenter);
            _userInterface.AddEntity(menuBase);

            Image image = new Image(gameName, new Vector2(700, 150), ImageDrawMode.Stretch, Anchor.TopCenter);
            menuBase.AddChild(image);

            #region Menu Panel
            Panel menuPanel = new Panel(new Vector2(300f, 500f), PanelSkin.Default, Anchor.AutoCenter);
            menuBase.AddChild(menuPanel);

            Paragraph paragraph = new Paragraph("Main menu", Anchor.AutoCenter);
            menuPanel.AddChild(paragraph);

            menuPanel.AddChild(new HorizontalLine(Anchor.AutoCenter));

            #region Buttons
            Button playButton = new Button("PLAY", ButtonSkin.Default, Anchor.AutoCenter, new Vector2(0, 60));
            playButton.OnClick = (Entity btn) =>
            {
                _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
            };
            menuPanel.AddChild(playButton);

            Button loadButton = new Button("LOAD", ButtonSkin.Default, Anchor.AutoCenter, new Vector2(0, 60));
            loadButton.OnClick = (Entity btn) =>
            {
                GeonBit.UI.Utils.MessageBox.ShowMsgBox("WIP", "This feature is in development");
            };
            loadButton.Enabled = false;
            menuPanel.AddChild(loadButton);

            Button achievementsButton = new Button("ACHIEVEMENTS", ButtonSkin.Default, Anchor.AutoCenter, new Vector2(0, 60));
            achievementsButton.OnClick = (Entity btn) =>
            {
                _game.ChangeState(new AchievementsState(_game, _graphicsDevice, _content));
            };
            menuPanel.AddChild(achievementsButton);

            Button settingsButton = new Button("SETTINGS", ButtonSkin.Default, Anchor.AutoCenter, new Vector2(0, 60));
            settingsButton.OnClick = (Entity btn) =>
            {
                _game.ChangeState(new SettingsState(_game, _graphicsDevice, _content));
            };
            menuPanel.AddChild(settingsButton);

            Button exitButton = new Button("EXIT", ButtonSkin.Default, Anchor.AutoCenter, new Vector2(0, 60));
            exitButton.OnClick = (Entity btn) =>
            {
                _game.Exit();
            };
            menuPanel.AddChild(exitButton);
            #endregion

            menuPanel.AddChild(new HorizontalLine(Anchor.AutoCenter));

            Paragraph versionText = new Paragraph(text: Globals.versionNumber, Anchor.AutoCenter, scale: 0.8f);
            menuPanel.AddChild(versionText);

            #endregion

            #endregion

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw logic here
            _userInterface.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            #region Keyboard checks
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                _game.Exit();
            }
            else if (keyboardState.IsKeyDown(Keys.NumPad0))
            {
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
            }
            else if (keyboardState.IsKeyDown(Keys.NumPad1))
            {
                _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
            }
            #endregion

            // Update logic here
            _userInterface.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // Remove sprites if they're not needed
        }
    }
}
