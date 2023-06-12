using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;

namespace Masterwatch
{
    public class DisclaimerPanel : IDisposable
    {
        private readonly Panel panel;

        public DisclaimerPanel(string disclaimerText)
        {
            // Create a panel and position it in the top left corner
            panel = new Panel(new Vector2(600, 200), PanelSkin.Default, Anchor.TopLeft, offset: new Vector2(10, 10))
            {
                Draggable = true
            };
            UserInterface.Active.AddEntity(panel);

            // Add title and close button
            Header header = new("Disclaimer:", Anchor.TopCenter);
            panel.AddChild(header);

            // create a horizontal line and add it to a panel we created before
            HorizontalLine hz = new(Anchor.AutoCenter);
            panel.AddChild(hz);

            Button closeButton = new("", ButtonSkin.Default, Anchor.TopRight, size: new Vector2(36, 36))
            {
                ToolTipText = "Close disclaimer",
                OnClick = (entity) =>
                {
                    panel.Visible = false;
                }
            };
            panel.AddChild(closeButton);

            LineSpace sp = new(1);
            panel.AddChild(sp);

            // Add version number text
            panel.AddChild(new RichParagraph(disclaimerText));
        }

        public void Dispose()
        {
            panel.Dispose();
        }
    }
}