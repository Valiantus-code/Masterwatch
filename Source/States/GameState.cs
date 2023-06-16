using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Masterwatch.Source.States
{
    public class GameState : State
    {
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Init stuff
            _game.Window.Title = "Game State";

            // Load textures, etc. here



            UserInterface.Active.Clear(); // Clear the current UI

            // Build the UI here

            Panel panel = new Panel(new Vector2(400f, 200f), PanelSkin.Default, Anchor.Center); // Make a new panel
            UserInterface.Active.AddEntity(panel); // Add the panel to the cleared UI
            Paragraph paragraph = new Paragraph("GameState");
            panel.AddChild(paragraph);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw logic here
            UserInterface.Active.Draw(spriteBatch);
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
            UserInterface.Active.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // Remove sprites if they're not needed
        }
    }
}
