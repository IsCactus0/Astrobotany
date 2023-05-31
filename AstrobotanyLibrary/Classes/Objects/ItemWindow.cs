using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class ItemWindow : Window
    {
        public ItemWindow(Item item)
        {
            Item = item;
        }
        public ItemWindow(Item item, Color backgroundColour)
            : base(item.Name, backgroundColour)
        {
            Item = item;
        }
        public ItemWindow(Item item, Color backgroundColour, Vector2 size)
            : base(item.Name, backgroundColour, size)
        {
            Item = item;
        }
        public ItemWindow(Item item, Color backgroundColour, Vector2 size, Vector2 position)
            : base(item.Name, backgroundColour, size, position)
        {
            Item = item;
        }

        public Item Item { get; private set; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}