using Masterwatch.Managers;
using Microsoft.Xna.Framework;

namespace Masterwatch.Pages
{
    // Change PageName to the name of the page class
    public class PageName : Page
    {
        // Change PageName to the name of the page class and change 'PageID.name' to the ID of the page in PageID.cs
        public PageName() : base(PageID.name)
        {

        }

        public override void Init(MainGame game)
        {

        }

        public override void Update(GameTime gameTime, MainGame game)
        {

        }

        public override void Draw(MainGame game)
        {
            // clear
            game.GraphicsDevice.Clear(Color.DarkSlateGray);

        }
    }
}
