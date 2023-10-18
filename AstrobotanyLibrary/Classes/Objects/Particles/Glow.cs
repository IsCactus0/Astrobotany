using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Particles
{
    public class Glow : Particle
    {
        public Glow(bool solid)
            : base(solid)
        {

        }
        public Glow(bool solid, int size)
            : base(solid, size)
        {

        }
        public Glow(bool solid, int width, int height)
            : base(solid, width, height)
        {

        }
        public Glow(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight)
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight)
        {

        }
        public Glow(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y)
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y)
        {

        }
        public Glow(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r)
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {

        }
        public Glow(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr)
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr)
        {

        }
        public Glow(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar)
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar)
        {

        }
        public Glow(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass)
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass)
        {

        }
        public Glow(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction)
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction)
        {

        }
        public Glow(bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction, Color colour)
            : base(solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r, vx, vy, vr, ax, ay, ar, mass, friction, colour)
        {

        }

        public Color GlowColour { get; set; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Main.AssetManager.GetTexture("blur"),
                Sprite, null, GlowColour);

            base.Draw(spriteBatch);
        }
    }
}