using Asteroids.Properties;
using Asteroids.Scenes;
using System;
using System.Drawing;

namespace Asteroids
{
    class Asteroid : BaseObject 
    {
        private int index;
        Random r = new Random();
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

            index = r.Next(1, 5);
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
            if (Pos.X < 0)
            {
                Pos.X = Game.Width;
                Dir.X = -Dir.X;
            }
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
        }

        internal override void Die()
        {
            //пока не убиваем а начинаем с конца экрана заново
            Pos.X = Game.Width - 1;
            var random = new Random();
            Pos.Y = random.Next(10, Game.Height - 10);
        }

    }
}
