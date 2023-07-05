using Microsoft.Xna.Framework;

namespace Masterwatch.Source.Engine
{
    public static class Globals
    {
        public static string versionNumber = "Version: 0.5.19";

        private static int _screenWidth = 1280;
        public static int ScreenWidth
        {
            get { return _screenWidth; }
            set
            {
                _screenWidth = value;
                UpdateGraphicsDevice();
            }
        }

        private static int _screenHeight = 720;
        public static int ScreenHeight
        {
            get { return _screenHeight; }
            set
            {
                _screenHeight = value;
                UpdateGraphicsDevice();
            }
        }

        private static GraphicsDeviceManager _graphics;
        private static bool _isFullscreen = false;

        internal static void Initialize(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
            UpdateGraphicsDevice();
        }

        public static bool IsFullscreen
        {
            get { return _isFullscreen; }
            set
            {
                _isFullscreen = value;
                UpdateGraphicsDevice();
            }
        }

        private static void UpdateGraphicsDevice()
        {
            if (_graphics != null)
            {
                _graphics.PreferredBackBufferWidth = _screenWidth;
                _graphics.PreferredBackBufferHeight = _screenHeight;
                _graphics.IsFullScreen = _isFullscreen;
                _graphics.ApplyChanges();
            }
        }
    }
}
