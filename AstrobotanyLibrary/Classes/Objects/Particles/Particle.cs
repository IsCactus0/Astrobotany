using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Particles
{
    public abstract class Particle : PhysicsObject
    {
        protected Particle()
            : base()
        {
            Colour = Color.White;
        }
        protected Particle(string name)
            : base(name)
        {
            Colour = Color.White;
        }
        protected Particle(string name, bool solid)
            : base(name, solid)
        {
            Colour = Color.White;
        }
        protected Particle(string name, bool solid, int size)
            : base(name, solid, size)
        {
            Colour = Color.White;
        }
        protected Particle(string name, bool solid, int width, int height)
            : base(name, solid, width, height)
        {
            Colour = Color.White;
        }
        protected Particle(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight)
        {
            Colour = Color.White;
        }
        protected Particle(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y)
        {
            Colour = Color.White;
        }
        protected Particle(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {
            Colour = Color.White;
        }
        protected Particle(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr)
        {
            Colour = Color.White;
        }
        protected Particle(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar)
        {
            Colour = Color.White;
        }
        protected Particle(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass)
        {
            Colour = Color.White;
        }
        protected Particle(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction)
        {
            Colour = Color.White;
        }
        protected Particle(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, Color colour)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction)
        {
            Colour = colour;
        }

        public Color Colour { get; set; }

        public override void Destroy()
        {
            Main.ParticleManager.Particles.Remove(this);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Drawing.DrawPoint(spriteBatch, Position, 3f, Colour);
        }
    }
}