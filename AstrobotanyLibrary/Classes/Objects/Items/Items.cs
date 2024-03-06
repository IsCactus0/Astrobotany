namespace AstrobotanyLibrary.Classes.Objects.Items
{
    public static class Items
    {
        public static readonly Item Capacitor = new ("Capacitor", "Stores an electrical charge.", 4, 8, Enums.ItemCategory.Component);
        public static readonly Item CircuitBoard = new ("Circuit Board", "A simple battery.", 2, 12, Enums.ItemCategory.Component);
        public static readonly Item Valve = new ("Valve", "Red valve.", 8, 12, Enums.ItemCategory.Component);
        public static readonly SeedItem SunflowerSeeds = new("Sunflower Seeds", "Makes a good snack.", 3, 12, Enums.ItemCategory.Seed);
    }
}