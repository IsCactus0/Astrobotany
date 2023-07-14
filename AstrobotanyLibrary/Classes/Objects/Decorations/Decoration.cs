using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Decorations
{
    public abstract class Decoration : GameObject
    {
        protected Decoration()
            : base()
        {

        }
        protected Decoration(string name)
            : base(name)
        {

        }
        protected Decoration(string name, bool solid)
            : base(name, solid)
        {

        }
        protected Decoration(string name, bool solid, int size)
            : base(name, solid, size)
        {
            
        }
        protected Decoration(string name, bool solid, int width, int height)
            : base(name, solid, width, height)
        {
            
        }
        protected Decoration(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight)
        {
            
        }
        protected Decoration(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y)
        {
            
        }
        protected Decoration(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {
            
        }

        public override void Destroy()
        {
            Main.DecorationManager.Decorations.Remove(this);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}