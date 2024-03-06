using AstrobotanyLibrary.Classes.Enums;

namespace AstrobotanyLibrary.Classes.Objects.Items
{
    public class SeedItem : Item
    {
        public SeedItem()
            : base()
        {
            Category = ItemCategory.Seed;
            Plant = new Plant();
        }
        public SeedItem(string name)
            : base(name)
        {
            Category = ItemCategory.Seed;
            Plant = new Plant();
        }
        public SeedItem(string name, string description)
            : base(name, description)
        {
            Category = ItemCategory.Seed;
            Plant = new Plant();
        }
        public SeedItem(string name, string description, int value)
            : base(name, description, value)
        {
            Category = ItemCategory.Seed;
            Plant = new Plant();
        }
        public SeedItem(string name, string description, int value, int maxStack)
            : base(name, description, value, maxStack)
        {
            Plant = new Plant();
        }
        public SeedItem(string name, string description, int value, int maxStack, ItemCategory category)
            : base(name, description, value, maxStack, category)
        {
            Plant = new Plant();
        }

        public Plant Plant { get; set; }
    }
}