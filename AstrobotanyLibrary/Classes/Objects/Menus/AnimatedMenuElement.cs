using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Objects.Menus {
    public abstract class AnimatedMenuElement : MenuElement
    {
        protected AnimatedMenuElement()
            : base() {
            FadeTime = 0.1f;
            TimeAlive = 0f;
        }
        protected AnimatedMenuElement(float x, float y)
            : base(x, y) {
            FadeTime = 0.1f;
            TimeAlive = 0f;
        }
        protected AnimatedMenuElement(float x, float y, float width, float height)
            : base(x, y, width, height) {
            FadeTime = 0.1f;
            TimeAlive = 0f;
        }
        protected AnimatedMenuElement(float x, float y, float width, float height, string text)
            : base(x, y, width, height, text) {
            FadeTime = 0.1f;
            TimeAlive = 0f;
        }
        protected AnimatedMenuElement(float x, float y, float width, float height, string text, float textScale)
            : base(x, y, width, height, text, textScale) {
            FadeTime = 0.1f;
            TimeAlive = 0f;
        }
        protected AnimatedMenuElement(float x, float y, float width, float height, string text, float textScale, Color colour)
            : base(x, y, width, height, text, textScale, colour) {
            FadeTime = 0.1f;
            TimeAlive = 0f;
        }
        protected AnimatedMenuElement(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour)
            : base(x, y, width, height, text, textScale, colour, textColour) {
            FadeTime = 0.2f;
            TimeAlive = 1f;
        }
        protected AnimatedMenuElement(float x, float y, float width, float height, string text, float textScale, Color colour, Color textColour, float fadeTime)
            : base(x, y, width, height, text, textScale, colour, textColour) {
            FadeTime = fadeTime;
            TimeAlive = 1f;
        }

        public float FadeTime { get; protected set; }
        public float TimeAlive { get; protected set; }

        public override void Update(float delta) {
            if (Active || Hovering)
                TimeAlive = Math.Min(TimeAlive + delta, 1);
            else TimeAlive -= delta;

            if (TimeAlive < 0)
                ToRemove = true;

            base.Update(delta);
        }
        public virtual float GetFadeAmount() {
            if (TimeAlive <= FadeTime)
                return MathF.Sin(TimeAlive / FadeTime * MathF.PI / 2f);
            else return 1f;
        }
    }
}