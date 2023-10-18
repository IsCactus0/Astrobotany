using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Objects.Windows
{
    public abstract class MovableWindow : Window
    {
        protected MovableWindow()
        {
        }
        protected MovableWindow(string title)
            : base(title)
        {
        }
        protected MovableWindow(string title, Color backgroundColour)
            : base(title, backgroundColour)
        {
        }
        protected MovableWindow(string title, Color backgroundColour, Vector2 position)
            : base(title, backgroundColour, position)
        {
        }

        protected Vector2 grabStart;

        public override void Update(float delta)
        {
            Vector2 mousePos = Main.InputManager.MouseScreenPosition();
            int index = Main.InterfaceManager.Windows.FindIndex(x => x == this);

            if (!MathAdditions.PointIntersects(mousePos.ToPoint(), Rectangle))
            {
                grabStart = -Vector2.One;
                if (Main.InterfaceManager.SelectedIndex == index)
                    Main.InterfaceManager.SelectedIndex = -1;

                return;
            }

            if (Main.InputManager.MouseFirstPressed())
            {
                grabStart = mousePos - Position;
                Main.InterfaceManager.SelectedIndex = index;
            }

            if (Main.InterfaceManager.SelectedIndex == index)
            {
                if (Main.InputManager.MousePressed() && grabStart != -Vector2.One)
                    Position = Main.InputManager.MouseScreenPosition() - grabStart;
                else
                {
                    grabStart = -Vector2.One;
                    Main.InterfaceManager.SelectedIndex = -1;
                }
            }
        }
    }
}