using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Objects.Tiles;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class TileManager : DrawableGameComponent
    {
        public TileManager(Game game)
            : base(game)
        {
            LoadScene(new Scene());
        }

        public Scene Scene { get; set; }
        public Tile SelectedTile { get; private set; }

        public void LoadScene(Scene Scene)
        {
            this.Scene = Scene;
            SelectedTile = null;

            Main.Camera.Offset = new Vector2(8, (Math.Max(Scene.Width, Scene.Height) + 1) * 4);
        }
        public override void Update(GameTime gameTime)
        {
            if (Main.InputManager.MouseFirstPressed(Enums.MouseButton.Right))
            {
                Point? index = Scene.CartesionToGrid(
                    MathAdditions.CartesionToIsometric(
                        Main.InputManager.MouseWorldPosition(Main.Camera), 16, 8));

                if (index is not null)
                    Main.EntityManager.Player.Path.Steps = Scene.Grid.Evaluate(
                        Main.EntityManager.Player.Position.ToPoint(), (Point)index);
            }

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;

            Scene.Update(delta);
        }
        public override void Draw(GameTime gameTime)
        {
            Scene.Draw(Main.SpriteBatch);
        }
    }
}