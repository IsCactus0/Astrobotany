using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public abstract class GameObject
    {
        public GameObject()
        {
            Position = Vector2.Zero;
        }
        public GameObject(float x, float y)
        {
            Position = new Vector2(x, y);
        }

        public Vector2 Position { get; set; }

        public abstract void Destroy();
        public abstract void Update(float delta);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}