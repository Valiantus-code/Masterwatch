using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;

namespace Masterwatch
{
    public class SettingsScreen : IDisposable
    {
        private Panel panel;
        private Button closeButton;

        public SettingsScreen()
        {
            CreatePanel();
            CreateTabs();
            CreateCloseButton();
        }

        private void CreatePanel()
        {
            // Create a panel for the settings screen
            panel = new Panel(new Vector2(1000, 600), PanelSkin.Default, Anchor.Center)
            {
                Draggable = true
            };
            UserInterface.Active.AddEntity(panel);
        }

        private void CreateTabs()
        {
            // create panel tabs
            PanelTabs tabs = new PanelTabs();
            tabs.BackgroundSkin = PanelSkin.Default;
            panel.AddChild(tabs);

            // add first panel
            {
                TabData tab = tabs.AddTab("Gameplay Settings");
                tab.panel.AddChild(new Header("Changing settings may require a restart!"));
                tab.panel.AddChild(new HorizontalLine());

                tab.panel.AddChild(new Paragraph(""));

            }

            // add second panel
            {
                TabData tab = tabs.AddTab("Video Settings");
                tab.panel.AddChild(new Header("Changing settings may require a restart!"));
                tab.panel.AddChild(new HorizontalLine());

                tab.panel.AddChild(new Paragraph("Change window mode:"));

                Panel panel = new Panel(new Vector2(270, 200), PanelSkin.Simple, Anchor.AutoInline);
                tab.panel.AddChild(panel);

                // create a radio button with the label "1920 x 1080", and add it to a panel we created before
                RadioButton radio = new RadioButton("1920 x 1080");
                radio.Checked = true;
                radio.OnValueChange = (Entity entity) =>
                {
                    // resolution change logic here
                };
                panel.AddChild(radio);

                // create a radio button with the label "1280 x 720", and add it to a panel we created before
                RadioButton radio2 = new RadioButton("1280 x 720");
                radio2.OnValueChange = (Entity entity) =>
                {
                    // radio was changed, do something here!
                };
                panel.AddChild(radio2);

                // create a radio button with the label "960 x 540", and add it to a panel we created before
                RadioButton radio3 = new RadioButton("960 x 540");
                radio3.OnValueChange = (Entity entity) =>
                {
                    // radio was changed, do something here!
                };
                panel.AddChild(radio3);

                tab.panel.AddChild(new HorizontalLine());


            }

            // add third panel
            {
                TabData tab = tabs.AddTab("Audio Settings");
                tab.panel.AddChild(new Header("Changing settings may require a restart!"));
                tab.panel.AddChild(new HorizontalLine());

                tab.panel.AddChild(new Paragraph(""));


            }

        }

        private void CreateCloseButton()
        {
            closeButton = new Button("", ButtonSkin.Default, Anchor.TopRight, size: new Vector2(36, 36), offset: new Vector2(0, 50));
            closeButton.OnClick = (entity) =>
            {
                Hide();
            };
            panel.AddChild(closeButton);
        }

        public void Show()
        {
            panel.Visible = true;
        }

        public void Hide()
        {
            panel.Visible = false;
        }

        public void Dispose()
        {
            panel.Dispose();
        }

    }
}