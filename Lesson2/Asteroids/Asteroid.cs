using Asteroids.Properties;
using System;
using System.Drawing;

namespace Asteroids
{
    class Asteroid : BaseObject
    {
        private int index;
        static Random r = new Random();
        public Asteroid(Point pos, Point dir, Size size) : base (pos, dir, size)
        {
            index = r.Next(1, 4);
        }

        public override void Draw()
        {
            switch (index)
            {
                case 1:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.asteroid01, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
                    break;
                case 2:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.asteroid02, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
                    break;
                case 3:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.asteroid03, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
                    break;
                case 4:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.asteroid04, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
                    break;
            }
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
        
        internal override void Die()        
        {
            int nAngle = r.Next(1, 4);
            switch (nAngle)
            {
                case 1:
                    Pos.X = 1;
                    Pos.Y = 1;
                    break;
                case 2:
                    Pos.X = Game.Width-1;
                    Pos.Y = 1;
                    break;
                case 3:
                    Pos.X = Game.Width - 1;
                    Pos.Y = Game.Height - 1;
                    break;
                case 4:
                    Pos.X = 1;
                    Pos.Y = Game.Height - 1;
                    break;
            }
        }


    }
}
