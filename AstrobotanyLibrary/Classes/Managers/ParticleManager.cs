﻿using AstrobotanyLibrary.Classes.Objects;
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
        public List<Particle> Particles { get; private set; }
        public int MaxParticles { get; set; }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            if (Particles.Count > MaxParticles)
                Particles.RemoveRange(0, Particles.Count - MaxParticles);

            for (int i = Particles.Count - 1; i >= 0; i--)
            {
                if (!MathAdditions.VectorIntersects(Particles[i].Position, Main.Camera.BoundingBox)) {
                    Particles[i].Destroy();
                    continue;
                }

                Particles[i].Update(delta);
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
                null, Main.Camera.Transform);

            foreach (Particle particle in Particles)
                if (MathAdditions.VectorIntersects(particle.Position, Main.Camera.BoundingBox))
                    particle.Draw(SpriteBatch);

            base.Draw(gameTime);

            SpriteBatch.End();
        }
    }
}