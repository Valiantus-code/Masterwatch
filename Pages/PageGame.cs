using Masterwatch.Managers;
using Masterwatch.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Masterwatch.Pages
{
    public class PageGame : Page
    {
        // create instance of things
        public ObjectManager objMngr = new ObjectManager();
        Block block = new Block(128, 128);
        private string Version = "Version: 1.3.0";

        // Title for debug of which screen is selected
        string title = "Masterwatch - Game";

        public PageGame() : base(PageID.game)
        {

        }

        public override void Init(MainGame game)
        {
            // add the block(some object) to objectmanager
            objMngr.Add(block, game);

        }

        public override void Update(GameTime gameTime, MainGame game)
        {
            objMngr.Update(gameTime, game);
            // set the window title to count of objects from object manager
            //game.Window.Title = objMngr.count.ToString();

            // set window title 
            game.Window.Title = title;

        }

        public override void Draw(MainGame game)
        {
            // clear
            game.GraphicsDevice.Clear(Color.Green);

            //begin
            game.spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //objs
            objMngr.Draw(game);
            //end
            game.spriteBatch.End();

        }
    }
}
