using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public abstract class Entity : PhysicsObject
    {
        public Entity()
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0.0f;
        }
        public Entity(float x, float y)
            : base(x, y)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0.0f;
        }
        public Entity(float x, float y, float vx, float vy)
            : base(x, y, vx, vy)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0.0f;
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay)
            : base(x, y, vx, vy, ax, ay)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0.0f;
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float maxHealth)
            : base(x, y, vx, vy, ax, ay)
        {
            Health = maxHealth;
            MaxHealth = maxHealth;
            DamageResistance = 0.0f;
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float health, float maxHealth)
            : base(x, y, vx, vy, ax, ay)
        {
            Health = health;
            MaxHealth = maxHealth;
            DamageResistance = 0.0f;
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float health, float maxHealth, float damageResist)
            : base(x, y, vx, vy, ax, ay)
        {
            Health = health;
            MaxHealth = maxHealth;
            DamageResistance = damageResist;
        }

        public float Health { get; set; }
        public float MaxHealth { get; protected set; }
        public float DamageResistance { get; protected set; }

        public override void Destroy()
        {
            Main.EntityManager.Entities.Remove(this);
        }
        public virtual void Damage(float damage)
        {
            Health -= damage * Math.Clamp(1f - DamageResistance, 0f, 1f);
            if (Health <= 0)
                Destroy();
        }
        public override void Update(float delta)
        {
            base.Update(delta);
        }
    }
}