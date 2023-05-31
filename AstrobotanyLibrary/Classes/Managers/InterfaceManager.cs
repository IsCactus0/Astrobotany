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
            Windows = new List<Window>
            {
                new Window("Inventory", new Color(32, 26, 34), new Vector2(429, 490), new Vector2(128))
            };
            CursorSize = 8f;
        }

        public static SpriteBatch SpriteBatch { get; private set; }
        public List<Window> Windows { get; private set; }
        public float CursorSize { get; set; }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            if (Windows is not null)
                foreach (Window window in Windows)
                    window.Update(delta);

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            foreach (Window window in Windows)
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