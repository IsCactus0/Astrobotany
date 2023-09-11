using AstrobotanyLibrary.Classes.Objects;
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
            RenderTarget = new RenderTarget2D(Main.Graphics.GraphicsDevice, Main.Settings.Resolution.X, Main.Settings.Resolution.Y);
            Tiles = new Tile[100, 100, 5];

            // ActiveEffect = Main.AssetManager.GetShader("Heatwave");
            // ActiveEffect.Parameters["DistortionTexture"].SetValue(Main.AssetManager.GetTexture("HeatwaveUV"));
            // ActiveEffect.Parameters["Magnitude"].SetValue(1f);
            // ActiveEffect.Parameters["Scale"].SetValue(1f);
            // ActiveEffect.Parameters["Time"].SetValue(0.0f);

            for (int z = 0; z < 5; z++)
                for (int y = 0; y < 100; y++)
                    for (int x = 0; x < 100; x++)
                    {
                        if (Main.OpenSimplexNoise.Evaluate(x / 100.0f, y / 100.0f, z / 100.0f) * 3.0f > 0.8f)
                        {
                            switch (z)
                            {
                                case 0: Tiles[x, y, z] = new Tile(x, y, z, "Stone");
                                    break;
                                case 1: Tiles[x, y, z] = new Tile(x, y, z, "Stone");
                                    break;
                                case 2: Tiles[x, y, z] = new Tile(x, y, z, "Clay");
                                    break;
                                case 3: Tiles[x, y, z] = new Tile(x, y, z, "Dirt");
                                    break;
                                case 4: Tiles[x, y, z] = new Tile(x, y, z, "Grass");
                                    break;
                                default: Tiles[x, y, z] = new Tile(x, y, z, "Floor");
                                    break;
                            }
                        }
                    }
        }

        public static SpriteBatch SpriteBatch { get; private set; }
        public static RenderTarget2D RenderTarget { get; set; }
        public Effect ActiveEffect { get; set; }
        public Tile[,,] Tiles { get; set; }
        public Tile SelectedTile { get; private set; }

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
                    Tiles[selectX, selectY, 0] = null;
                else if (Main.InputManager.MousePressed(Enums.MouseButton.Right))
                    Tiles[selectX, selectY, 0] = new Tile(selectX, selectY, 0, "Floor");

                SelectedTile = Tiles[selectX, selectY, 0];
            }

            // ActiveEffect.Parameters["Scale"].SetValue(10f / Main.Camera.Scale);
            // ActiveEffect.Parameters["Magnitude"].SetValue(Main.Camera.Scale / 300f); 
            // ActiveEffect.Parameters["Time"].SetValue((float)gameTime.TotalGameTime.TotalMinutes * 10.0f);

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

            for (int z = 0; z < 5; z++)
                for (int y = 0; y < 100; y++)
                    for (int x = 0; x < 100; x++)
                        if (Tiles[x, y, z] is not null)
                            Tiles[x, y, z].Draw(SpriteBatch);

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