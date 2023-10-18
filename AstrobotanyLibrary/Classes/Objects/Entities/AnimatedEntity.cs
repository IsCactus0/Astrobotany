using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Entities
{
    public abstract class AnimatedEntity : Entity
    {
        protected AnimatedEntity()
            : base()
        {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(AnimatedEntity copy)
        {
            CurrentAnimation = copy.CurrentAnimation;
            Animations = copy.Animations;
        }

        public string CurrentAnimation { get; set; }
        public Dictionary<string, Animation> Animations { get; set; }

        public override void Update(float delta)
        {
            if (!string.IsNullOrEmpty(CurrentAnimation))
                Animations[CurrentAnimation].Update(delta);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Animations[CurrentAnimation].Texture,
                new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    32, 32),
                Color.White);
        }
        public override string ToString()
        {
            string baseString = base.ToString();
            baseString.Replace(GetType().BaseType.Name, GetType().Name);

            return baseString +
                   $"\n   CurrentAnimation: {CurrentAnimation}" +
                   $"\n   DamageResistance: {DamageResistance}";
        }
    }
}