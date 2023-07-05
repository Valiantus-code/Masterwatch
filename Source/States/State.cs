using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Masterwatch.Source.States
{
    public abstract class State
    {
        #region Fields

        protected ContentManager _content;
        protected GraphicsDevice _graphicsDevice;
        protected Game1 _game;
        protected UserInterface _userInterface;

        #endregion

        #region Methods

        public State(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;

            // Assign the UserInterface instance from Game1
            _userInterface = game.UI;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);

        public abstract void PostUpdate(GameTime gameTime);

        #endregion
    }
}
