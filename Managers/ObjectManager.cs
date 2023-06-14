using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Masterwatch.Managers
{
    public class ObjectManager
    {
        public List<GameObject> objects = new List<GameObject>();
        public int count { get { return objects.Count; } }

        public ObjectManager()
        {

        }

        public void Update(GameTime gameTime, MainGame game)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject obj = objects[i];

                if (obj.rendered)
                {
                    obj.SetBounds(obj.x, obj.y, obj.width, obj.height);
                    obj.Update(gameTime, game);
                }
            }
        }

        public void Draw(MainGame game)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject obj = objects[i];

                if (obj.rendered && obj.visible)
                {
                    obj.Draw(game);
                }
            }
        }

        // sets
        public void Add(GameObject obj, MainGame game)
        {
            objects.Add(obj);
            obj.Init(game);
        }

        public virtual void Remove(GameObject obj, MainGame game)
        {
            objects.Remove(obj);
            obj.Destroy(game);
        }

        public virtual void Remove(int index, MainGame game)
        {
            objects[index].Destroy(game);
            objects.Remove(objects[index]);
        }

        public void Clear() { objects.Clear(); }

        // gets
        public int GetCount() { return objects.Count; }

    }

}
