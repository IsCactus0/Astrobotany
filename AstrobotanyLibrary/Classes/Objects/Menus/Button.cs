using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Objects.Menus;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Windows
{
    public class Button : MenuElement {
        public Button()
            : base() {
            ActiveColour = Colour;
            ActiveTextColour = TextColour;
            HoverColour = Colour;
            HoverTextColour = TextColour;
        }
        public Button(float x, float y)
            : base(x, y) {
            ActiveColour = Colour;
            ActiveTextColour = TextColour;
            HoverColour = Colour;
            HoverTextColour = TextColour;
        }
        public Button(float x, float y, float width, float height)
            : base(x, y, width, height) {
            ActiveColour = Colour;
            ActiveTextColour = TextColour;
            HoverColour = Colour;
            HoverTextColour = TextColour;
        }
        public Button(float x, float y, float width, float height, string text)
            : base(x, y, width, height, text) {
            ActiveColour = Colour;
            ActiveTextColour = TextColour;
            HoverColour = Colour;
            HoverTextColour = TextColour;
        }
        public Button(float x, float y, float width, float height, string text, float textScale)
            : base(x, y, width, height, text, textScale) {
            ActiveColour = Colour;
            ActiveTextColour = TextColour;
            HoverColour = Colour;
            HoverTextColour = TextColour;
        }
        public Button(float x, float y, float width, float height, string text, float textScale, Color colour)
            : base(x, y, width, height, text, textScale, colour) {
            ActiveColour = Colour;
            ActiveTextColour = TextColour;
            HoverColour = Colour;
            HoverTextColour = TextColour;
        }
        public Button(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour)
            : base(x, y, width, height, text, textScale, colour, textColour) {
            ActiveColour = Colour;
            ActiveTextColour = TextColour;
            HoverColour = Colour;
            HoverTextColour = TextColour;
        }
        public Button(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour, Color activeColour)
            : base(x, y, width, height, text, textScale, colour, textColour) {
            ActiveColour = activeColour;
            ActiveTextColour = TextColour;
            HoverColour = Colour;
            HoverTextColour = TextColour;
        }
        public Button(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour, Color activeColour, Color activeTextColour)
            : base(x, y, width, height, text, textScale, colour, textColour) {
            ActiveColour = activeColour;
            ActiveTextColour = activeTextColour;
            HoverColour = Colour;
            HoverTextColour = TextColour;
        }
        public Button(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour, Color activeColour, Color activeTextColour, Color hoverColour)
            : base(x, y, width, height, text, textScale, colour, textColour) {
            ActiveColour = activeColour;
            ActiveTextColour = activeTextColour;
            HoverColour = hoverColour;
            HoverTextColour = TextColour;
        }
        public Button(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour, Color activeColour, Color activeTextColour, Color hoverColour, Color hoverTextColour)
            : base(x, y, width, height, text, textScale, colour, textColour) {
            ActiveColour = activeColour;
            ActiveTextColour = activeTextColour;
            HoverColour = hoverColour;
            HoverTextColour = hoverTextColour;
        }

        public Color ActiveColour { get; protected set; }
        public Color ActiveTextColour { get; protected set; }
        public Color HoverColour { get; protected set; }
        public Color HoverTextColour { get; protected set; }

        public override void Click(MouseButton button = MouseButton.Left) {
            base.Click(button);
        }
        public override void Drag(MouseButton button = MouseButton.Left) {
            return;
        }
        public override void Draw(SpriteBatch spriteBatch) {
            SpriteFont font = Main.AssetManager.GetFont("Montserrat");
            float textScale = Size.X / font.MeasureString(Text).X * TextScale * Main.InterfaceManager.Scale;
            
            if (Active) {
                Drawing.DrawRectangle(spriteBatch, Rectangle, ActiveColour);
                Drawing.DrawString(spriteBatch, font, Text, Position, ActiveTextColour,
                    AlignmentVertical.Centre, AlignmentHorizontal.Centre, textScale);
                return;
            }
            
            if (Hovering) {
                Drawing.DrawRectangle(spriteBatch, Rectangle, HoverColour);
                Drawing.DrawString(spriteBatch, font, Text, Position, HoverTextColour,
                    AlignmentVertical.Centre, AlignmentHorizontal.Centre, textScale);
                return;
            }
            
            Drawing.DrawRectangle(spriteBatch, Rectangle, Colour);
            Drawing.DrawString(spriteBatch, font, Text, Position, TextColour,
                AlignmentVertical.Centre, AlignmentHorizontal.Centre, textScale);
        }
    }
}