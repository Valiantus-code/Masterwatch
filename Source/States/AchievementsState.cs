using GeonBit.UI.Entities;
using Masterwatch.Source.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masterwatch.Source.States
{
    internal class AchievementsState : State
    {
        public AchievementsState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Init stuff
            _game.Window.Title = "Settings State";

            // Load textures, etc. here

            _userInterface.Clear(); // Clear the current UI

            #region Menu base Panel

            Panel menuBase = new Panel(new Vector2(800, 650), PanelSkin.None, Anchor.TopCenter);
            _userInterface.AddEntity(menuBase);

            #region Achievements panel with tabs

            // create panel
            Panel panel = new Panel(new Vector2(0, 0), skin: PanelSkin.None);
            menuBase.AddChild(panel);

            // create panel tabs
            PanelTabs tabs = new PanelTabs();
            tabs.BackgroundSkin = PanelSkin.Default;
            panel.AddChild(tabs);

            Button exitSettingsButton = new Button(string.Empty, ButtonSkin.Default, Anchor.TopRight, new Vector2(32, 32), offset: new Vector2(0, 54));
            exitSettingsButton.OnClick = (Entity btn) =>
            {
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
            };
            tabs.AddChild(exitSettingsButton);

            // add first panel
            {
                TabData tab = tabs.AddTab("General");

                tab.panel.AddChild(new HorizontalLine(Anchor.AutoCenter, offset: new Vector2(0, 32)));



            }

            // add second panel
            {
                TabData tab = tabs.AddTab("Skill");

                tab.panel.AddChild(new HorizontalLine(Anchor.AutoInline, offset: new Vector2(0, 32)));



            }

            // add third panel
            {
                TabData tab = tabs.AddTab("Slayer");

                tab.panel.AddChild(new HorizontalLine(Anchor.AutoCenter, offset: new Vector2(0, 32)));



            }

            // add fourth panel
            {
                TabData tab = tabs.AddTab("Secret");

                tab.panel.AddChild(new HorizontalLine(Anchor.AutoCenter, offset: new Vector2(0, 32)));



            }

            #endregion

            #endregion

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw logic here
            _userInterface.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            #region Keyboard checks
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
            }
            #endregion

            // Update logic here
            _userInterface.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // Remove sprites if they're not needed
        }
    }
}
