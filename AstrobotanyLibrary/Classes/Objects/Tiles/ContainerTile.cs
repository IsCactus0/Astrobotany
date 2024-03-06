using AstrobotanyLibrary.Classes.Objects.Items;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Tiles
{
    public abstract class ContainerTile : Tile
    {
        public ContainerTile()
            : base()
        {
            Inventory = new Inventory(3, 3);
        }
        public ContainerTile(int x, int y)
            : base(x, y)
        {
            Inventory = new Inventory(3, 3);
        }
        public ContainerTile(int x, int y, int sizeX, int sizeY)
            : base(x, y)
        {
            Inventory = new Inventory(sizeX, sizeY);
        }
        public ContainerTile(int x, int y, int sizeX, int sizeY, string name)
            : base(x, y)
        {
            Inventory = new Inventory(sizeX, sizeY, name);
        }

        public Inventory Inventory;

        public override void Drop(ItemStack stack)
        {
            Inventory.AddItem(stack);
        }
        public override void Hover(float delta)
        {
            base.Hover(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public override void Reset()
        {
            Inventory.Clear();
            base.Reset();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}