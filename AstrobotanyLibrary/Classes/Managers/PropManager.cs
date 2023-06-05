using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class PropManager : DrawableGameComponent
    {
        public PropManager(Game game)
            : base(game)
        {
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
            Props = new List<Prop>();
        }

        public static SpriteBatch SpriteBatch { get; private set; }
        public List<Prop> Props { get; private set; }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            foreach (Prop prop in Props)
                prop.Update(delta);

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

            foreach (Prop prop in Props)
                if (MathAdditions.VectorIntersects(prop.Position, Main.Camera.BoundingBox))
                    prop.Draw(SpriteBatch);

            base.Draw(gameTime);

            SpriteBatch.End();
        }
    }
}