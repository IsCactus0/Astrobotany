using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Managers;

namespace AstrobotanyLibrary.Classes.Objects.Items
{

    public class Item
    {
        public Item()
        {
            Name = "";
            Description = "";
            Value = 0;
            MaxStack = 1;
            Category = ItemCategory.Misc;
        }
        public Item(string name)
        {
            Name = name;
            Description = "";
            Value = 0;
            MaxStack = 1;
            Category = ItemCategory.Misc;
        }
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
            Value = 0;
            MaxStack = 1;
            Category = ItemCategory.Misc;
        }
        public Item(string name, string description, int value)
        {
            Name = name;
            Description = description;
            Value = value;
            MaxStack = 1;
            Category = ItemCategory.Misc;
        }
        public Item(string name, string description, int value, int maxStack)
        {
            Name = name;
            Description = description;
            Value = value;
            MaxStack = maxStack;
            Category = ItemCategory.Misc;
        }
        public Item(string name, string description, int value, int maxStack, ItemCategory category)
        {
            Name = name;
            Description = description;
            Value = value;
            MaxStack = maxStack;
            Category = category;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int MaxStack { get; set; }
        public ItemCategory Category { get; set; }

        public override string ToString()
        {
            return AssetManager.FileName(Name);
        }
    }
}