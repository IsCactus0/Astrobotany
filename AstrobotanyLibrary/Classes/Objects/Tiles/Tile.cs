using AstrobotanyLibrary.Classes.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Tiles
{
    public abstract class Tile : GameObject
    {
        public Tile()
            : base()
        {
            Name = "Crate";
            Remove = false;
        }
        public Tile(int x, int y)
            : base(x, y)
        {
            Name = "Crate";
            Remove = false;
        }

        public bool Remove { get; set; }

        public virtual void Hover()
        {
            Main.InterfaceManager.DebugString = $"Tile: {this}";
        }
        public virtual void Click(MouseButton button)
        {
            if (button == MouseButton.Left)
                Destroy();
        }
        public override void Update(float delta)
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sprite = Sprite;
            spriteBatch.Draw(
                Main.AssetManager.GetTexture(Name),
                new Rectangle(
                    (int)((sprite.X - sprite.Y) * 16f),
                    (int)((sprite.X + sprite.Y) * 8f),
                    sprite.Width, sprite.Height),
                Color.White);
        }
        public override void Destroy()
        {
            Remove = true;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}