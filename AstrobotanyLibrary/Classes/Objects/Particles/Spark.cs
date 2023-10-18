using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Objects.Particles
{
    public class Spark : Particle
    {
        public Spark(bool solid)
            : base(solid)
        {

        }
        public Spark(bool solid, int size)
            : base(solid, size)
        {

        }
        public Spark(bool solid, int width, int height) 
            : base(solid, width, height)
        {

        }
        public Spark(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight) 
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight)
        {

        }
        public Spark(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y) 
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y)
        {

        }
        public Spark(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r) 
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {

        }
        public Spark(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr) 
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr)
        {

        }
        public Spark(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar) 
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar)
        {

        }
        public Spark(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass) 
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass)
        {

        }
        public Spark(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction) 
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction)
        {

        }
        public Spark(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, Color colour) 
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction, colour)
        {

        }
    }
}