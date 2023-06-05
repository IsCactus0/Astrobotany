using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public abstract class Character : Entity
    {
        public Character()
            : base()
        {
            Inventory = new Inventory();
        }

        public Inventory Inventory { get; protected set; }

        public override void Destroy()
        {
            
        }
        public override void Update(float delta)
        {
            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}