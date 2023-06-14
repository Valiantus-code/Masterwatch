using GeonBit.UI;
using GeonBit.UI.Entities;
using Masterwatch.Managers;
using Masterwatch.Pages;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        // Strings
        public string title = "Masterwatch - Menu";
        private string disclaimerText = "This game is in {{RED}}Early Access{{DEFAULT}} and is under heavy development, expect {{BOLD}}game changes, bugs and mayhem.{{DEFAULT}}";

        // page access and pages
        public PageManager pageMngr = new PageManager();
        public PageGame pageGame = new PageGame();
        public PageSettings pageSettings = new PageSettings();
        public PageLoad pageLoad = new PageLoad();
        public PageVillage pageVillage = new PageVillage();
        public PagePlayerBase pagePlayerBase = new PagePlayerBase();
        public PagePlayer pagePlayer = new PagePlayer();

        // Textures
        public Texture2D gameName;
        public Texture2D menuBackground;

        // Panels

        public MainGame()
        {
            // init
            width = 1200;
            height = 800;

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
            IsMouseVisible = false;
            IsFixedTimeStep = false;
            Window.Title = title;

            // Init pages
            pageMngr.Add(pageGame, this);
            pageMngr.Add(pageSettings, this);
            pageMngr.Add(pageLoad, this);
            pageMngr.Add(pageVillage, this);
            pageMngr.Add(pagePlayerBase, this);
            pageMngr.Add(pagePlayer, this);

            // Set home on init
            pageMngr.Set(0);

            // GeonBit.UI: Init the UI manager using the "hd" built-in theme
            UserInterface.Initialize(Content, BuiltinThemes.editor);

            // Create a panel and position it in the top left corner
            Panel panel = new Panel(new Vector2(600, 200), PanelSkin.Default, Anchor.TopLeft, offset: new Vector2(10, 10))
            {
                Draggable = true
            };

            // Add title and close button
            Header header = new("Disclaimer:", Anchor.TopCenter);
            panel.AddChild(header);

            // create a horizontal line and add it to a panel we created before
            HorizontalLine hz = new(Anchor.AutoCenter);
            panel.AddChild(hz);

            Button closeButton = new("", ButtonSkin.Default, Anchor.TopRight, size: new Vector2(36, 36))
            {
                ToolTipText = "Close disclaimer",
                OnClick = (entity) =>
                {
                    panel.Visible = false;
                }
            };
            panel.AddChild(closeButton);

            LineSpace sp = new(1);
            panel.AddChild(sp);

            // Add version number text
            panel.AddChild(new RichParagraph(disclaimerText));

            UserInterface.Active.AddEntity(panel);



            // GeonBit.UI: tbd create your GUI layouts here.. (One time GUI setup, doesn't work with moving to the screen again)

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load any additional content here
            gameName = Content.Load<Texture2D>("Misc//GameName");
            menuBackground = Content.Load<Texture2D>("Misc//MenuBackground");
        }

        protected override void Update(GameTime gameTime)
        {
            // set window title 
            Window.Title = title;

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            else if (keyboardState.IsKeyDown(Keys.NumPad0))
            {
                pageMngr.Set(0);
                UserInterface.Active.Clear();
            }
            else if (keyboardState.IsKeyDown(Keys.NumPad1))
            {
                pageMngr.Set(1);
                UserInterface.Active.Clear();
            }
            else if (keyboardState.IsKeyDown(Keys.NumPad2))
            {
                pageMngr.Set(2);
                UserInterface.Active.Clear();
            }
            else if (keyboardState.IsKeyDown(Keys.NumPad3))
            {
                pageMngr.Set(3);
                UserInterface.Active.Clear();
            }
            else if (keyboardState.IsKeyDown(Keys.NumPad4))
            {
                pageMngr.Set(4);
                UserInterface.Active.Clear();
            }
            else if (keyboardState.IsKeyDown(Keys.NumPad5))
            {
                pageMngr.Set(5);
                UserInterface.Active.Clear();
            }
            else if (keyboardState.IsKeyDown(Keys.NumPad6))
            {
                pageMngr.Set(6);
                UserInterface.Active.Clear();
            }

            pageMngr.Update(gameTime, this);

            // GeonBit.UI update UI manager
            UserInterface.Active.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw the background
            spriteBatch.Begin();
            spriteBatch.Draw(menuBackground, GraphicsDevice.Viewport.Bounds, Color.White);
            spriteBatch.End();

            // Draw your game here
            spriteBatch.Begin();

            // Calculate the position of the texture
            Vector2 screenSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            Vector2 textureSize = new Vector2(gameName.Width, gameName.Height);
            Vector2 position = (screenSize - textureSize) / 2;
            position.Y -= 200;

            spriteBatch.Draw(gameName, position, Color.White);

            spriteBatch.End();

            pageMngr.Draw(this);

            // GeonBit.UI: draw UI using the spriteBatch you created above
            UserInterface.Active.Draw(spriteBatch);

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