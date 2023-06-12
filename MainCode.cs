// using GeonBit UI elements
using GeonBit.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Masterwatch
{
    /// This is the main class for your game.
    public class MainCode : Game
    {
        // Graphics and spritebatch
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Disclaimer panel
        DisclaimerPanel disclaimerPanel;

        // Menu panel
        MenuPanel menuPanel;

        // Replace with the actual last update date
        DateTime lastUpdateDate = new DateTime(2023, 6, 12);

        public MainCode()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                // Set the game to run in fullscreen mode
                IsFullScreen = true
            };

            // Get the user's screen resolution
            int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            // Set the fullscreen resolution
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            // Apply changes to the graphics device
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";

        }

        protected override void Initialize()
        {
            // GeonBit.UI: Init the UI manager using the "hd" built-in theme
            UserInterface.Initialize(Content, BuiltinThemes.editor);

            // Create the Early Access disclaimer panel
            string disclaimerText = ("This game is in {{RED}}Early Access{{DEFAULT}} and the current gameplay may change {{RED}}drastically{{DEFAULT}}! Bugs galore, feedback is appreciated.");
            disclaimerPanel = new DisclaimerPanel(disclaimerText);

            // Calculate or obtain the value of 'z' based on your requirements
            int z = CalculateDaysSinceLastUpdate();

            // Create the main menu panel with the gameVersion string at the bottom
            string gameVersion = "Version: 1.1." + z.ToString();
            menuPanel = new MenuPanel(this, gameVersion);

            base.Initialize();
        }

        private int CalculateDaysSinceLastUpdate()
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan timeSinceLastUpdate = currentDate - lastUpdateDate;
            int daysSinceLastUpdate = (int)timeSinceLastUpdate.TotalDays;

            return daysSinceLastUpdate;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            // Exit on 'esc'
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            UserInterface.Active.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            UserInterface.Active.Draw(spriteBatch);

            base.Draw(gameTime);

        }

    }
}