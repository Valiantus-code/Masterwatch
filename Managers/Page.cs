using System;
using Microsoft.Xna.Framework;

namespace Masterwatch.Managers
{
    public abstract class Page
    {
        public int id;

        public Page(int id)
        {
            this.id = id;
        }

        public abstract void Init(MainGame game);
        public abstract void Update(GameTime gameTime, MainGame game);
        public abstract void Draw(MainGame game);
    }
}
