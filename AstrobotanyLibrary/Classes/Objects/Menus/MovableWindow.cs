using AstrobotanyLibrary.Classes.Enums;
using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Objects.Windows
{
    public abstract class MovableWindow : Window
    {
        protected MovableWindow()
            : base()
        {
            GrabStart = -Vector2.One;
        }
        protected MovableWindow(float x, float y)
            : base(x, y)
        {
            GrabStart = -Vector2.One;
        }
        protected MovableWindow(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
            GrabStart = -Vector2.One;
        }
        protected MovableWindow(float x, float y, float width, float height, string text)
            : base(x, y, width, height, text)
        {
            GrabStart = -Vector2.One;
        }
        protected MovableWindow(float x, float y, float width, float height, string text, float textScale)
            : base(x, y, width, height, text, textScale)
        {
            GrabStart = -Vector2.One;
        }
        protected MovableWindow(float x, float y, float width, float height, string text, float textScale, Color colour)
            : base(x, y, width, height, text, textScale, colour)
        {
            GrabStart = -Vector2.One;
        }
        protected MovableWindow(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour)
            : base(x, y, width, height, text, textScale, colour, textColour)
        {
            GrabStart = -Vector2.One;
        }

        protected Vector2 GrabStart { get; set; }

        public override void Click(MouseButton button = MouseButton.Left)
        {
            if (button == MouseButton.Left)
            {
                GrabStart = Main.InterfaceManager.Cursor.Position - Position;
                Main.InterfaceManager.Elements.Remove(this);
                Main.InterfaceManager.Elements.Add(this);
            }

            base.Click(button);
        }
        public override void Drag(MouseButton button = MouseButton.Left)
        {
            if (Main.InterfaceManager.Cursor.GrabbedItem is not null)
                return;

            if (GrabStart != -Vector2.One && Main.InputManager.MousePressed())
            {
                Position = Vector2.Clamp(Main.InterfaceManager.Cursor.Position - GrabStart, Vector2.Zero, Main.Settings.Resolution.ToVector2());
                return;
            }
        }
        public override void Release(MouseButton button = MouseButton.Left)
        {
            GrabStart = -Vector2.One;

            base.Release(button);
        }
    }
}