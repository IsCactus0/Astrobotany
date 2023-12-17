namespace AstrobotanyLibrary.Classes.Objects.Tiles
{
    public class WoodenCrate : ContainerTile
    {
        public WoodenCrate()
            : base()
        {
            Name = "Crate";
            Inventory.Name = "Wooden Crate";
            Solid = true;
        }
        public WoodenCrate(int x, int y)
            : base(x, y)
        {
            Name = "Crate";
            Inventory.Name = "Wooden Crate";
            Solid = true;
        }
    }
}