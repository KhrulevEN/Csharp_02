using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class GameObjectException : Exception
    {
        public GameObjectException()
        {            
            Game.Buffer.Graphics.DrawString($"{base.Message}", new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold), 
                Brushes.White, 10, 200);
            Game.Buffer.Render();
        }
    }

    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            try { 
                Pos = pos;
                if (pos.X < 0 || pos.Y < 0)
                {
                    throw new GameObjectException();
                }
                Dir = dir;
                if (Math.Abs(Dir.X- Pos.X)>50 || Math.Abs(Dir.Y - Pos.Y) > 50)
                {
                    //throw new GameObjectException();
                }
                Size = size;
                if (Size.Width<=0 || Size.Height<=0)
                {
                    throw new GameObjectException();
                }
            }
            catch (GameObjectException)
            {

            }

        }

        public Rectangle Rect => new Rectangle(Pos, Size);

        public bool Collision(BaseObject obj)
        {
            return obj.Rect.IntersectsWith(Rect);
        }

        public abstract void Draw();


        public abstract void Update();
        internal abstract void Die();
    }
}
