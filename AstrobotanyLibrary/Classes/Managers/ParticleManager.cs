using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Objects.Particles;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class ParticleManager : DrawableGameComponent
    {
        public ParticleManager(Game game)
            : base(game)
        {
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
            Particles = new List<Particle>();
            MaxParticles = 1000;
        }

        public SpriteBatch SpriteBatch { get; private set; }
        public Effect ActiveEffect { get; set; }
        public List<Particle> Particles { get; private set; }
        public QuadTree QuadTree { get; private set; }
        public int MaxParticles { get; set; }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            QuadTree = new QuadTree(Main.Camera.BoundingBox, 32);

            // if (Particles.Count < MaxParticles)
            // {
            //     Particles.Add(
            //         new Rain(
            //             "Rain", false,
            //             4, 4, 4, 4,
            //             Main.Random.Next(-Main.Camera.BoundingBox.Width / 2, Main.Camera.BoundingBox.Width / 2),
            //             Main.Camera.Position.Y, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 1f, 0.001f, Color.White));
            // }

            if (Particles.Count > MaxParticles)
                Particles.RemoveRange(0, Particles.Count - MaxParticles);

            for (int i = Particles.Count - 1; i >= 0; i--)
            {
                Particle particle = Particles[i];
                if (!MathAdditions.VectorIntersects(Particles[i].Position, Main.Camera.PhysicsBoundingBox)) {
                    particle.Destroy();
                    continue;
                }

                particle.Update(delta);
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                Main.Camera.SamplerState,
                DepthStencilState.None,
                RasterizerState.CullNone,
                ActiveEffect, Main.Camera.Transform);

            foreach (Particle particle in Particles)
                if (MathAdditions.VectorIntersects(particle.Position, Main.Camera.BoundingBox))
                    particle.Draw(SpriteBatch);

            base.Draw(gameTime);

            SpriteBatch.End();
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