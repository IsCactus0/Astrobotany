using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public abstract class GameObject
    {
        protected GameObject()
        {
            Solid = true;
            Hitbox = new Rectangle(0, 0, 32, 32);
            Sprite = new Rectangle(0, 0, 32, 32);
            Position = Vector2.Zero;
        }
        protected GameObject(float x, float y)
        {
            Solid = true;
            Hitbox = new Rectangle(0, 0, 32, 32);
            Sprite = new Rectangle(0, 0, 32, 32);
            Position = new Vector2(x, y);
        }
        protected GameObject(GameObject copy)
        {
            Solid = copy.Solid;
            Hitbox = copy.Hitbox;
            Sprite = copy.Sprite;
            Position = copy.Position;
        }

        public string Name { get; protected set; }
        public bool Solid { get; set; }
        public Rectangle Hitbox { get; set; }
        public Rectangle Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Centre {
            get
            {
                return Position + Sprite.Center.ToVector2();
            }
        }

        public abstract void Update(float delta);
        public abstract void Draw(SpriteBatch spriteBatch);
        public virtual void Reset()
        {
            Position = Vector2.Zero;
        }
        public abstract void Destroy();
        public override string ToString()
        {
            Rectangle hitbox = Hitbox;
            Rectangle sprite = Sprite;

            return $"[{GetType().Name}]" +
                   $"\n   Solid: {Solid}" +
                   $"\n   Hitbox:" +
                   $"\n      Size: {hitbox.Width}, {hitbox.Height}" +
                   $"\n      Position: {hitbox.Location.X}, {hitbox.Location.Y}" +
                   $"\n   Sprite: {sprite.Location.X}, {sprite.Location.Y}" +
                   $"\n      Size: {sprite.Width}, {sprite.Height}" +
                   $"\n      Position: {sprite.Location.X}, {sprite.Location.Y}" +
                   $"\n   Position: {Position}";
        }
    }
}