using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Menus
{
    public abstract class MenuElement
    {
        protected MenuElement()
        {
            Position = Vector2.Zero;
            Size = new Vector2(128);
            Colour = Color.White;
            Font = Main.AssetManager.GetFont("Montserrat");
            Text = "";
            TextScale = 1f;
            TextColour = Color.White;
            Visible = true;
            Active = false;
            Hovering = false;
        }
        protected MenuElement(float x, float y)
        {
            Position = new Vector2(x, y);
            Size = new Vector2(128);
            Colour = Color.White;
            Font = Main.AssetManager.GetFont("Montserrat");
            Text = "";
            TextScale = 1f;
            TextColour = Color.White;
            Visible = true;
            Active = false;
            Hovering = false;
        }
        protected MenuElement(float x, float y, float width, float height)
        {
            Position = new Vector2(x, y);
            Size = new Vector2(width, height);
            Colour = Color.White;
            Font = Main.AssetManager.GetFont("Montserrat");
            Text = "";
            TextScale = 1f;
            TextColour = Color.White;
            Visible = true;
            Active = false;
            Hovering = false;
        }
        protected MenuElement(float x, float y, float width, float height, string text)
        {
            Position = new Vector2(x, y);
            Size = new Vector2(width, height);
            Colour = Color.White;
            Font = Main.AssetManager.GetFont("Montserrat");
            Text = text;
            TextScale = 1f;
            TextColour = Color.White;
            Visible = true;
            Active = false;
            Hovering = false;
        }
        protected MenuElement(float x, float y, float width, float height, string text, float textScale)
        {
            Position = new Vector2(x, y);
            Size = new Vector2(width, height);
            Colour = Color.White;
            Font = Main.AssetManager.GetFont("Montserrat");
            Text = text;
            TextScale = textScale;
            TextColour = Color.White;
            Visible = true;
            Active = false;
            Hovering = false;
        }
        protected MenuElement(float x, float y, float width, float height, string text, float textScale, Color colour)
        {
            Position = new Vector2(x, y);
            Size = new Vector2(width, height);
            Colour = colour;
            Font = Main.AssetManager.GetFont("Montserrat");
            Text = text;
            TextScale = textScale;
            TextColour = Color.White;
            Visible = true;
            Active = false;
            Hovering = false;
        }
        protected MenuElement(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour)
        {
            Position = new Vector2(x, y);
            Size = new Vector2(width, height);
            Colour = colour;
            Font = Main.AssetManager.GetFont("Montserrat");
            Text = text;
            TextScale = textScale;
            TextColour = textColour;
            Visible = true;
            Active = false;
            Hovering = false;
        }

        public Texture2D Texture { get; protected set; }
        public Vector2 Position { get; protected set; }
        public Vector2 Size { get; protected set; }
        public Rectangle Rectangle 
        {
            get
            {
                return new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                (int)(Size.X * Main.InterfaceManager.Scale),
                (int)(Size.Y * Main.InterfaceManager.Scale));
            }
        }
        public Color Colour { get; protected set; }
        public SpriteFont Font { get; protected set; }
        public string Text { get; protected set; }
        public float TextScale { get; protected set; }
        public Color TextColour { get; protected set; }
        public bool Visible { get; protected set; }
        public bool Active { get; protected set; }
        public bool Hovering { get; protected set; }
        public bool ToRemove { get; set; }
        public System.Action StartActivated { get; set; }
        public System.Action ReleaseActivated { get; set; }

        public virtual void Hover() {
            Hovering = true;
        }
        public virtual void Click(MouseButton button = MouseButton.Left) {
            StartActivated?.Invoke();
            Active = true;
        }
        public virtual void Drag(MouseButton button = MouseButton.Left) {
            return;
        }
        public virtual void Release(MouseButton button = MouseButton.Left) {
            ReleaseActivated?.Invoke();
            Active = false;
        }
        public virtual void Leave() {
            Hovering = false;
            Active = false;
        }
        public virtual void Update(float delta) {
            if (ToRemove)
                Remove();

            if (!MathAdditions.VectorIntersects(Main.InterfaceManager.Cursor.Position, Rectangle)) {
                Leave();
                return;
            }

            if (Main.InputManager.MouseFirstPressed())
                Click(Main.InputManager.GetMouseButton());
            else if (Active && Main.InputManager.MouseFirstReleased())
                Release(Main.InputManager.GetMouseButton());
            else if (Main.InputManager.MouseAnyPressed())
                Drag(Main.InputManager.GetMouseButton());
            else Hover();
        }
        public virtual void Draw(SpriteBatch spriteBatch) {
            Drawing.DrawSprite(spriteBatch, Texture, Rectangle, Colour);
            Drawing.DrawString(spriteBatch, Font, Text, Position, Colour, AlignmentVertical.Centre, AlignmentHorizontal.Centre);
        }
        public virtual void SetVisibility(bool visible) {
            Visible = visible;
        }
        public virtual void Remove() {
            Main.InterfaceManager.Elements.Remove(this);
        }
    }
}