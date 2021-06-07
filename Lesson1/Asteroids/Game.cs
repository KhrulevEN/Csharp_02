using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static Asteroid[] _asteroids1;
        static Asteroid[] _asteroids2;
        static Asteroid[] _asteroids3;
        static Asteroid[] _stars1;
        static Asteroid[] _stars2;
        static Asteroid[] _stars3;

        public static int Width { get; set; }
        public static int Height { get; set; }


        public static void Init(Form form)
        {

            _context = BufferedGraphicsManager.Current;
           Graphics g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));           
           

            Load();

            Timer timer = new Timer();
            timer.Interval = 60;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);      
            Buffer.Graphics.DrawImage(Resources.background, new Rectangle(0, 0, Width, Height)); // отрисуем фон

            foreach (var star in _stars1)
            {
                star.Draw(TypeAsteroid.TA_ONE);
            }
            foreach (var star in _stars2)
            {
                star.Draw(TypeAsteroid.TA_TWO);
            }
            foreach (var star in _stars3)
            {
                star.Draw(TypeAsteroid.TA_THREE);
            }

            Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.DrawImage(Resources.planet, new Rectangle(100, 100, 200, 200)); // отрисуем планету  

            Buffer.Graphics.FillEllipse(Brushes.Blue, new Rectangle(400, 350, 200, 200));
            Buffer.Graphics.DrawImage(Resources.planet, new Rectangle(400, 350, 200, 200)); // отрисуем планету  

            foreach (var asteroid in _asteroids1)
            {
                asteroid.Draw(TypeAsteroid.TA_ONE);
            }
            foreach (var asteroid in _asteroids2)
            {
                asteroid.Draw(TypeAsteroid.TA_TWO);
            }

            foreach (var asteroid in _asteroids3)
            {
                asteroid.Draw(TypeAsteroid.TA_THREE);
            }


            Buffer.Render();
        }

        public static void Update()
        {
            foreach(var asteroid in _asteroids1)
            {
                asteroid.Update();
            }
            foreach (var asteroid in _asteroids2)
            {
                asteroid.Update();
            }
            foreach (var asteroid in _asteroids3)
            {
                asteroid.Update();
            }

            foreach (var star in _stars1)
            {
                star.Update();
            }
            foreach (var star in _stars2)
            {
                star.Update();
            }
            foreach (var star in _stars3)
            {
                star.Update();
            }
        }

        public static void Load()
        {
            var random = new Random();

            _asteroids1 = new Asteroid[5];
            for (int i = 0; i < _asteroids1.Length; i++)
            {
                var size = random.Next(20, 40);
                _asteroids1[i] = new Asteroid(new Point(600, i * 20 + 5), new Point(-i + 2, -i + 2), new Size(size, size));                
            }

            _asteroids2 = new Asteroid[5];
            for (int i = 0; i < _asteroids1.Length; i++)
            {
                var size = random.Next(20, 30);
                _asteroids2[i] = new Asteroid(new Point(400, i * 20 + 5), new Point(-i + 2, -i + 2), new Size(size, size));
            }

            _asteroids3 = new Asteroid[5];
            for (int i = 0; i < _asteroids3.Length; i++)
            {
                var size = random.Next(25, 35);
                _asteroids3[i] = new Asteroid(new Point(200, i * 20 + 5), new Point(-i + 2, -i + 2), new Size(size, size));
            }

            _stars1 = new Asteroid[7];
            for (int i = 0; i < _stars1.Length; i++)
            {
                var size = random.Next(10, 20);
                _stars1[i] = new Star(new Point(600, i * 40), new Point(-i, -i), new Size(size, size));
            }
            _stars2 = new Asteroid[7];
            for (int i = 0; i < _stars2.Length; i++)
            {
                var size = random.Next(10, 20);
                _stars2[i] = new Star(new Point(400, i * 40), new Point(-i, -i), new Size(size, size));
            }
            _stars3 = new Asteroid[7];
            for (int i = 0; i < _stars3.Length; i++)
            {
                var size = random.Next(10, 20);
                _stars3[i] = new Star(new Point(200, i * 40), new Point(-i, -i), new Size(size, size));
            }
        }


    }
}
