using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Objects.Items;
using AstrobotanyLibrary.Classes.Objects.Menus;
using AstrobotanyLibrary.Classes.Objects.Windows;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Tiles {
    public abstract class Tile : GameObject {
        public Tile()
            : base() {
            Name = "";
            Remove = false;
        }
        public Tile(int x, int y)
            : base(x, y) {
            Name = "";
            Remove = false;
        }

        public bool Remove { get; set; }

        public abstract void Drop(ItemStack stack);
        public virtual void Hover(float delta) {
            return;
        }
        public virtual void Click(float delta, MouseButton button = MouseButton.Left) {
            if (button == MouseButton.Right) {
                SingleWindow window = new SingleWindow(
                    Main.InterfaceManager.Cursor.Position.X - 5.5f * Main.InterfaceManager.Scale,
                    Main.InterfaceManager.Cursor.Position.Y - 5.5f * Main.InterfaceManager.Scale,
                    32, 11, "Open", 0.3f,
                    Color.White, new Color(157, 157, 157));
                window.ReleaseActivated += () => { window.Remove(); Destroy(); };
                Main.InterfaceManager.Elements.Add(window);
            }

            if (button == MouseButton.Left)
                Destroy();
        }
        public override void Draw(SpriteBatch spriteBatch) {
            Rectangle sprite = Sprite;
            Texture2D texture = Main.AssetManager.GetTexture("Tiles/" + Name);
            Drawing.DrawSprite(spriteBatch,
                texture,
                new Vector2(
                    ((Position.X + sprite.X) - (Position.Y + sprite.Y)) * 16f,
                    ((Position.X + sprite.X) + (Position.Y + sprite.Y)) * 8f),
                new Vector2(sprite.Width, sprite.Height),
                Color.White,
                false,
                Main.SceneManager.Layer.LayerDepth(
                    (int)(Position.X + sprite.Location.X),
                    (int)(Position.Y + sprite.Location.Y)));
        }
        public override void Destroy() {
            Remove = true;
        }
        public override string ToString() {
            return base.ToString();
        }
    }
}