using AstrobotanyLibrary.Classes.Objects.Items;
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
            ItemWindow = new ItemWindow(null);
        }
        public ContainerWindow(string title)
            : base(title)
        {
            Inventory = new Inventory();
            ItemWindow = new ItemWindow(null);
        }
        public ContainerWindow(string title, Color backgroundColour)
            : base(title, backgroundColour)
        {
            Inventory = new Inventory();
            ItemWindow = new ItemWindow(null);
        }
        public ContainerWindow(string title, Color backgroundColour, Vector2 position)
            : base(title, backgroundColour, position)
        {
            Inventory = new Inventory();
            ItemWindow = new ItemWindow(null);
        }
        public ContainerWindow(string title, Color backgroundColour, Vector2 position, int inventorySize)
            : base(title, backgroundColour, position)
        {
            Inventory = new Inventory(inventorySize);
            ItemWindow = new ItemWindow(null);
        }
        public ContainerWindow(string title, Color backgroundColour, Vector2 position, int inventoryWidth, int inventoryHeight)
            : base(title, backgroundColour, position)
        {
            Inventory = new Inventory(inventoryWidth, inventoryHeight);
            ItemWindow = new ItemWindow(null);
        }

        public Inventory Inventory { get; set; }
        public ItemWindow ItemWindow { get; set; }
        public Rectangle ItemRectangle
        {
            get
            {
                Rectangle temp = CalculateSize();
                temp.X += 12;
                temp.Y += 70;
                temp.Width -= 24;
                temp.Height -= 140;

                return temp;
            }
        }

        public override void Update(float delta)
        {
            Vector2 mousePos = Main.InputManager.MouseScreenPosition();
            int index = Main.InterfaceManager.Windows.FindIndex(x => x == this);

            if (!MathAdditions.PointIntersects(mousePos.ToPoint(), ItemRectangle))
                return;

            Vector2 itemIndex = Main.InputManager.MouseScreenPosition() - Position;
            itemIndex /= 51.0f;
            itemIndex.Floor();

            Point indexP = itemIndex.ToPoint();
            ItemStack itemStack = Inventory.Items[indexP.X, indexP.Y];

            if (itemStack is not null)
            {
                ItemWindow.Visible = true;
                ItemWindow.Item  = itemStack.Item;
            }

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            for (int x = 0; x < Inventory.Items.GetLength(0); x++)
                for (int y = 0; y < Inventory.Items.GetLength(1); y++)
                {
                    Drawing.DrawRectangle(
                        spriteBatch,
                        new Rectangle(
                            (int)Position.X + 12 + x * 51,
                            (int)Position.Y + 70 + y * 51,
                            48, 48),
                        new Color(28, 28, 28, 204));

                    if (Inventory.Items[x, y] is not null)
                        spriteBatch.Draw(
                            Main.AssetManager.GetTexture($"Items/{Inventory.Items[x, y].Item.Name}"),
                            new Rectangle(
                                (int)Position.X + 12 + x * 51,
                                (int)Position.Y + 70 + y * 51, 48, 48),
                            Color.White * 0.8f);
                }

            ItemWindow.Draw(spriteBatch);
        }
        public override void Remove()
        {
            ItemWindow.Remove();
            base.Remove();
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