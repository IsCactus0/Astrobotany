using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Particles
{
    public class Rain : Particle
    {
        public Rain()
            : base()
        {

        }
        public Rain(string name)
            : base(name)
        {

        }
        public Rain(string name, bool solid)
            : base(name, solid)
        {

        }
        public Rain(string name, bool solid, int size)
            : base(name, solid, size)
        {

        }
        public Rain(string name, bool solid, int width, int height)
            : base(name, solid, width, height)
        {

        }
        public Rain(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight)
        {

        }
        public Rain(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y)
        {

        }
        public Rain(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {

        }
        public Rain(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr)
        {

        }
        public Rain(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar)
        {

        }
        public Rain(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass)
        {

        }
        public Rain(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction)
        {

        }
        public Rain(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, Color colour)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction, colour)
        {

        }

        public override void Destroy()
        {
            base.Destroy();
        }
        public override void Update(float delta)
        {
            Force += new Vector2(2f, 9.8f) * 100f;

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            // Drawing.DrawLine(spriteBatch, Position - Velocity, Position, 2f, Colour);

            Drawing.DrawPoint(spriteBatch, Position, 3f, Color.Red);
        }
    }
}