namespace AstrobotanyLibrary.Classes.Objects.Items
{
    public class ItemStack
    {
        public ItemStack(Item item)
        {
            Item = item;
            Count = 1;
        }
        public ItemStack(Item item, int count)
        {
            Item = item;
            Count = count;
        }

        public Item Item { get; set; }
        public int Count { get; set; }

        public bool CanStackWith(ItemStack other)
        {
            if (other.Item != Item)
                return false;

            if (other.Count + Count > Item.MaxStack)
                return false;

            return true;
        }
        public bool IncreaseCount(int amount = 1)
        {
            if (Count + amount > Item.MaxStack)
                return false;

            Count += amount;
            return true;
        }
        public bool DecreaseCount(int amount = 1)
        {
            if (Count < amount)
                return false;

            Count -= amount;
            return true;
        }
    }
}