using System.Windows.Forms;

namespace Asteroids.Scenes
{
    public interface IScene
    {
        void Init(Form form);
        void Draw();
    }
}
