using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Entities
{
    public abstract class AnimatedEntity : Entity {
        protected AnimatedEntity() : base() {
            CurrentAnimation = "";
            Animations = new Dictionary<string, Animation>();
        }
        protected AnimatedEntity(AnimatedEntity copy) : base(copy) {
            CurrentAnimation = copy.CurrentAnimation;
            Animations = copy.Animations;
        }

        public string CurrentAnimation { get; set; }
        public Dictionary<string, Animation> Animations { get; set; }

        public void SetAnimation(string newAnimation) {
            if (CurrentAnimation == newAnimation)
                return;

            CurrentAnimation = newAnimation;
            Animations[CurrentAnimation].CurrentIndex = Animations[CurrentAnimation].StartIndex;
        }
        public override void Update(float delta) {
            if (!string.IsNullOrEmpty(CurrentAnimation))
                Animations[CurrentAnimation].Update(delta);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch) {
            base.Draw(spriteBatch);
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