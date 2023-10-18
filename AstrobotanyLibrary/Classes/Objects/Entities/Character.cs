using AstrobotanyLibrary.Classes.Objects.Items;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Entities
{
    public abstract class Character : AnimatedEntity
    {
        protected Character()
            : base()
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(Character copy)
        {
            MoveSpeed = copy.MoveSpeed;
            Inventory = copy.Inventory;
        }

        public float MoveSpeed { get; protected set; }
        public Inventory Inventory { get; protected set; }

        public override void Update(float delta)
        {
            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public override string ToString()
        {
            string baseString = base.ToString();
            baseString.Replace(GetType().BaseType.Name, GetType().Name);

            return baseString +
                   $"\n   MoveSpeed: {Health} / {MaxHealth}" +
                   $"\n   Inventory: {DamageResistance}";
        }
    }
}