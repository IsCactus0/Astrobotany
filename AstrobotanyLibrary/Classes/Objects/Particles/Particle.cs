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
            Size = 1f;
            TimeAlive = 0f;
            MaxLifespan = 10f;
        }
        protected Particle(Particle copy)
        {
            Colour = copy.Colour;
            Size = copy.Size;
            TimeAlive = copy.TimeAlive;
            MaxLifespan = copy.MaxLifespan;
        }
        protected Particle(float x, float y)
            : base(x, y)
        {
            Colour = Color.White;
            Size = 1f;
            TimeAlive = 0f;
            MaxLifespan = 10f;
        }

        public Color Colour { get; set; }
        public float Size { get; set; }
        public float TimeAlive { get; set; }
        public float MaxLifespan { get; set; }

        public override void Destroy()
        {
            Main.ParticleManager.Particles.Remove(this);
        }
        public override List<GameObject> FindCollisions()
        {
            Rectangle hitbox = Hitbox;
            List<GameObject> colliding = Main.ParticleManager.FindAllInBounds(hitbox);

            colliding.Remove(this);
            return colliding;
        }
        public override void Update(float delta)
        {
            TimeAlive += delta;
            if (TimeAlive > MaxLifespan)
                Destroy();

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Drawing.DrawPoint(spriteBatch, Position, 3f, Colour);
        }
        public abstract float CalculateFade();
    }
}