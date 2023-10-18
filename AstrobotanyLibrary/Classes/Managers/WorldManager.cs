using AstrobotanyLibrary.Classes.Objects.Tiles;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class WorldManager : DrawableGameComponent
    {
        public WorldManager(Game game)
            : base(game)
        {
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
            RenderTarget = new RenderTarget2D(Main.Graphics.GraphicsDevice, Main.Settings.Resolution.X, Main.Settings.Resolution.Y);
            Width = 16;
            Height = 16;
            Tiles = new Tile[Width, Height];

            // ActiveEffect = Main.AssetManager.GetShader("Heatwave");
            // ActiveEffect.Parameters["DistortionTexture"].SetValue(Main.AssetManager.GetTexture("HeatwaveUV"));
            // ActiveEffect.Parameters["Magnitude"].SetValue(0.1f);
            // ActiveEffect.Parameters["Scale"].SetValue(0.3f);
            // ActiveEffect.Parameters["Time"].SetValue(0.0f);

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    Tiles[x, y] = new Tile(x, y, "Floor");
        }

        public static SpriteBatch SpriteBatch { get; private set; }
        public static RenderTarget2D RenderTarget { get; set; }
        public Effect ActiveEffect { get; set; }
        public Tile[,] Tiles { get; set; }
        public Tile SelectedTile { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        
        public override void Update(GameTime gameTime)
        {
            Vector2 selection = MathAdditions.CartesionToIsometric(Main.InputManager.MouseWorldPosition(Main.Camera), 16, 8);
            selection += new Vector2(-0.5f, 0.5f);
            int selectX = (int)Math.Floor(selection.X);
            int selectY = (int)Math.Floor(selection.Y);

            if (selectX >= 0 && selectX < Tiles.GetLength(0) &&
                selectY >= 0 && selectY < Tiles.GetLength(1))
            {
                if (Main.InputManager.MousePressed(Enums.MouseButton.Left))
                    Tiles[selectX, selectY] = null;
                else if (Main.InputManager.MousePressed(Enums.MouseButton.Right))
                    Tiles[selectX, selectY] = new Tile(selectX, selectY, "Floor");

                SelectedTile = Tiles[selectX, selectY];
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
                ActiveEffect, 
                Main.Camera.Transform);

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    if (Tiles[x, y] is not null)
                        Tiles[x, y].Draw(SpriteBatch);

            if (SelectedTile is not null)
                SpriteBatch.Draw(
                    Main.AssetManager.GetTexture("Selection"),
                    new Rectangle(
                        (int)((SelectedTile.Position.X - SelectedTile.Position.Y) * 16f),
                        (int)((SelectedTile.Position.X + SelectedTile.Position.Y) * 8f),
                        32, 32),
                    Color.Red);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}