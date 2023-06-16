using GeonBit.UI;
using GeonBit.UI.Entities;
using Masterwatch.Source.Engine;
using Masterwatch.Source.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Masterwatch
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // States
        private State _currentState;
        private State _nextState;

        // Background texture
        private Texture2D backgroundTexture;
        private Texture2D gameName;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Settings launch screen size
            graphics.PreferredBackBufferWidth = Globals.ScreenWidth;
            graphics.PreferredBackBufferHeight = Globals.ScreenHeight;
            graphics.ApplyChanges();

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Init stuff
            Window.Title = "Masterwatch";

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            #region Load Textures
            // Load textures for splashscreen



            // Load the background texture
            backgroundTexture = Content.Load<Texture2D>("Misc/MenuBackground");
            gameName = Content.Load<Texture2D>("Misc/GameName");

            #endregion

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Init UserInterface from GeonBit.UI
            UserInterface.Initialize(Content, BuiltinThemes.hd);

            // Build UI in load screen
            #region Menu base Panel
            Panel menuBase = new Panel(new Vector2(800, 700), PanelSkin.None, Anchor.Center);
            UserInterface.Active.AddEntity(menuBase);

            Image image = new Image(gameName, new Vector2(700, 150), ImageDrawMode.Stretch, Anchor.TopCenter);
            menuBase.AddChild(image);

            Panel panel = new Panel(new Vector2(600f, 400f), PanelSkin.Default, Anchor.Center, offset: new Vector2(0, 50));
            menuBase.AddChild(panel);

            #region Disclaimer Panel
            Header header = new Header("Disclaimer");
            panel.AddChild(header);

            panel.AddChild(new HorizontalLine());

            RichParagraph disclaimer = new RichParagraph("This game is currently in {{RED}}Early Access{{DEFAULT}} and is under heavy development.\nExpect {{BOLD}}changes, bugs and mayhem.{{DEFAULT}}", Anchor.Center, scale: 1.3f);
            panel.AddChild(disclaimer);

            Button button = new Button("I understand.", ButtonSkin.Default, Anchor.BottomCenter);
            button.OnClick = (Entity btn) =>
            {
                this.ChangeState(new MenuState(this, graphics.GraphicsDevice, Content));
            };
            panel.AddChild(button);
            #endregion

            #endregion


        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }
            _currentState?.Update(gameTime);

            _currentState?.PostUpdate(gameTime);

            // Update logic for splash screen here
            UserInterface.Active.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw background texture before other UI elements
            spriteBatch.Begin(SpriteSortMode.Immediate, samplerState: SamplerState.AnisotropicWrap);
            spriteBatch.Draw(backgroundTexture, GraphicsDevice.Viewport.Bounds, Color.White);
            spriteBatch.End();

            _currentState?.Draw(gameTime, spriteBatch);

            // Draw logic for splash screen here
            UserInterface.Active.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        // Main launch method from program.cs 
        static void Main()
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
}