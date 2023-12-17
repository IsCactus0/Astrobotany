namespace AstrobotanyLibrary.Classes.Objects.Items
{
    public static class Items
    {
        public static Item Capacitor = new Item()
        {
            Name = "Capacitor",
            Description =
                "A capacitor is a device that" +
                "stores electrical energy in an" +
                "electric field by virtue of" +
                "accumulating electric charges" +
                "on two close surfaces insulated" +
                "from each other.",
            Category = Enums.ItemCategory.Component,
            Value = 12
        };

        public static Item Battery = new Item()
        {
            Name = "Battery",
            Description =
                "A simple battery.",
            Category = Enums.ItemCategory.Component,
            Value = 6
        };
    }
}