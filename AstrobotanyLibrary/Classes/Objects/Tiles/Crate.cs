namespace AstrobotanyLibrary.Classes.Objects.Tiles
{
    public class Crate : ContainerTile
    {
        public Crate()
            : base()
        {
            Name = "Crate";
            Inventory.Name = "Crate";
            Solid = true;
        }
        public Crate(int x, int y)
            : base(x, y)
        {
            Name = "Crate";
            Inventory.Name = "Crate";
            Solid = true;
        }

        public override void Update(float delta)
        {
            return;
            // base.Update(delta);
        }
    }
}