using AstrobotanyLibrary.Classes.Objects.Items;
using AstrobotanyLibrary.Classes.Objects.Pathfinding;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Entities
{
    public abstract class Character : AnimatedEntity
    {
        protected Character()
            : base()
        {
            MoveSpeed = 100f;
            Path = new NavPath();
            Inventory = new Inventory();
        }
        protected Character(Character copy)
        {
            MoveSpeed = copy.MoveSpeed;
            Path = new NavPath(copy.Path);
            Inventory = copy.Inventory;
        }

        public float MoveSpeed { get; protected set; }
        public float LastMoved { get; protected set; }
        public NavPath Path { get; set; }
        public Inventory Inventory { get; protected set; }

        public override void Update(float delta)
        {
            LastMoved += delta;
            if (LastMoved >= MoveSpeed &&
                Path is not null &&
                Path.Steps.Count > 0)
            {
                LastMoved = 0f;
                Position = Path.Steps[0].ToVector2();
                Path.Steps.RemoveAt(0);
            }

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            Path.Draw(spriteBatch);
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