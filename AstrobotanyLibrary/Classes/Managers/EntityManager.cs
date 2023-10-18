using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Objects.Entities;
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
        }

        public SpriteBatch SpriteBatch { get; private set; }
        public List<Entity> Entities { get; set; }
        public QuadTree QuadTree { get; private set; }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            if (Entities.Count > 0 || delta <= 0f)
                return;

            QuadTree = new QuadTree(Main.Camera.BoundingBox, 8);

            for (int i = Entities.Count - 1; i >= 0; i--)
            {
                Entity entity = Entities[i];
                if (Main.Camera.PhysicsBoundingBox.Intersects(entity.Hitbox))
                {
                    entity.Update(delta);
                    QuadTree.Add(entity);
                }
            }
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

            foreach (Entity entity in Entities)
                if (Main.Camera.BoundingBox.Intersects(entity.Sprite))
                    entity.Draw(SpriteBatch);

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
            return QuadTree.Query(bounds);
        }
    }
}