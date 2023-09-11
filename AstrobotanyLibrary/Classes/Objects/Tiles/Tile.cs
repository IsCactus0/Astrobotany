using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Tiles
{
    public class Tile
    {
        public Tile()
        {
            Position = Vector3.Zero;
            Name = "";
        }
        public Tile(float x, float y, float z)
        {
            Position = new Vector3(x, y, z);
            Name = "";
        }
        public Tile(float x, float y, float z, string name)
        {
            Position = new Vector3(x, y, z);
            Name = name;
        }

        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)Position.X * 16,
                    (int)(Position.Y + Position.Z) * 16,
                    32,
                    32);
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Main.AssetManager.GetTexture(Name),
                new Rectangle(
                    (int)((Position.X - (Position.Y + Position.Z)) * 16f),
                    (int)((Position.X + (Position.Y + Position.Z)) * 8f),
                    32, 32),
                Color.White);
        }
    }
}