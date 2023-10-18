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
            MaxLifespan = 10f;
        }
        protected Particle(Particle copy)
        {
            Colour = copy.Colour;
            MaxLifespan = copy.MaxLifespan;
        }

        public Color Colour { get; set; }
        public float MaxLifespan { get; set; }

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