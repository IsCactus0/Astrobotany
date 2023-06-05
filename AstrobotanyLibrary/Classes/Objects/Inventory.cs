namespace AstrobotanyLibrary.Classes.Objects
{
    public class Inventory
    {
        public Inventory()
        {
            Items = new ItemStack[1, 1];
        }
        public Inventory(int size)
        {
            Items = new ItemStack[size, size];
        }
        public Inventory(int width, int height)
        {
            Items = new ItemStack[width, height];
        }

        public ItemStack[,] Items { get; set; }
    }
}