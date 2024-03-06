using AstrobotanyLibrary.Classes.Objects.Menus;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Windows
{
    public abstract class Window : MenuElement
    {
        protected Window()
            : base()
        {

        }
        protected Window(float x, float y)
            : base(x, y)
        {

        }
        protected Window(float x, float y, float width, float height)
            : base(x, y, width, height)
        {

        }
        protected Window(float x, float y, float width, float height, string text)
            : base(x, y, width, height, text)
        {

        }
        protected Window(float x, float y, float width, float height, string text, float textScale)
            : base(x, y, width, height, text, textScale)
        {

        }
        protected Window(float x, float y, float width, float height, string text, float textScale, Color colour)
            : base(x, y, width, height, text, textScale, colour)
        {

        }
        protected Window(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour)
            : base(x, y, width, height, text, textScale, colour, textColour)
        {

        }

        public override void Update(float delta)
        {
            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Drawing.DrawRectangle(
                spriteBatch,
                Position,
                Size * Main.InterfaceManager.Scale,
                Colour);

            SpriteFont font = Main.AssetManager.GetFont("MonomaniacOne");
            string title = Text.ToUpper();
            float width = Size.X * Main.InterfaceManager.Scale;

            Drawing.DrawString(spriteBatch, font, title,
                Position + new Vector2(1, 0) * Main.InterfaceManager.Scale,
                Color.White,
                Enums.AlignmentVertical.Bottom,
                Enums.AlignmentHorizontal.Left,
                width / font.MeasureString(title).X);

            Drawing.DrawRoundedLine(spriteBatch,
                new Vector2(Position.X + Main.InterfaceManager.Scale / 2f, Position.Y),
                new Vector2(Position.X - Main.InterfaceManager.Scale / 2f + width, Position.Y),
                Main.InterfaceManager.Scale, Color.White);
        }
    }
}