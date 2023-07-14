using AstrobotanyLibrary.Classes.Objects.Tiles;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class TileManager : DrawableGameComponent
    {
        public TileManager(Game game)
            : base(game)
        {
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
            Tiles = new Tile[10, 10];

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Tiles[x,y] = new Tile()
                    {
                        Position = new Vector2(x, y),
                        Name = $"Stone"
                    };
                }
            }
        }

        public static SpriteBatch SpriteBatch { get; private set; }
        public Effect ActiveEffect { get; set; }
        public Tile[,] Tiles { get; set; }
        public Tile SelectedTile { get; private set; }

        public override void Update(GameTime gameTime)
        {
            // float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            Vector2 selection = MathAdditions.CartesionToIsometric(Main.InputManager.MouseWorldPosition(Main.Camera), 16, 8);
            int selectX = (int)Math.Floor(selection.X);
            int selectY = (int)Math.Floor(selection.Y);
            if (selectX >= 0 && selectX < Tiles.GetLength(0) &&
                selectY >= 0 && selectY < Tiles.GetLength(1))
                SelectedTile = Tiles[selectX, selectY];

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

            foreach (Tile tile in Tiles)
                if (Main.Camera.BoundingBox.Intersects(tile.Bounds))
                    tile.Draw(SpriteBatch);

            if (SelectedTile is not null)
                SpriteBatch.Draw(
                    Main.AssetManager.GetTexture(SelectedTile.Name),
                    new Rectangle(
                        (int)((SelectedTile.Position.X - SelectedTile.Position.Y) * 16f),
                        (int)((SelectedTile.Position.X + SelectedTile.Position.Y) * 8f),
                        32, 32),
                    Color.Red);

            base.Draw(gameTime);

            SpriteBatch.End();
        }
    }
}