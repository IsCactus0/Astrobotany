using AstrobotanyLibrary.Classes.Enums;

namespace AstrobotanyLibrary.Classes.Objects
{

    public class Item
    {
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
            Category = ItemCategory.Misc;
        }
        public Item(string name, string description, ItemCategory category)
        {
            Name = name;
            Description = description;
            Category = category;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public ItemCategory Category { get; set; }
    }
}