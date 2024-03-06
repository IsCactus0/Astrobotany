using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Objects.Particles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class ParticleManager : DrawableGameComponent
    {
        public ParticleManager(Game game)
            : base(game)
        {
            Particles = new List<Particle>();
            MaxParticles = 1000;
        }

        public Effect ActiveEffect { get; set; }
        public List<Particle> Particles { get; private set; }
        public QuadTree QuadTree { get; private set; }
        public int MaxParticles { get; set; }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            if (Particles.Count == 0 || delta <= 0f)
                return;

            QuadTree = new QuadTree(Main.Camera.BoundingBox, 32);
            if (Particles.Count > MaxParticles)
                Particles.RemoveRange(0, Particles.Count - MaxParticles);

            for (int i = Particles.Count - 1; i >= 0; i--)
            {
                Particle particle = Particles[i];
                if (!Main.Camera.WithinBounds(particle.Position)) {
                    particle.Destroy();
                    continue;
                }

                particle.Update(delta);
                QuadTree.Add(particle);
            }
        }
        public override void Draw(GameTime gameTime)
        {
            foreach (Particle particle in Particles)
                if (Main.Camera.WithinBounds(particle.Position))
                    particle.Draw(Main.SpriteBatch);

            base.Draw(gameTime);
        }
        public List<GameObject> FindAllInRange(Vector2 position, float range)
        {
            Rectangle bounds = new Rectangle(
                (int)(position.X - (range / 2f)),
                (int)(position.Y - (range / 2f)),
                (int)range,
                (int)range);

            List<GameObject> found = FindAllInBounds(bounds);
            for (int i = found.Count - 1; i >= 0; i--)
                if (Vector2.Distance(found[i].Position, position) > range)
                    found.RemoveAt(i);

            return found;
        }
        public List<GameObject> FindAllInBounds(Rectangle bounds)
        {
            if (QuadTree is null)
                return new List<GameObject>();

            return QuadTree.Query(bounds);
        }
    }
}