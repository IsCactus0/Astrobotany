using AstrobotanyLibrary.Classes.Enums;

namespace AstrobotanyLibrary.Classes.Objects.Items
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
    
        public bool AddItem(ItemStack itemStack)
        {
            for (int y = 0; y < Items.GetLength(1); y++)
                for (int x = 0; x < Items.GetLength(0); x++)
                {
                    // Check if slot is empty.
                    if (Items[x, y] is null)
                    {
                        Items[x, y] = itemStack;
                        return true;
                    }

                    // Check if items are the same.
                    if (Items[x, y].Item.Name != itemStack.Item.Name)
                        continue;

                    // Merge stacks together if enough space is left.
                    if (Items[x, y].Count + itemStack.Count <= Items[x, y].MaxStack)
                    {
                        Items[x, y].Count += itemStack.Count;
                        return true;
                    }

                    // Add remaining items to original item then make new stack.
                    int remaining = Items[x, y].MaxStack - Items[x, y].Count;
                    itemStack.Count -= remaining;
                    Items[x, y].Count = Items[x, y].MaxStack;

                }

            return false;
        }
        public bool SortItems(SortMode sortMode = SortMode.Count)
        {
            switch (sortMode)
            {
                case SortMode.Count:
                    List<ItemStack> items = new List<ItemStack>();

                    for (int y = 0; y < Items.GetLength(1); y++)
                        for (int x = 0; x < Items.GetLength(0); x++)
                            if (Items[x, y] is not null)
                                items.Add(Items[x, y]);
                    
                    if (items.Count == 0)
                        return false;

                    Array.Clear(Items);
                    items.OrderBy(x => x.Count).ToList();
                    foreach (ItemStack item in items)
                        AddItem(item);

                    return true;

                default:
                    return false;
            }
        }
    }
}