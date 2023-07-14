using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Entities
{
    public abstract class Entity : PhysicsObject
    {
        protected Entity()
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0f;
        }
        protected Entity(string name)
            : base(name)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid)
            : base(name, solid)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid, int size)
            : base(name, solid, size)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid, int width, int height)
            : base(name, solid, width, height)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass)
        {
            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction)
        {

            Health = 100f;
            MaxHealth = 100f;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, float health)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction)
        {
            Health = health;
            MaxHealth = health;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, float health, float maxHealth)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction)
        {
            Health = health;
            MaxHealth = maxHealth;
            DamageResistance = 0f;
        }
        protected Entity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, float health, float maxHealth, float damageResist)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction)
        {
            Health = health;
            MaxHealth = maxHealth;
            DamageResistance = damageResist;
        }

        public float Health { get; set; }
        public float MaxHealth { get; protected set; }
        public float DamageResistance { get; protected set; }

        public virtual void Damage(float damage)
        {
            Health -= damage * Math.Clamp(1f - DamageResistance, 0f, 1f);
            if (Health <= 0)
                Destroy();
        }
        public override void Destroy()
        {
            Main.EntityManager.Entities.Remove(this);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            Drawing.DrawRectangle(spriteBatch, Hitbox, Color.Red * 0.5f);
            Drawing.DrawRectangle(spriteBatch, Sprite, Color.RoyalBlue * 0.5f);
        }
        public override string ToString()
        {
            string baseString = base.ToString();
            baseString.Replace(GetType().BaseType.Name, GetType().Name);

            return baseString +
                   $"\n   Health: {Health} / {MaxHealth}" +
                   $"\n   DamageResistance: {DamageResistance}";
        }
    }
}