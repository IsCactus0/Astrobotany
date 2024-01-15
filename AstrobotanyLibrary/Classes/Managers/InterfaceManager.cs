using AstrobotanyLibrary.Classes.Objects.Items;
using AstrobotanyLibrary.Classes.Objects.Windows;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class InterfaceManager : DrawableGameComponent
    {
        public InterfaceManager(Game game)
                    : base(game)
        {
            Windows = new List<Window>();
            CursorSize = 8f;
            InterfaceScale = 1f;
            Windows.Add(new ContainerWindow(Main.EntityManager.Player.Inventory, "Inventory", Color.Black));
            ((ContainerWindow)Windows[0]).Inventory.AddItem(new ItemStack(Items.Capacitor));
            ((ContainerWindow)Windows[0]).Inventory.AddItem(new ItemStack(Items.Battery));
        }

        public Effect ActiveEffect { get; set; }
        public List<Window> Windows { get; private set; }
        public ContainerWindow InventoryWindow { get; private set; }
        public int SelectedIndex { get; set; }
        public float CursorSize { get; set; }
        public float InterfaceScale { get; set; }
        public int FPS { get; private set; }
        public float LastFPS { get; private set; }

        public const float FPSFreq = 0.7f;
        public string DebugString = "";

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            LastFPS += delta;
            if (LastFPS >= FPSFreq)
            {
                FPS = (int)(1f / gameTime.ElapsedGameTime.TotalSeconds);
                LastFPS = 0f;
            }

            Main.Camera.Scale -= delta * Main.InputManager.MouseScrollValue() * 10f;
            Main.Camera.Scale = Math.Clamp(Main.Camera.Scale, 1f, 10f);
            Main.Camera.Update(delta, 8f, Vector2.Zero);

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
            foreach (Window window in Windows)
                if (window.Visible)
                    window.Draw(Main.SpriteBatch);

            Drawing.DrawString(
                Main.SpriteBatch,
                Main.AssetManager.GetFont("Montserrat"),
                $"FPS {FPS}",
                new Vector2(10),
                Color.White,
                Enums.Alignment.TopLeft,
                Main.InterfaceManager.InterfaceScale);

            Main.SpriteBatch.Draw(
                Main.AssetManager.GetTexture("circle"), 
                MathAdditions.CenterRect(Main.InputManager.MouseScreenPosition(), (int)CursorSize),
                Color.White);

            base.Draw(gameTime);
        }
    }
}