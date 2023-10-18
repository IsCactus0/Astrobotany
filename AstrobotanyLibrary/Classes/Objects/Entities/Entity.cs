using AstrobotanyLibrary.Classes.Objects.Effects;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Entities
{
    public abstract class Entity : PhysicsObject
    {
        protected Entity()
            : base()
        {
            Health = 100f;
            TimeAlive = 0f;
            MaxHealth = 100f;
            DamageResistance = 0f;
            ImmunityTime = 0f;
            MaxImmunityTime = 1f;
            Effects = new List<EntityEffect>();
        }
        protected Entity(Entity copy)
            : base(copy)
        {
            Health = copy.Health;
            TimeAlive = copy.TimeAlive;
            MaxHealth = copy.MaxHealth;
            DamageResistance = copy.DamageResistance;
            ImmunityTime = copy.ImmunityTime;
            MaxImmunityTime = copy.MaxImmunityTime;
            Effects = new List<EntityEffect>(copy.Effects);
        }

        public float Health { get; set; }
        public float MaxHealth { get; protected set; }
        public float TimeAlive { get; set; }
        public float DamageResistance { get; protected set; }
        public float ImmunityTime { get; set; }
        public float MaxImmunityTime { get; set; }
        public List<EntityEffect> Effects { get; set; }

        public virtual void Damage(float damage)
        {
            if (ImmunityTime > 0f)
                return;

            ImmunityTime = MaxImmunityTime;

            Health -= damage / DamageResistance;
            if (Health <= 0)
                Destroy();
        }
        public override void Destroy()
        {
            Main.EntityManager.Entities.Remove(this);
        }
        public override void Update(float delta)
        {
            if (ImmunityTime > 0f)
                ImmunityTime -= delta;

            TimeAlive += delta;
            if (Health <= 0f)
                Destroy();

            for (int i = Effects.Count - 1; i >= 0; i--)
                Effects[i].Update(delta, this);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (EntityEffect effect in Effects)
                effect.Draw(spriteBatch, this);
        }
        public override string ToString()
        {
            string baseString = base.ToString();
            baseString.Replace(GetType().BaseType.Name, GetType().Name);

            string effects = "\n   Effects:";
            foreach (EntityEffect effect in Effects)
                effects += effect.ToString();

            return baseString +
                   $"\n   Health: {Health} / {MaxHealth}" +
                   $"\n   TimeAlive: {TimeAlive}" +
                   $"\n   DamageResistance: {DamageResistance}" +
                   $"\n   ImmunityTime: {ImmunityTime} / {MaxImmunityTime}" +
                   effects;
                   
        }
    }
}