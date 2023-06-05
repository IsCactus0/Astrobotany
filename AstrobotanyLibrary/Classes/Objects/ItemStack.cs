namespace AstrobotanyLibrary.Classes.Objects
{
    public class ItemStack
    {
        public ItemStack(Item item)
        {
            Item = item;
            Count = 1;
            MaxStack = 1;
        }
        public ItemStack(Item item, int maxCount)
        {
            Item = item;
            Count = 1;
            MaxStack = maxCount;
        }
        public ItemStack(Item item, int count, int maxCount)
        {
            Item = item;
            Count = count;
            MaxStack = maxCount;
        }

        public Item Item { get; set; }
        public int Count { get; set; }
        public int MaxStack { get; set; }
    }
}