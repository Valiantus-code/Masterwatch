using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masterwatch.Source.States
{
    internal class SettingsState : State
    {
        public SettingsState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Init stuff
            _game.Window.Title = "Settings State";

            // Load textures, etc. here

            UserInterface.Active.Clear(); // Clear the current UI

            #region Menu base Panel

            Panel menuBase = new Panel(new Vector2(800, 700), PanelSkin.None, Anchor.Center);
            UserInterface.Active.AddEntity(menuBase);

            #region Settings panel with tabs

            // create panel and add to list of panels and manager
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
                TabData tab = tabs.AddTab("Game settings");

                tab.panel.AddChild(new HorizontalLine(Anchor.AutoCenter, offset: new Vector2(0, 32)));
                tab.panel.AddChild(new Paragraph("PanelTab creates a group of internal panels with toggle buttons to switch between them.\nChoose a tab in the buttons above for more info..."));
            }

            // add second panel
            {
                TabData tab = tabs.AddTab("Video settings");

                tab.panel.AddChild(new HorizontalLine(Anchor.AutoCenter, offset: new Vector2(0, 32)));
                tab.panel.AddChild(new Paragraph("Awesome, you got to tab2!\nMaybe something interesting in tab3?"));
            }

            // add third panel
            {
                TabData tab = tabs.AddTab("Audio settings");

                tab.panel.AddChild(new HorizontalLine(Anchor.AutoCenter, offset: new Vector2(0, 32)));
                tab.panel.AddChild(new Paragraph("Nothing to see here."));
            }

            #endregion

            #endregion

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw logic here
            UserInterface.Active.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            // Update logic here
            UserInterface.Active.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // Remove sprites if they're not needed
        }
    }
}
