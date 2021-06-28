using Asteroids.Properties;
using Asteroids.Scenes;
using System;
using System.Drawing;

namespace Asteroids
{
    class Ship : BaseObject
    {
        private int energy = 100;
        public static event EventHandler DieEvent;

        public int Energy
        {
            get { return energy; }
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public void EnergyLow(int n)
        {
            energy -= n;
        }

        public void EnergyHigh(int n)
        {
            energy += n;
        }


        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.ship, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);

        }

        public override void Update() { }

        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        public void Left()
        {
            if (Pos.X > 0) Pos.X = Pos.X - Dir.X;
        }

        public void Right()
        { 
            if (Pos.X < Game.Width) Pos.X = Pos.X + Dir.X;
        }

        internal override void Die()
        {
            if (DieEvent != null)
                DieEvent.Invoke(this, new EventArgs());
        }

    }
}
