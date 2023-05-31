using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Managers;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Window
    {
        public Window()
        {
            Title = "";
            BackgroundColour = new Color(46, 39, 48);
            Size = new Vector2(128);
            Position = Vector2.Zero;
        }
        public Window(string title, Color backgroundColour)
        {
            Title = title;
            BackgroundColour = backgroundColour;
            Size = new Vector2(128);
            Position = Vector2.Zero;
        }
        public Window(string title, Color backgroundColour, Vector2 size)
        {
            Title = title;
            BackgroundColour = backgroundColour;
            Size = size;
            Position = Vector2.Zero;
        }
        public Window(string title, Color backgroundColour, Vector2 size, Vector2 position)
        {
            Title = title;
            BackgroundColour = backgroundColour;
            Size = size;
            Position = position;
        }

        public string Title { get; set; }
        public Color BackgroundColour { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Rectangle 
        {
            get
            {
                return new Rectangle(
                    MathAdditions.ToPointFloor(Position),
                    MathAdditions.ToPointCeiling(Size));
            }
        }

        private Vector2 grabStart;

        public virtual void Update(float delta)
        {
            Vector2 mousePos = Main.InputManager.MouseScreenPosition();

            if (!MathAdditions.PointIntersects(
                mousePos.ToPoint(), Rectangle))
                return;

            if (Main.InputManager.MouseFirstPressed())
                grabStart = mousePos;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Main.AssetManager.GetTexture("simple"),
                Rectangle,
                BackgroundColour);

            // spriteBatch.DrawString(
            //     Main.AssetManager.GetFont("MonomaniacOne", FontWeight.Regular),
            //     Title,
            //     Position + new Vector2(16f, -11f), Color.White);
            // 
            // Drawing.DrawRoundedLine(
            //     spriteBatch,
            //     new Vector2(Position.X + 5, Position.Y),
            //     new Vector2(Position.X - 5 + Size.X, Position.Y),
            //     8f, Color.White);
        }
    }
}