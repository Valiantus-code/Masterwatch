using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using System.Xml.Linq;

namespace Masterwatch.Managers
{
    public abstract class GameObject
    {
        //dimensions
        public float x, y;
        public float xSpeed, ySpeed;
        public int width, height;
        public Vector2 position { get { return new Vector2(x, y); } set { x = value.X; y = value.Y; } }
        public Vector2 speed { get { return new Vector2(xSpeed, ySpeed); } set { x = value.X; y = value.Y; } }
        public Vector2 size { get { return new Vector2(width, height); } set { x = value.X; y = value.Y; } }

        public Rectangle bounds;

        // properties
        public int id;
        public string text, tag;
        public bool rendered, visible;
        public bool collission, hover;

        // sprite
        public Vector2 spritePOS;

        public GameObject(int x, int y, int width, int height, int id)
        {
            //dimensions
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            bounds = new Rectangle(x, y, width, height);

            // properties
            this.id = id;
            rendered = true;
            visible = true;
            collission = false;
            hover = false;
            spritePOS = new Vector2(0, 0);
        }

        // abstract functions
        public abstract void Init(MainGame game);
        public abstract void Destroy(MainGame game);
        public abstract void Update(GameTime gameTime, MainGame game);
        public abstract void Draw(MainGame game);

        // sets
        public void SetPosition(float x, float y) 
        {
            this.x = x;
            this.y = y;
        }

        public void SetSpeed(float xSpd, float ySpd)
        {
            this.xSpeed = xSpd;
            this.ySpeed = ySpd;
        }

        public void SetSize(int w, int h)
        {
            this.width = w;
            this.height = h;
        }

        public void SetBounds(float x, float y, int w, int h)
        {
            this.bounds = new Rectangle((int)x, (int)y, w, h);
        }

        // gets
        public int GetID()
        {
            return id;
        }
        public float DistanceTo(Vector2 pos)
        {
            return Vector2.Distance(position, pos);
        }

        public Vector2 GetPositionCentered()
        {
            return new Vector2(x + (width / 2), y + (height / 2));
        }
    }
}
