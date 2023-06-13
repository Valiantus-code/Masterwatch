using Masterwatch.Managers;
using Masterwatch.Pages;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using System.Xml.Linq;

namespace Masterwatch
{
    public class MainGame : Game
    {
        // graphics access
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        // window
        public int width { get; private set; }
        public int height { get; private set; }
        public string title = "Masterwatch";

        // page access and pages
        public PageManager pageMngr = new PageManager();
        public PageGame pageGame = new PageGame();

        public MainGame()
        {
            // init
            width = 800;
            height = 600;

            // init graphics
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // window
            IsMouseVisible = true;
            IsFixedTimeStep = false;
            Window.Title = title;

            // Init pages
            pageMngr.Add(pageGame, this);
            pageMngr.Set(pageGame);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load any additional content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();


            pageMngr.Update(gameTime, this);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw your game here

            pageMngr.Draw(this);

            base.Draw(gameTime);
        }

        // Main launch method from program.cs
        static void Main()
        {
            using var game = new MainGame();
            game.Run();
        }
    }
}