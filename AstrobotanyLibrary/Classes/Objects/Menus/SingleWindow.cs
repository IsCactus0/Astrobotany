using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Menus
{
    public class SingleWindow : AnimatedMenuElement
    {
        public SingleWindow() 
            : base() {
            Texture = Main.AssetManager.GetTexture("Interface/Menu/Single_Middle");
            LeftTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Arrow");
            RightTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Rounded");
        }
        public SingleWindow(float x, float y)
            : base(x, y) {
            Texture = Main.AssetManager.GetTexture("Interface/Menu/Single_Middle");
            LeftTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Arrow");
            RightTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Rounded");
        }
        public SingleWindow(float x, float y, float width, float height)
            : base(x, y, width, height) {
            Texture = Main.AssetManager.GetTexture("Interface/Menu/Single_Middle");
            LeftTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Arrow");
            RightTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Rounded");
        }
        public SingleWindow(float x, float y, float width, float height, string text)
            : base(x, y, width, height, text) {
            Texture = Main.AssetManager.GetTexture("Interface/Menu/Single_Middle");
            LeftTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Arrow");
            RightTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Rounded");
        }
        public SingleWindow(float x, float y, float width, float height, string text, float textScale)
            : base(x, y, width, height, text, textScale) {
            Texture = Main.AssetManager.GetTexture("Interface/Menu/Single_Middle");
            LeftTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Arrow");
            RightTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Rounded");
        }
        public SingleWindow(float x, float y, float width, float height, string text, float textScale, Color colour)
            : base(x, y, width, height, text, textScale, colour) {
            Texture = Main.AssetManager.GetTexture("Interface/Menu/Single_Middle");
            LeftTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Arrow");
            RightTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Rounded");
        }
        public SingleWindow(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour)
            : base(x, y, width, height, text, textScale, colour, textColour) {
            Texture = Main.AssetManager.GetTexture("Interface/Menu/Single_Middle");
            LeftTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Arrow");
            RightTexture = Main.AssetManager.GetTexture("Interface/Menu/Single_Rounded");
        }

        public Texture2D LeftTexture { get; protected set; }
        public Texture2D RightTexture { get; protected set; }

        public override void Draw(SpriteBatch spriteBatch) {
            Point leftSize = LeftTexture.Bounds.Size;
            Point rightSize = RightTexture.Bounds.Size;
            float fade = GetFadeAmount();

            Drawing.DrawSprite(spriteBatch, LeftTexture,
                Position,
                leftSize.ToVector2() * Main.InterfaceManager.Scale,
                Colour * fade);

            Drawing.DrawSprite(spriteBatch, Texture,
                new Vector2(Position.X + leftSize.X * Main.InterfaceManager.Scale, Position.Y),
                new Vector2(Size.X - (leftSize.X + rightSize.X), Size.Y) * Main.InterfaceManager.Scale,
                Colour * fade);

            Drawing.DrawSprite(spriteBatch, RightTexture,
                new Vector2(Position.X + (Size.X - rightSize.X) * Main.InterfaceManager.Scale, Position.Y),
                rightSize.ToVector2() * Main.InterfaceManager.Scale,
                Colour * fade, true);

            Drawing.DrawString(spriteBatch, Font, Text, Position, TextColour * fade,
                AlignmentVertical.Top, AlignmentHorizontal.Left, TextScale);
        }
    }
}