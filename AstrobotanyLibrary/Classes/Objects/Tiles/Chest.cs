namespace AstrobotanyLibrary.Classes.Objects.Tiles
{
    public class Chest : ContainerTile
    {
        public Chest()
            : base()
        {
            Name = "Chest";
            Inventory.Name = "Chest";
            Solid = true;
        }
        public Chest(int x, int y)
            : base(x, y)
        {
            Name = "Chest";
            Inventory.Name = "Chest";
            Solid = true;
        }

        public override void Update(float delta)
        {

        }
    }
}