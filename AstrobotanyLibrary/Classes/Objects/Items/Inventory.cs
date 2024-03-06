using AstrobotanyLibrary.Classes.Enums;
using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Objects.Items
{
    public class Inventory
    {
        public Inventory()
        {
            Name = "";
            Items = new ItemStack[1, 1];
        }
        public Inventory(int size)
        {
            Name = "";
            Items = new ItemStack[size, size];
        }
        public Inventory(int width, int height)
        {
            Name = "";
            Items = new ItemStack[width, height];
        }
        public Inventory(int width, int height, string name)
        {
            Name = name;
            Items = new ItemStack[width, height];
        }

        public string Name { get; set; }
        public ItemStack[,] Items { get; set; }
    
        public void Clear()
        {
            Array.Clear(Items, 0, Items.Length);
        }
        public bool AddItemToSlot(ItemStack itemStack, int x, int y)
        {
            // Check if slot is empty.
            if (Items[x, y] is null)
            {
                Items[x, y] = itemStack;
                return true;
            }

            // Check if items are the same.
            if (Items[x, y].Item == itemStack.Item)
                return false;

            // Merge stacks together if enough space is left.
            if (Items[x, y].Count + itemStack.Count <= Items[x, y].Item.MaxStack)
            {
                Items[x, y].Count += itemStack.Count;
                return true;
            }

            // Add remaining items to original item then make new stack.
            int remaining = Items[x, y].Item.MaxStack - Items[x, y].Count;
            itemStack.Count -= remaining;
            Items[x, y].Count = Items[x, y].Item.MaxStack;
            return true;
        }
        public bool AddItem(ItemStack itemStack)
        {
            for (int y = 0; y < Items.GetLength(1); y++)
                for (int x = 0; x < Items.GetLength(0); x++)
                    if (AddItemToSlot(itemStack, x, y))
                        return true;

            return false;
        }
        public bool SortItems(SortMode sortMode = SortMode.Count)
        {
            switch (sortMode)
            {
                case SortMode.Count:
                    List<ItemStack> items = new();

                    for (int y = 0; y < Items.GetLength(1); y++)
                        for (int x = 0; x < Items.GetLength(0); x++)
                            if (Items[x, y] is not null)
                                items.Add(Items[x, y]);
                    
                    if (items.Count == 0)
                        return false;

                    Array.Clear(Items);
                    items = items.OrderBy(x => x.Count).ToList();
                    foreach (ItemStack item in items)
                        AddItem(item);

                    return true;

                default:
                    return false;
            }
        }
        public override string ToString()
        {
            string baseString = base.ToString();
            baseString = baseString.Replace(GetType().BaseType.Name, GetType().Name);

            string items = "";
            int width = Items.GetLength(0);
            int height = Items.GetLength(1);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    items += $"\n      {Items[x, y].Item}";

            return baseString +
                   $"\n   Name: {Name}" +
                   $"\n   Size: {Items.GetLength(0)} x {Items.GetLength(1)}" +
                   $"\n   Items: {items}";
        }
    }
}