using AstrobotanyLibrary.Classes.Enums;

namespace AstrobotanyLibrary.Classes.Objects.Items
{

    public class Item
    {
        public Item()
        {
            Name = "";
            Description = "";
            Value = 0;
            Category = ItemCategory.Misc;
        }
        public Item(string name)
        {
            Name = name;
            Description = "";
            Value = 0;
            Category = ItemCategory.Misc;
        }
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
            Value = 0;
            Category = ItemCategory.Misc;
        }
        public Item(string name, string description, int value)
        {
            Name = name;
            Description = description;
            Value = value;
            Category = ItemCategory.Misc;
        }
        public Item(string name, string description, int value, ItemCategory category)
        {
            Name = name;
            Description = description;
            Value = value;
            Category = category;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public ItemCategory Category { get; set; }
    }
}