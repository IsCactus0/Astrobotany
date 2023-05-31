using AstrobotanyLibrary.Classes.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class ParticleManager : DrawableGameComponent
    {
        public ParticleManager(Game game)
            : base(game)
        {
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
            //Particles = new List<Particle>();
            MaxParticles = 1000;
        }

        public static SpriteBatch SpriteBatch { get; private set; }
        // public List<Particle> Particles { get; private set; }
        public int MaxParticles { get; set; }

        public override void Update(GameTime gameTime)
        {
            // float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            // foreach (Particle particle in Particles)
            //     particle.Update(delta);

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

            base.Draw(gameTime);

            SpriteBatch.End();
        }
    }
}