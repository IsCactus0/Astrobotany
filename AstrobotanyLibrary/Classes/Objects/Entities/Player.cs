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
            spriteBatch.Draw(
                Main.AssetManager.GetTexture(Name),
                new Rectangle(
                    (int)((sprite.X - sprite.Y) * 16f),
                    (int)((sprite.X + sprite.Y) * 8f),
                    sprite.Width, sprite.Height),
                Color.White);
        }
    }
}