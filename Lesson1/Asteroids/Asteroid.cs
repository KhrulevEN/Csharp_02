using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum TypeAsteroid
{
    TA_ONE = 0,
    TA_TWO = 1,
    TA_THREE = 2
};


namespace Asteroids
{


    class Asteroid
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;




        public Asteroid(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw(TypeAsteroid typeastroid)
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            switch (typeastroid)
            {
                case TypeAsteroid.TA_ONE:
                    Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big1, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
                case TypeAsteroid.TA_TWO:
                    Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big2, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
                case TypeAsteroid.TA_THREE:
                    Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big3, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
            }


        }


        public virtual void Update()
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
