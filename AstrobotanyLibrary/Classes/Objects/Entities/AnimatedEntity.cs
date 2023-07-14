using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Entities
{
    public abstract class AnimatedEntity : Entity
    {
        protected AnimatedEntity()
            : base()
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name)
            : base(name)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid)
            : base(name, solid)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid, int size)
            : base(name, solid, size)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid, int width, int height)
            : base(name, solid, width, height)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, float health)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction, health)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, float health, float maxHealth)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction, health, maxHealth)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, float health, float maxHealth, float damageResist)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction, health, maxHealth, damageResist)
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }

        public string CurrentAnimation { get; set; }
        public Dictionary<string, Animation> Animations { get; set; }

        public override void Update(float delta)
        {
            if (!string.IsNullOrEmpty(CurrentAnimation))
                Animations[CurrentAnimation].Update(delta);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Animations[CurrentAnimation].Texture,
                new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    32, 32),
                Color.White);
        }
    }
}