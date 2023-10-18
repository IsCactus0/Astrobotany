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
                    Math.Max(100, Main.AssetManager.GetFont("MonomaniacOne").MeasureString(Title.ToUpper()).X * 0.5f + 24),
                    Math.Max(100, 58));
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
                Rectangle,
                BackgroundColour * 0.8f);

            spriteBatch.DrawString(
                Main.AssetManager.GetFont("MonomaniacOne"),
                Title.ToUpper(),
                Position,
                Color.White * 0.8f,
                0f,
                new Vector2(-32f, 0f),
                0.5f,
                SpriteEffects.None,
                0f);

            Drawing.DrawRoundedLine(
                spriteBatch,
                new Vector2(Position.X + 4f, Position.Y),
                new Vector2(Position.X + Size.X - 4f, Position.Y),
                8f, Color.White);
        }
        public virtual void Remove()
        {
            Main.InterfaceManager.Windows.Remove(this);
        }
        public virtual Rectangle CalculateSize()
        {
            return new Rectangle(Position.ToPoint(), Size.ToPoint());
        }
        public virtual void ToggleVisibility()
        {
            Visible = !Visible;
        }
    }
}