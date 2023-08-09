using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Objects.Items;
using AstrobotanyLibrary.Classes.Objects.Windows;
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
            InventoryWindow = new ContainerWindow("Inventory", new Color(32, 26, 34), new Vector2(32), 4, 7);
            InventoryWindow.Inventory.Items[0, 0] = new ItemStack(
                    new Item(
                        "Capacitor",
                        "A capacitor is a device that" +
                        "stores electrical energy in an" +
                        "electric field by virtue of" +
                        "accumulating electric charges" +
                        "on two close surfaces insulated" +
                        "from each other",
                        12, Enums.ItemCategory.Component),
                    2, 8);
            Windows = new List<Window> { InventoryWindow };
            CursorSize = 8f;
            InterfaceScale = 1f;
        }

        public static SpriteBatch SpriteBatch { get; private set; }
        public Effect ActiveEffect { get; set; }
        public List<Window> Windows { get; private set; }
        public ContainerWindow InventoryWindow { get; private set; }
        public int SelectedIndex { get; set; }
        public float CursorSize { get; set; }
        public float InterfaceScale { get; set; }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;

            Main.Camera.Scale -= delta * Main.InputManager.MouseScrollValue() * 10f;
            Main.Camera.Scale = Math.Clamp(Main.Camera.Scale, 1f, 10f);
            Main.Camera.Update(delta, 80f, Vector2.Zero);// Main.EntityManager.Player.Position);

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
            SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                Main.Camera.SamplerState,
                DepthStencilState.None,
                RasterizerState.CullNone,
                ActiveEffect, null);

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