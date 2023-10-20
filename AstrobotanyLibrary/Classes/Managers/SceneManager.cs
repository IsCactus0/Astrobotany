using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Objects.Tiles;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class SceneManager : DrawableGameComponent
    {
        public SceneManager(Game game)
            : base(game)
        {
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
            LoadScene(new Scene());
        }

        public static SpriteBatch SpriteBatch { get; private set; }
        public Scene Scene { get; set; }
        public Effect ActiveEffect { get; set; }
        public Tile SelectedTile { get; private set; }
        
        public void LoadScene(Scene Scene)
        {
            this.Scene = Scene;
            SelectedTile = null;

            Main.Camera.Offset = new Vector2(8, (Math.Max(Scene.Width, Scene.Height) + 1) * 4);
        }
        public override void Update(GameTime gameTime)
        {            
            if (Main.InputManager.MousePressed(Enums.MouseButton.Left))
            {
                Vector2 hover = MathAdditions.CartesionToIsometric(
                    Main.InputManager.MouseWorldPosition(Main.Camera), 16, 8);
                Vector3 index = Scene.SelectProp(hover);
                if (index != Vector3.Down)
                    Scene.Tiles[(int)index.X, (int)index.Y, (int)index.Z] = null;
            }
            else if (Main.InputManager.MousePressed(Enums.MouseButton.Right))
            {
                Vector2 hover = MathAdditions.CartesionToIsometric(
                    Main.InputManager.MouseWorldPosition(Main.Camera), 16, 8);
                Vector3 index = Scene.SelectProp(hover);
                if (index != Vector3.Down)
                    Scene.Tiles[(int)index.X, (int)index.Y, (int)index.Z] = new Tile((int)index.X, (int)index.Y);
            }

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;

            Scene.Update(delta);
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

            Scene.Draw(SpriteBatch);

            SpriteBatch.End();
        }
    }
}