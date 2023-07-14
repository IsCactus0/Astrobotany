using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public abstract class GameObject
    {
        protected GameObject()
        {
            Name = "";
            Solid = true;
            Hitbox = new Rectangle(0, 0, 32, 32);
            Sprite = new Rectangle(0, 0, 32, 32);
            Position = Vector2.Zero;
            Rotation = 0f;
        }
        protected GameObject(string name)
        {
            Name = name;
            Solid = true;
            Hitbox = new Rectangle(0, 0, 32, 32);
            Sprite = new Rectangle(0, 0, 32, 32);
            Position = Vector2.Zero;
            Rotation = 0f;
        }
        protected GameObject(string name, bool solid)
        {
            Name = name;
            Solid = solid;
            Hitbox = new Rectangle(0, 0, 32, 32);
            Sprite = new Rectangle(0, 0, 32, 32);
            Position = Vector2.Zero;
            Rotation = 0f;
        }
        protected GameObject(string name, bool solid, int size)
        {
            Name = name;
            Solid = solid;
            Hitbox = new Rectangle(0, 0, size, size);
            Sprite = new Rectangle(0, 0, size, size);
            Position = Vector2.Zero;
            Rotation = 0f;
        }
        protected GameObject(string name, bool solid, int width, int height)
        {
            Name = name;
            Solid = solid;
            Hitbox = new Rectangle(0, 0, width, height);
            Sprite = new Rectangle(0, 0, width, height);
            Position = Vector2.Zero;
            Rotation = 0f;
        }
        protected GameObject(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight)
        {
            Name = name;
            Solid = solid;
            Hitbox = new Rectangle(0, 0, hitboxWidth, hitboxHeight);
            Sprite = new Rectangle(0, 0, spriteWidth, spriteHeight);
            Position = Vector2.Zero;
            Rotation = 0f;
        }
        protected GameObject(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y)
        {
            Name = name;
            Solid = solid;
            Hitbox = new Rectangle(0, 0, hitboxWidth, hitboxHeight);
            Sprite = new Rectangle(0, 0, spriteWidth, spriteHeight);
            Position = new Vector2(x, y);
            Rotation = 0f;
        }
        protected GameObject(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r)
        {
            Name = name;
            Solid = solid;
            Hitbox = new Rectangle(0, 0, hitboxWidth, hitboxHeight);
            Sprite = new Rectangle(0, 0, spriteWidth, spriteHeight);
            Position = new Vector2(x, y);
            Rotation = r;
        }

        protected Rectangle sprite_;
        protected Rectangle hitbox_;

        public string Name { get; protected set; }
        public bool Solid { get; protected set; }
        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X + hitbox_.X,
                    (int)Position.Y + hitbox_.Y,
                    hitbox_.Width,
                    hitbox_.Height);
            }
            protected set
            {
                hitbox_ = value;
            }
        }
        public Rectangle Sprite
        {
            get
            {
                return new Rectangle(
                    (int)Position.X + sprite_.X,
                    (int)Position.Y + sprite_.Y,
                    sprite_.Width,
                    sprite_.Height);
            }
            protected set
            {
                sprite_ = value;
            }
        }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }

        public abstract void Destroy();
        public virtual void Reset()
        {
            Position = Vector2.Zero;
            Rotation = 0f;
        }
        public abstract void Update(float delta);
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Main.AssetManager.GetTexture(Name), Sprite, Color.White);
        }
        public override string ToString()
        {
            Rectangle hitbox = Hitbox;
            Rectangle sprite = Sprite;

            return $"[{GetType().Name}]" +
                   $"\n   Name: \"{Name}\"" +
                   $"\n   Solid: {Solid}" +
                   $"\n   Hitbox:" +
                   $"\n      Size: {hitbox.Width}, {hitbox.Height}" +
                   $"\n      Position: {hitbox.Location.X}, {hitbox.Location.Y}" +
                   $"\n   Sprite: {sprite.Location.X}, {sprite.Location.Y}" +
                   $"\n      Size: {sprite.Width}, {sprite.Height}" +
                   $"\n      Position: {sprite.Location.X}, {sprite.Location.Y}" +
                   $"\n   Position: {Position}" +
                   $"\n   Rotation: {Rotation}°";
        }
    }
}