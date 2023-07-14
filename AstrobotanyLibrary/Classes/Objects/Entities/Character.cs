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
        protected Character(string name)
            : base(name)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid)
            : base(name, solid)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int size)
            : base(name, solid, size)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int width, int height)
            : base(name, solid, width, height)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, float health)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction, health)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, float health, float maxHealth)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction, health, maxHealth)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, float health, float maxHealth, float damageResist)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction, health, maxHealth, damageResist)
        {
            MoveSpeed = 100f;
            Inventory = new Inventory();
        }
        protected Character(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, float health, float maxHealth, float damageResist, float moveSpeed)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction, health, maxHealth, damageResist)
        {
            MoveSpeed = moveSpeed;
            Inventory = new Inventory();
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
    }
}