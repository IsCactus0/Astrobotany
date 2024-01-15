using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Entities
{
    public class Player : Character
    {
        public Player()
        {
            Name = "Player";
            MoveSpeed = 0.1f;
        }
        public Player(Player copy)
            : base(copy)
        {
            Name = copy.Name;
            MoveSpeed = copy.MoveSpeed;
        }

        public override void Update(float delta)
        {
            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sprite = Sprite;
            Texture2D texture = Main.AssetManager.GetTexture(Name);
            spriteBatch.Draw(
                texture,
                new Rectangle(
                    (int)((sprite.X - sprite.Y) * 16f),
                    (int)((sprite.X + sprite.Y) * 8f),
                    sprite.Width, sprite.Height),
                texture.Bounds,
                Color.White,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                (float)(sprite.X + sprite.Y) / (Main.SceneManager.Scene.Width + Main.SceneManager.Scene.Height));
        }
    }
}