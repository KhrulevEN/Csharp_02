using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Star : Asteroid
    {
        public Star (Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw(TypeAsteroid typeastroid)
        {
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            switch (typeastroid)
            {
                case TypeAsteroid.TA_ONE:
                    Game.Buffer.Graphics.DrawImage(Resources.star1, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
                case TypeAsteroid.TA_TWO:
                    Game.Buffer.Graphics.DrawImage(Resources.star2, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
                case TypeAsteroid.TA_THREE:
                    Game.Buffer.Graphics.DrawImage(Resources.star3, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
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
    }
}
