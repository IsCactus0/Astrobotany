﻿using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Objects.Decorations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class DecorationManager : DrawableGameComponent
    {
        public DecorationManager(Game game)
            : base(game)
        {
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
            Decorations = new List<Decoration>();
        }

        public static SpriteBatch SpriteBatch { get; private set; }
        public List<Decoration> Decorations { get; set; }
        public QuadTree QuadTree { get; private set; }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            QuadTree = new QuadTree(Main.Camera.PhysicsBoundingBox, 4);

            for (int i = Decorations.Count - 1; i >= 0; i--)
            {
                Decoration decoration = Decorations[i];
                if (Main.Camera.PhysicsBoundingBox.Intersects(decoration.Hitbox))
                {
                    decoration.Update(delta);
                    QuadTree.Add(decoration);
                }
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

            foreach (Decoration decoration in Decorations)
                if (Main.Camera.BoundingBox.Intersects(decoration.Sprite))
                    decoration.Draw(SpriteBatch);

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