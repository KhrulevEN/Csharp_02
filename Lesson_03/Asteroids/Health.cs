using Asteroids.Properties;
using Asteroids.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Health : BaseObject
    {
        public Health(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.health, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
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
            //пока не убиваем а начинаем с конца экрана занов
            Pos.X = Game.Width - 1;
            var random = new Random();            
            Pos.Y = random.Next(10, Game.Height - 10);
        }
    }
}
