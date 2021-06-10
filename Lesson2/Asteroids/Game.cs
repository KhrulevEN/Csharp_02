using Asteroids.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{

    static class Game
    {
        static BaseObject[] _asteroids;
        static BaseObject[] _stars;
        static Bullet _bullet;
        static Timer _timer;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;


        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
        public static void Init(Form form)
        {          
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            if (!Load())
            {
                return;
            }
            _timer = new Timer { Interval = 60 };
            _timer.Start();
            _timer.Tick += Timer_Tick;

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            try
            {
                if (Width > 1000 || Height > 1000 || Width < 0 || Height < 0)
                {

                    throw new ArgumentOutOfRangeException();

                }
            }
            catch (ArgumentOutOfRangeException)
            {
                _timer.Stop();
                Buffer.Graphics.DrawString("Ширина и высота экрана не должны превышать 1000!", new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold), Brushes.White, 10, 200);
                Buffer.Render();
                return;
            }
            finally
            {
            }

            foreach (BaseObject obj in _stars)
                obj.Draw();

            Buffer.Graphics.DrawImage(new Bitmap(Resources.planet, new Size(200, 200)), 100, 100);

            foreach (BaseObject obj in _asteroids)
                obj.Draw();

            _bullet.Draw();

            Buffer.Render();
        }

        public static bool Load()
        {

            try
            {
                _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(54, 9));

                var random = new Random();
                _asteroids = new BaseObject[15];
                for (int i = 0; i < _asteroids.Length; i++)
                {
                    var size = random.Next(10, 40);
                    _asteroids[i] = new Asteroid(new Point(600, i * 20), new Point(-i, -i), new Size(size, size));
                }
                _stars = new BaseObject[20];
                for (int i = 0; i < _stars.Length; i++)
                    _stars[i] = new Star(new Point(600, i * 40), new Point(-i, -i), new Size(3, 3));
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static void Update()
        {
            foreach (BaseObject obj in _asteroids)
                obj.Update();
            foreach (BaseObject obj in _stars)
                obj.Update();

            _bullet.Update();


            foreach(var asteroid in _asteroids)
            {
                if (asteroid.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    asteroid.Die();
                }

            }


        }

    }
}
