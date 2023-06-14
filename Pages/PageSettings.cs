using Masterwatch.Managers;
using Microsoft.Xna.Framework;

namespace Masterwatch.Pages
{
    public class PageSettings : Page
    {
        // Title for debug of which screen is selected
        string title = "Masterwatch - Settings";

        public PageSettings() : base(PageID.settings)
        {

        }

        public override void Init(MainGame game)
        {

        }

        public override void Update(GameTime gameTime, MainGame game)
        {
            // set window title 
            game.Window.Title = title;
        }

        public override void Draw(MainGame game)
        {
            // clear
            game.GraphicsDevice.Clear(Color.DarkSlateGray);

        }
    }
}
