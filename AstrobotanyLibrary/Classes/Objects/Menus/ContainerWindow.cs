using AstrobotanyLibrary.Classes.Managers;
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
            Spacing = 6;
            SlotSize = 16;
            Inventory = new Inventory();
            Size = new Vector2(SlotSize + (Spacing * 2), SlotSize + (Spacing * 3));
        }
        public ContainerWindow(float x, float y)
            : base(x, y)
        {
            Spacing = 6;
            SlotSize = 16;
            Inventory = new Inventory();
            Size = new Vector2(SlotSize + (Spacing * 2), SlotSize + (Spacing * 3));
        }
        public ContainerWindow(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
            Spacing = 6;
            SlotSize = 16;
            Inventory = new Inventory();
            Size = new Vector2(SlotSize + (Spacing * 2), SlotSize + (Spacing * 3));
        }
        public ContainerWindow(float x, float y, float width, float height, string text)
            : base(x, y, width, height, text)
        {
            Spacing = 6;
            SlotSize = 16;
            Inventory = new Inventory();
            Size = new Vector2(SlotSize + (Spacing * 2), SlotSize + (Spacing * 3));
        }
        public ContainerWindow(float x, float y, float width, float height, string text, float textScale)
            : base(x, y, width, height, text, textScale)
        {
            Spacing = 6;
            SlotSize = 16;
            Inventory = new Inventory();
            Size = new Vector2(SlotSize + (Spacing * 2), SlotSize + (Spacing * 3));
        }
        public ContainerWindow(float x, float y, float width, float height, string text, float textScale, Color colour)
            : base(x, y, width, height, text, textScale, colour)
        {
            Spacing = 6;
            SlotSize = 16;
            Inventory = new Inventory();
            Size = new Vector2(SlotSize + (Spacing * 2), SlotSize + (Spacing * 3));
        }
        public ContainerWindow(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour)
            : base(x, y, width, height, text, textScale, colour, textColour)
        {
            Spacing = 6;
            SlotSize = 16;
            Inventory = new Inventory();
            Size = new Vector2(SlotSize + (Spacing * 2), SlotSize + (Spacing * 3));
        }
        public ContainerWindow(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour, float spacing)
            : base(x, y, width, height, text, textScale, colour, textColour)
        {
            Spacing = spacing;
            SlotSize = 16;
            Inventory = new Inventory();
            Size = new Vector2(SlotSize + (Spacing * 2), SlotSize + (Spacing * 3));
        }
        public ContainerWindow(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour, float spacing, float slotSize)
            : base(x, y, width, height, text, textScale, colour, textColour)
        {
            Spacing = spacing;
            SlotSize = slotSize;
            Inventory = new Inventory();
            Size = new Vector2(SlotSize + (Spacing * 2), SlotSize + (Spacing * 3));
        }
        public ContainerWindow(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour, float spacing, float slotSize, int inventorySize)
            : base(x, y, width, height, text, textScale, colour, textColour)
        {
            Spacing = spacing;
            SlotSize = slotSize;
            Inventory = new Inventory(inventorySize);
            Size = new Vector2(
                (SlotSize + Spacing) * inventorySize + Spacing,
                (SlotSize + Spacing) * inventorySize + Spacing * 2);
        }
        public ContainerWindow(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour, float spacing, float slotSize, int inventoryWidth, int inventoryHeight)
            : base(x, y, width, height, text, textScale, colour, textColour)
        {
            Spacing = spacing;
            SlotSize = slotSize;
            Inventory = new Inventory(inventoryWidth, inventoryHeight);
            Size = new Vector2(
                (SlotSize + Spacing) * inventoryWidth + Spacing,
                (SlotSize + Spacing) * inventoryHeight + Spacing * 2);
        }
        public ContainerWindow(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour, float spacing, float slotSize, Inventory inventory)
            : base(x, y, width, height, text, textScale, colour, textColour)
        {
            Spacing = spacing;
            SlotSize = slotSize;
            Inventory = inventory;
            Size = new Vector2(
                (SlotSize + Spacing) * inventory.Items.GetLength(0) + Spacing,
                (SlotSize + Spacing) * inventory.Items.GetLength(1) + Spacing * 2);
        }

        public float Spacing { get; set; }
        public float SlotSize { get; set; }
        public Inventory Inventory { get; set; }
        public ItemStack ItemHovering { get; protected set; }
        public Rectangle ItemBounds
        {
            get
            {
                return new Rectangle(
                    (int)(Position.X + Spacing * Main.InterfaceManager.Scale),
                    (int)(Position.Y + Spacing * 2 * Main.InterfaceManager.Scale),
                    (int)((Size.X - Spacing) * Main.InterfaceManager.Scale),
                    (int)((Size.Y - Spacing * 2) * Main.InterfaceManager.Scale));
            }
        }

        public override void Hover()
        {
            ItemHovering = null;

            Vector2 mousePos = Main.InterfaceManager.Cursor.Position;
            if (MathAdditions.VectorIntersects(mousePos, ItemBounds))
            {
                Point index = GetItemIndex(mousePos);
                if (index.X >= 0 && index.X < Inventory.Items.GetLength(0) &&
                    index.Y >= 0 && index.Y < Inventory.Items.GetLength(1))
                    ItemHovering = Inventory.Items[index.X, index.Y];
            }

            base.Hover();
        }
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
                    Vector2 offset = new Vector2(Spacing + x * (SlotSize + Spacing), Spacing + y * (SlotSize + Spacing) + 2) * Main.InterfaceManager.Scale;
                    Vector2 pos = new(Position.X + offset.X, Position.Y + offset.Y);

                    Drawing.DrawRectangle(spriteBatch, pos, new Vector2(SlotSize) * Main.InterfaceManager.Scale, Colour);
                    if (Inventory.Items[x, y] is not null)
                    {
                        Drawing.DrawSprite(spriteBatch,
                            Main.AssetManager.GetTexture($"Items/{AssetManager.FileName(Inventory.Items[x, y].Item.Name)}"),
                            pos + new Vector2(1.25f * Main.InterfaceManager.Scale),
                            new Vector2(SlotSize - 2.5f) * Main.InterfaceManager.Scale,
                            Color.White, false, 0f);
                    }
                }
            }

            if (ItemHovering is not null)
            {
                Vector2 position = Main.InterfaceManager.Cursor.Position;
            
                Drawing.DrawString(spriteBatch,
                    Main.AssetManager.GetFont("Montserrat", Enums.FontWeight.SemiBold),
                    ItemHovering.Item.Name,
                    position + new Vector2(4f * Main.InterfaceManager.Scale, 0),
                    Color.White,
                    Enums.AlignmentVertical.Centre,
                    Enums.AlignmentHorizontal.Left,
                    0.1f * Main.InterfaceManager.Scale);
            }
        }
        public virtual Point GetItemIndex(Vector2 mousePos)
        {
            Rectangle bounds = ItemBounds;
            Vector2 relative = mousePos - bounds.Location.ToVector2();
            float slot = SlotSize / (SlotSize + Spacing);
            int width = Inventory.Items.GetLength(0);
            int height = Inventory.Items.GetLength(1);
            float x = relative.X / bounds.Width * width;
            float y = relative.Y / bounds.Height * height;
            int xi = (int)Math.Truncate(x);
            int yi = (int)Math.Truncate(y);

            if (x - xi <= slot && y - yi <= slot)
                return new Point(xi, yi);
            else return new Point(-1);
        }
    }
}