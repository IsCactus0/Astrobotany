using AstrobotanyLibrary.Classes.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class InterfaceManager : DrawableGameComponent
    {
        public InterfaceManager(Game game)
                    : base(game)
        {
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
            Windows = new List<Window>();
            Inventory = new ContainerWindow("Inventory", new Color(32, 26, 34), new Vector2(500), 4, 7);
            Windows.Add(Inventory);
            CursorSize = 8f;
        }

        public static SpriteBatch SpriteBatch { get; private set; }
        public List<Window> Windows { get; private set; }
        public Window Inventory { get; private set; }
        public int SelectedIndex { get; set; }
        public float CursorSize { get; set; }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;

            Main.Camera.Scale -= delta * Main.InputManager.MouseScrollValue() * 10f;
            Main.Camera.Scale = Math.Clamp(Main.Camera.Scale, 1f, 10f);

            if (SelectedIndex >= 0 && SelectedIndex < Windows.Count - 1)
            {
                Window window = Windows[SelectedIndex];
                Windows.Remove(window);
                Windows.Add(window);
                SelectedIndex = Windows.Count - 1;
            }

            foreach (Window window in Windows)
                if (window.Visible)
                    window.Update(delta);

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            foreach (Window window in Windows)
                if (window.Visible)
                    window.Draw(SpriteBatch);

            SpriteBatch.Draw(
                Main.AssetManager.GetTexture("circle"),
                new Rectangle(
                    Main.InputManager.MouseScreenPositionP() - new Point((int)(CursorSize / 2f)),
                    new Point((int)CursorSize)),
                Color.White);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}