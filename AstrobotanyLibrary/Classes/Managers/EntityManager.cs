using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class EntityManager : DrawableGameComponent
    {
        public EntityManager(Game game)
            : base(game)
        {
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
            Entities = new List<Entity>();
            Player = new Player();
        }

        public SpriteBatch SpriteBatch { get; private set; }
        public List<Entity> Entities { get; private set; }
        public Player Player { get; private set; }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;

            Player.Update(delta);
            for (int i = Entities.Count - 1; i >= 0; i--)
                Entities[i].Update(delta);

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

            Player.Draw(SpriteBatch);
            foreach (Entity entity in Entities)
                if (MathAdditions.VectorIntersects(entity.Position, Main.Camera.BoundingBox))
                    entity.Draw(SpriteBatch);

            base.Draw(gameTime);

            SpriteBatch.End();
        }
    }
}