using AstrobotanyLibrary.Classes.Objects.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Windows
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
        public ItemWindow(Item item, Color backgroundColour, Vector2 position)
            : base(item.Name, backgroundColour, position)
        {
            Item = item;
        }

        public Item Item { get; private set; }

        public override void Update(float delta)
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}