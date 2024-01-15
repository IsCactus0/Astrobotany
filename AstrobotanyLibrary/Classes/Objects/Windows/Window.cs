using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Windows
{
    public abstract class Window
    {
        protected Window()
        {
            Title = "";
            BackgroundColour = new Color(46, 39, 48);
            Position = Vector2.Zero;
            Visible = true;
            ZIndex = 0;
        }
        protected Window(string title)
        {
            Title = title;
            BackgroundColour = new Color(46, 39, 48);
            Position = Vector2.Zero;
            Visible = true;
            ZIndex = 0;
        }
        protected Window(string title, Color backgroundColour)
        {
            Title = title;
            BackgroundColour = backgroundColour;
            Position = Vector2.Zero;
            Visible = true;
            ZIndex = 0;
        }
        protected Window(string title, Color backgroundColour, Vector2 position)
        {
            Title = title;
            BackgroundColour = backgroundColour;
            Position = position;
            Visible = true;
            ZIndex = 0;
        }

        public string Title { get; set; }
        public Color BackgroundColour { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size
        {
            get
            {
                return new Vector2(
                    Math.Max(20, 100 * Main.InterfaceManager.InterfaceScale),
                    Math.Max(20, 200 * Main.InterfaceManager.InterfaceScale));
            }
        }
        public Rectangle Rectangle
        {
            get { return CalculateSize(); }
        }
        public bool Visible { get; set; }
        public int ZIndex { get; set; }

        public abstract void Update(float delta);
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Drawing.DrawRectangle(
                spriteBatch,
                CalculateSize(),
                Color.Red,
                Main.InterfaceManager.InterfaceScale);

            Drawing.DrawString(
                spriteBatch,
                Main.AssetManager.GetFont("MonomaniacOne"),
                Title.ToUpper(),
                Position,
                Color.White,
                Enums.Alignment.BottomLeft,
                Main.InterfaceManager.InterfaceScale);

            Drawing.DrawRoundedLine(
                spriteBatch,
                new Vector2(Position.X, Position.Y),
                new Vector2(Position.X + Size.X, Position.Y + Size.Y),
                4f, Color.White,
                Main.InterfaceManager.InterfaceScale);
        }
        public virtual void Remove()
        {
            Main.InterfaceManager.Windows.Remove(this);
        }
        public virtual Rectangle CalculateSize()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }
        public virtual void ToggleVisibility()
        {
            Visible = !Visible;
        }
    }
}