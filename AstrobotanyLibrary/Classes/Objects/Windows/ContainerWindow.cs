using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Windows
{
    public class ContainerWindow : MovableWindow
    {
        public ContainerWindow()
            : base()
        {
            Inventory = new Inventory();
        }
        public ContainerWindow(string title)
            : base(title)
        {
            Inventory = new Inventory();
        }
        public ContainerWindow(string title, Color backgroundColour)
            : base(title, backgroundColour)
        {
            Inventory = new Inventory();
        }
        public ContainerWindow(string title, Color backgroundColour, Vector2 position)
            : base(title, backgroundColour, position)
        {
            Inventory = new Inventory();
        }
        public ContainerWindow(string title, Color backgroundColour, Vector2 position, int inventorySize)
            : base(title, backgroundColour, position)
        {
            Inventory = new Inventory(inventorySize);
        }
        public ContainerWindow(string title, Color backgroundColour, Vector2 position, int inventoryWidth, int inventoryHeight)
            : base(title, backgroundColour, position)
        {
            Inventory = new Inventory(inventoryWidth, inventoryHeight);
        }

        public Inventory Inventory { get; set; }

        public override void Update(float delta)
        {
            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            for (int x = 0; x < Inventory.Items.GetLength(0); x++)
            {
                for (int y = 0; y < Inventory.Items.GetLength(1); y++)
                {
                    Drawing.DrawRectangle(
                        spriteBatch,
                        new Rectangle(
                            (int)Position.X + 12 + x * 51,
                            (int)Position.Y + 70 + y * 51,
                            48, 48),
                        new Color(26, 21, 28) * 0.8f);

                    if (Inventory.Items[x, y] is not null)
                        spriteBatch.Draw(
                            Main.AssetManager.GetTexture(Inventory.Items[x, y].Item.Name),
                            new Rectangle(x * 51, y * 51, 48, 48),
                            Color.White * 0.8f);
                }
            }
        }
        public override Rectangle CalculateSize()
        {
            return new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                Inventory.Items.GetLength(0) * 51 + 21,
                Inventory.Items.GetLength(1) * 51 + 79);
        }
    }
}