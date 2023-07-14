using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Tiles
{
    public class Tile
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)Position.X * 16,
                    (int)Position.Y * 16,
                    32,
                    32);
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Main.AssetManager.GetTexture(Name),
                new Rectangle(
                    (int)((Position.X - Position.Y) * 16f),
                    (int)((Position.X + Position.Y) * 8f),
                    32, 32),
                Color.White);
        }
    }
}