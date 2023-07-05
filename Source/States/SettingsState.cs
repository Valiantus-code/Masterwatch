using GeonBit.UI;
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
    internal class SettingsState : State
    {
        public SettingsState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Init stuff
            _game.Window.Title = "Settings State";

            // Load textures, etc. here

            _userInterface.Clear(); // Clear the current UI

            #region Menu base Panel

            Panel menuBase = new Panel(new Vector2(800, 650), PanelSkin.None, Anchor.TopCenter);
            _userInterface.AddEntity(menuBase);

            #region Settings panel with tabs

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
                TabData tab = tabs.AddTab("Game settings");

                tab.panel.AddChild(new HorizontalLine(Anchor.AutoCenter, offset: new Vector2(0, 32)));


            }

            // add second panel
            {
                TabData tab = tabs.AddTab("Video settings");

                tab.panel.AddChild(new HorizontalLine(Anchor.AutoInline, offset: new Vector2(0, 32)));

                #region Window mode

                Paragraph windowMode = new Paragraph("Window mode:", Anchor.AutoInline);
                tab.panel.AddChild(windowMode);

                // window or fullscreen selection
                RadioButton windowedMode = new RadioButton("Windowed", Anchor.AutoInline, new Vector2(200, 50), isChecked: true);
                tab.panel.AddChild(windowedMode);

                RadioButton fullscreenMode = new RadioButton("Fullscreen", Anchor.AutoInline, new Vector2(200, 50));
                tab.panel.AddChild(fullscreenMode);

                windowedMode.OnValueChange = (Entity entity) =>
                {
                    if (windowedMode.Checked)
                    {
                        Globals.IsFullscreen = false; // Set the game window to windowed mode
                    }
                };

                fullscreenMode.OnValueChange = (Entity entity) =>
                {
                    if (fullscreenMode.Checked)
                    {
                        Globals.IsFullscreen = true; // Set the game window to fullscreen mode
                    }
                };

                #endregion

                tab.panel.AddChild(new HorizontalLine(Anchor.AutoInline));

                #region Resolution
                tab.panel.AddChild(new Paragraph("Resolution:"));
                DropDown resolution = new DropDown(new Vector2(400, 200));
                resolution.DefaultText = "Default - 1280x720";
                resolution.AddItem("2560x1440");
                resolution.AddItem("1920x1080");
                resolution.AddItem("1440x900");
                resolution.AddItem("1280x720");
                tab.panel.AddChild(resolution);

                // Event handler for the dropdown list's value change
                resolution.OnValueChange += (entity) =>
                {
                    string selectedResolution = resolution.SelectedValue;
                    string[] dimensions = selectedResolution.Split('x');
                    if (dimensions.Length == 2)
                    {
                        int width = int.Parse(dimensions[0]);
                        int height = int.Parse(dimensions[1]);

                        // Set the ScreenWidth and ScreenHeight based on the selected resolution
                        Globals.ScreenWidth = width;
                        Globals.ScreenHeight = height;
                    }
                };
                #endregion

                tab.panel.AddChild(new HorizontalLine(Anchor.AutoInline));

                #region GUI scale
                // scale show
                Paragraph scaleShow = new Paragraph("GUI scale:" + "100%", Anchor.AutoInline);
                tab.panel.AddChild(scaleShow);

                // zoom in / out factor
                float zoominFactor = 0.05f;
                float zoomDefault = 1f;

                // init default button
                Button defaultZoom = new Button("Default", ButtonSkin.Default, Anchor.AutoInline, new Vector2(200, 50));

                defaultZoom.OnClick = (Entity btn) => {
                    _userInterface.GlobalScale = zoomDefault;
                    scaleShow.Text = ("GUI scale: " + (int)System.Math.Round(_userInterface.GlobalScale * 100f)).ToString() + "%";
                };
                tab.panel.AddChild(defaultZoom);

                // init zoom-out button
                Button zoomout = new Button(string.Empty, ButtonSkin.Default, Anchor.AutoInline, new Vector2(50, 50), new Vector2(25, 0));
                Icon zoomoutIcon = new Icon(IconType.ZoomOut, Anchor.Center, 0.25f);
                zoomout.AddChild(zoomoutIcon, true);
                zoomout.OnClick = (Entity btn) => {
                    if (_userInterface.GlobalScale > 0.5f)
                        _userInterface.GlobalScale -= zoominFactor;
                    scaleShow.Text = ("GUI scale: " + (int)System.Math.Round(_userInterface.GlobalScale * 100f)).ToString() + "%";
                };
                tab.panel.AddChild(zoomout);

                // init zoom-in button
                Button zoomin = new Button(string.Empty, ButtonSkin.Default, Anchor.AutoInline, new Vector2(50, 50), new Vector2(25, 0));
                Icon zoominIcon = new Icon(IconType.ZoomIn, Anchor.Center, 0.25f);
                zoomin.AddChild(zoominIcon, true);
                zoomin.OnClick = (Entity btn) => {
                    if (_userInterface.GlobalScale < 1.45f)
                        _userInterface.GlobalScale += zoominFactor;
                    scaleShow.Text = ("GUI scale: " + (int)System.Math.Round(_userInterface.GlobalScale * 100f)).ToString() + "%";
                };
                tab.panel.AddChild(zoomin);

                // extra scaleShow paragraph update to display current scale % after re-opening settings state
                scaleShow.Text = ("GUI scale: " + (int)System.Math.Round(_userInterface.GlobalScale * 100f)).ToString() + "%";

                #endregion

            }

            // add third panel
            {
                TabData tab = tabs.AddTab("Audio settings");

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
