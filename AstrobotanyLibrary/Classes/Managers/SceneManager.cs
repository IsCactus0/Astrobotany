using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Objects.Tiles;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class SceneManager : DrawableGameComponent {
        public SceneManager(Game game) : base(game) {
            LoadScene(new Scene());
            Layer = new Layer(0, Scene.MaxLayerDepth);
        }

        public Scene Scene { get; set; }
        public Layer Layer { get; private set; }

        public void LoadScene(Scene scene) {
            Scene = scene;
            Main.Camera.Offset = new Vector2(8, (Math.Max(scene.Width, scene.Height) + 1) * 4);
        }
        public override void Update(GameTime gameTime) {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            Scene.Update(delta);
        }
        public Tile GetTile(float x, float y) {
            Point? index = GetScenePosition(x, y);
            if (index is not null)
                return Scene.Tiles[index.Value.X, index.Value.Y];
            else return null;
        }
        public Point? GetScenePosition(float x, float y) {
            Vector2 world = Vector2.Transform(
                new Vector2(x, y),
                Main.Camera.InvertedTransform);

            return Scene.IsometricToGrid(
                MathAdditions.CartesionToIsometric(new Vector2(world.X, world.Y), 16, 8));
        }
        public override void Draw(GameTime gameTime) {
            Scene.Draw(Main.SpriteBatch);
        }
    }
}