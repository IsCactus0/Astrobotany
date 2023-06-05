using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Particle : PhysicsObject
    {
        public Particle()
        {
            Colour = Color.White;
        }
        public Particle(float x, float y)
            : base(x, y)
        {
            Colour = Color.White;
        }
        public Particle(float x, float y, float vx, float vy)
            : base(x, y, vx, vy)
        {
            Colour = Color.White;
        }
        public Particle(float x, float y, float vx, float vy, float ax, float ay)
            : base(x, y, vx, vy, ax, ay)
        {
            Colour = Color.White;
        }
        public Particle(float x, float y, float vx, float vy, float ax, float ay, Color colour)
            : base(x, y, vx, vy, ax, ay)
        {
            Colour = colour;
        }

        public Color Colour { get; set; }

        public override void Destroy()
        {
            Main.ParticleManager.Particles.Remove(this);
        }
        public override void Update(float delta)
        {
            Acceleration += new Vector2(0, 9.8f);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Drawing.DrawPoint(spriteBatch, Position, 3f, Colour);
        }
    }
}