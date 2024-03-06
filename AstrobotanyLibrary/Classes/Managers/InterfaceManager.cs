using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Objects.Menus;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class InterfaceManager : DrawableGameComponent {
        public InterfaceManager(Game game)
                    : base(game)
        {
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
            Elements = new List<MenuElement>();
            Cursor = new Cursor();
            Scale = 5f;
        }

        public static SpriteBatch SpriteBatch { get; private set; }
        public Effect ActiveEffect { get; set; }
        public List<MenuElement> Elements { get; private set; }
        public Cursor Cursor { get; set; }
        public int SelectedIndex { get; set; }
        public float Scale { get; set; }
        public int FPS { get; private set; }
        public float LastFPS { get; private set; }
        public string DebugString { get; set; }

        public override void Update(GameTime gameTime) {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            LastFPS += delta;
            if (LastFPS >= 0.7f) {
                FPS = (int)(1f / gameTime.ElapsedGameTime.TotalSeconds);
                LastFPS = 0f;
            }

            Main.Camera.Scale -= delta * Main.InputManager.MouseScrollValue() * 10f;
            Main.Camera.Scale = Math.Clamp(Main.Camera.Scale, 1f, 10f);
            Main.Camera.Update(delta, 8f, Vector2.Zero);

            for (int i = 0; i < Elements.Count; i++)
                Elements[i].Update(delta);

            Cursor.Update(delta);

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime) {
            SpriteBatch.Begin(
                sortMode: SpriteSortMode.Deferred,
                blendState: BlendState.NonPremultiplied,
                samplerState: SamplerState.PointClamp,
                depthStencilState: DepthStencilState.Default,
                rasterizerState: RasterizerState.CullNone);

            for (int i = 0; i < Elements.Count; i++) {
                MenuElement element = Elements[i];
                if (element.Visible)
                    element.Draw(SpriteBatch);
            }

            SpriteFont font = Main.AssetManager.GetFont("Montserrat");
            Drawing.DrawString(SpriteBatch, font, $"FPS", new Vector2(16), Color.White, Enums.AlignmentVertical.Top, Enums.AlignmentHorizontal.Left, 0.3f);
            Drawing.DrawString(SpriteBatch, Main.AssetManager.GetFont("Montserrat", Enums.FontWeight.Medium), $"{FPS}", new Vector2(16 + font.MeasureString("FPS ").X * 0.3f, 16), Color.HotPink, Enums.AlignmentVertical.Top, Enums.AlignmentHorizontal.Left, 0.3f);
           
            Drawing.DrawString(SpriteBatch, Main.AssetManager.GetFont("Montserrat", Enums.FontWeight.Black),
                $"{Main.EntityManager.Player.Animations[Main.EntityManager.Player.CurrentAnimation].CurrentIndex}", new Vector2(12, 12), Color.MediumVioletRed,
                Enums.AlignmentVertical.Top, Enums.AlignmentHorizontal.Left, 0.3f);

            if (!Main.Settings.UseSystemCursor)
                Cursor.Draw(SpriteBatch);

            SpriteBatch.End();
        }
    }
}