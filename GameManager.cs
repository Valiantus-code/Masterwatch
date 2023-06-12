using Microsoft.Xna.Framework;

namespace Masterwatch
{
    public class GameManager
    {
        private readonly Game game;

        public GameManager(Game game)
        {
            this.game = game;
        }

        public void StartGame()
        {
            GameScreen gameScreen = new GameScreen(game);
            //panel.Visible = false;

            // Load the new game screen using the screen manager
            //screenManager.LoadScreen(gameScreen);
        }


    }
}