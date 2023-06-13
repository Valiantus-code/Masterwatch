using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Timers;

namespace Masterwatch.Managers
{
    public class PageManager
    {
        public List<Page> pages = new List<Page>();

        public int count
        {
            get
            {
                return pages.Count;
            }
        }

        public int selected;

        public void Update(GameTime gametime, MainGame game)
        {
            for (int i = 0; i < count; i++)
            {
                Page page = pages[i];
                if (page.id == selected)
                {
                    page.Update(gametime, game);
                }
            }
        }

        public void Draw(MainGame game)
        {
            for (int i = 0; i < count; i++)
            {
                Page page = pages[i];
                if (page.id == selected)
                {
                    page.Draw(game);
                }
            }
        }

        public virtual void Set(int id)
        {
            selected = id;
        }

        public virtual void Set(Page page)
        {
            selected = page.id;
        }

        public void Add(Page page, MainGame game)
        {
            // Add page to list
            pages.Add(page);
            // Initialize page in game
            page.Init(game);
        }
        public void Remove(Page page) 
        {
            // Remove page from  list
            pages.Remove(page); 
        }
        public void Clear() 
        {
            pages.Clear();
        }
    }
}
