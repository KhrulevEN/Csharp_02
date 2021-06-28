using Asteroids.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids.Scenes
{
    public delegate void MyDelegate();

    public class Game : BaseScene
    {
        public event MyDelegate JournalConsole;

        const int MAX_POINTS = 20;
        
        private int _countAteroids;//вспомогательная переменная пока нет коллекции
        private int _points;
        private BaseObject[] _asteroids;
        private BaseObject[] _stars;
        //private BaseObject[] _healths;        
        private BaseObject _health;
        private Bullet _bullet;
        private Ship _ship;
        private Timer _timer;
        private Random random = new Random();

        public override void Init(Form form)
        {
            base.Init(form);

            Load();

            _timer = new Timer { Interval = 60 };
            _timer.Start();
            _timer.Tick += Timer_Tick;
            Ship.DieEvent += Finish;            
        }

        public override void SceneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 21), new Point(5, 0), new Size(54, 9));
            }
            if (e.KeyCode == Keys.Up)
            {
                _ship.Up();
            }
            if (e.KeyCode == Keys.Down)
            {
                _ship.Down();
            }
            if (e.KeyCode == Keys.Left)
            {
                _ship.Left();
            }
            if (e.KeyCode == Keys.Right)
            {
                _ship.Right();
            }
            if (e.KeyCode == Keys.Back)
            {
                SceneManager
                    .Get()
                    .Init<MenuScene>(_form)
                    .Draw();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public void ShowJournal()
        {
            if (_ship != null)
            {
                _ship.Draw();
                Buffer.Graphics.DrawString($"Energy: {_ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
            }

            Buffer.Graphics.DrawString($"Points: {_points} из {MAX_POINTS}", SystemFonts.DefaultFont, Brushes.White, 0, 15);//_asteroids.Length
            if (_points >= MAX_POINTS)
            {
                _timer.Enabled = false;
                Buffer.Graphics.DrawString("You win!!!", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.Yellow, 180, 100);
                Buffer.Graphics.DrawString("<Backspace> - в меню", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.Yellow, 80, 200);
            }
        }


        public override void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            foreach (var obj in _stars)
                obj.Draw();

            Buffer.Graphics.DrawImage(new Bitmap(Resources.planet, new Size(200, 200)), 100, 100);

            foreach (var asteroid in _asteroids)
                if (asteroid != null)
                    asteroid.Draw();

            if (_bullet != null)
                _bullet.Draw();

            JournalConsole.Invoke();
/*
            if (_ship != null)
            {
                _ship.Draw();
                Buffer.Graphics.DrawString($"Energy: {_ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
            }

            Buffer.Graphics.DrawString($"Points: {_points} из {MAX_POINTS}", SystemFonts.DefaultFont, Brushes.White, 0, 15);//_asteroids.Length
            if (_points >= MAX_POINTS)
            {
                _timer.Enabled = false;
                Buffer.Graphics.DrawString("You win!!!", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.Yellow, 180, 100);
                Buffer.Graphics.DrawString("<Backspace> - в меню", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.Yellow, 80, 200);
            }
*/
            _health.Draw();


            Buffer.Render();
        }

        public void Load()
        {
            _points = 0;

             _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(45, 50));
            Ship.DieEvent += Finish;

            var random = new Random();            
            var countAteroids = random.Next(5, 10);
            _countAteroids = countAteroids;
            _asteroids = new Asteroid[countAteroids];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var sizeAsteroid = random.Next(30, 40);
                var speedAsteroid = random.Next(5, 10);                
                _asteroids[i] = new Asteroid(new Point(750, i * (600 / countAteroids)), new Point(-speedAsteroid, 0), new Size(sizeAsteroid, sizeAsteroid));
            }
            _stars = new Star[20];
            for (int i = 0; i < _stars.Length; i++)
                _stars[i] = new Star(new Point(600, i * 40), new Point(-i, -i), new Size(3, 3));

            var speedHealth = random.Next(3, 8);
            var sizeHealth = random.Next(30, 40);
            var xHealth = random.Next(300, 700);
            var yHealth = random.Next(100, 500);
            _health = new Health(new Point(xHealth, yHealth), new Point(-speedHealth, 0), new Size(sizeHealth, sizeHealth));

            JournalConsole = ShowJournal;


        }

        public void Update()
        {

            _countAteroids = 0;
            for (int i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _countAteroids++;

                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    //_asteroids[i] = null;
                    _asteroids[i].Die();
                    _points++;
                    _bullet = null;
                    continue;
                }

                if (_ship != null && _ship.Collision(_asteroids[i]))
                {
                    _ship.EnergyLow(random.Next(1, 10));
                    System.Media.SystemSounds.Hand.Play();

                    if (_ship.Energy <= 0)
                        _ship.Die();
                }


            }

            _health.Update();

            if (_ship != null && _ship.Collision(_health))
            {
                _ship.EnergyHigh(random.Next(1, 10));
                System.Media.SystemSounds.Hand.Play();
                _health.Die();
            }


            foreach (var obj in _stars)
                obj.Update();

            if (_bullet != null)
                _bullet.Update();
        }

        private void Finish(object sender, EventArgs e)
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.White, 180, 100);
            Buffer.Graphics.DrawString("<Backspace> - в меню", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.White, 80, 200);
            Buffer.Render();
        }

        public override void Dispose()
        {
            base.Dispose();
            _timer.Stop();
        }

    }
}
