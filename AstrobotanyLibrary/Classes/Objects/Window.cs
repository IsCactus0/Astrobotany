using Microsoft.Xna.Framework.Graphics;
using System.Numerics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Window
    {
        public Window()
        {
            Title = string.Empty;
            Position = Vector2.Zero;
            Size = Vector2.Zero;
        }

        public string Title { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public void Update(float delta)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}