using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Objects.Items;
using AstrobotanyLibrary.Classes.Objects.Menus;
using AstrobotanyLibrary.Classes.Objects.Tiles;
using AstrobotanyLibrary.Classes.Objects.Windows;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Cursor {
        public Cursor() {
            Position = Vector2.Zero;
            Colour = Color.White;
            Scale = 0.8f;
            TransitionState = 0f;
            TransitionSpeed = 4f;
            State = CursorState.Pointer;
        }

        public Vector2 Position { get; set; }
        public Color Colour { get; set; }
        public float Scale { get; protected set; }
        public float TransitionState { get; protected set; }
        public float TransitionSpeed { get; protected set; }
        public CursorState State { get; set; }
        public ItemStack GrabbedItem { get; set; }

        protected virtual void SetTransition(float value) {
            TransitionState = value;
        }
        protected virtual void Transition(float delta, float value, float min = 0f, float max = 1f) {
            float change = delta * value * TransitionSpeed;
            TransitionState = Math.Clamp(TransitionState + change, min, max);
        }
        protected virtual void Hover(float delta) {
            for (int i = Main.InterfaceManager.Elements.Count - 1; i >= 0; i--) {
                MenuElement element = Main.InterfaceManager.Elements[i];
                if (MathAdditions.VectorIntersects(Main.InterfaceManager.Cursor.Position, element.Rectangle)) {
                    Mouse.SetCursor(MouseCursor.Hand);
                    State = CursorState.Hover;
                    return;
                }
            }

            Mouse.SetCursor(MouseCursor.Arrow);
            State = CursorState.Arrow;
        }
        protected virtual void Click(float delta, MouseButton button = MouseButton.Left) {
            if (button == MouseButton.Left || button == MouseButton.Right) {
                for (int i = Main.InterfaceManager.Elements.Count - 1; i >= 0; i--) {
                    if (MathAdditions.VectorIntersects(Main.InterfaceManager.Cursor.Position, Main.InterfaceManager.Elements[i].Rectangle)) {
                        Mouse.SetCursor(MouseCursor.Hand);
                        State = CursorState.Grab;
                        return;
                    }
                }

                Point? selected = Main.SceneManager.GetScenePosition(Position.X, Position.Y);
                if (selected is null)
                    return;

                Tile tile = Main.SceneManager.Scene.Tiles[selected.Value.X, selected.Value.Y];
                if (tile is null) {
                    Main.EntityManager.Player.QueueMove((Point)selected, Main.SceneManager.Scene.Grid);
                    return;
                }

                tile.Click(delta, Main.InputManager.GetFirstPressedMouseButton());
            }
        }
        protected virtual void Hold(float delta) {

        }
        protected virtual void Release(float delta, MouseButton button = MouseButton.Left) {
            State = CursorState.Arrow;
            Mouse.SetCursor(MouseCursor.Arrow);

            if (GrabbedItem is null)
                return;

            for (int i = Main.InterfaceManager.Elements.Count - 1; i >= 0; i--) {
                if (Main.InterfaceManager.Elements[i] is ContainerWindow container && 
                    MathAdditions.VectorIntersects(Main.InterfaceManager.Cursor.Position, container.ItemBounds)) {
                    Point droppedIndex = container.GetItemIndex(Position);
                    if (container.Inventory.AddItemToSlot(GrabbedItem, droppedIndex.X, droppedIndex.Y) ||
                        container.Inventory.AddItem(GrabbedItem))
                        return;
                }
            }
        }
        public virtual void Update(float delta) {
            Position = Main.InputManager.MouseScreenPosition();

            if (Main.InputManager.MouseAnyFirstPressed())
                Click(delta, Main.InputManager.GetFirstPressedMouseButton());
            else if (Main.InputManager.MousePressed())
                Hold(delta);
            else if (Main.InputManager.MouseFirstReleased())
                Release(delta, Main.InputManager.GetReleasedMouseButton());
            else Hover(delta);
        }
        public virtual void Draw(SpriteBatch spriteBatch) {
            if (GrabbedItem is not null)
                Drawing.DrawSprite(spriteBatch,
                    Main.AssetManager.GetTexture($"Items/{GrabbedItem.Item}"),
                    Position - new Vector2(16 * Scale * Main.InterfaceManager.Scale), new Vector2(32 * Scale * Main.InterfaceManager.Scale), Color.White);

            Drawing.DrawSprite(spriteBatch,
                Main.AssetManager.GetTexture($"Interface/Cursor/{State}"),
                Position - new Vector2(16 * Scale * Main.InterfaceManager.Scale), new Vector2(32 * Scale * Main.InterfaceManager.Scale), Colour);
        }
    }
}