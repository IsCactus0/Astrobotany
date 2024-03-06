using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Particles
{
    public class Smoke : Particle
    {
        public Smoke()
            : base()
        {
            Colour = Color.Gainsboro;
            Size = (Main.Random.NextSingle() + 0.5f) * 2.5f;
            MaxLifespan = 1f + Main.Random.NextSingle();
            Rotation = Main.Random.NextSingle() * MathHelper.Tau;
            RotationalVelocity = (Main.Random.NextSingle() - 0.5f) * 6f;
        }
        public Smoke(float x, float y)
            : base(x, y)
        {
            Colour = Color.Gainsboro;
            Size = (Main.Random.NextSingle() + 0.5f) * 2.5f;
            MaxLifespan = 1f + Main.Random.NextSingle();
            Rotation = Main.Random.NextSingle() * MathHelper.Tau;
            RotationalVelocity = (Main.Random.NextSingle() - 0.5f) * 6f;
        }

        public override void Update(float delta)
        {
            Force += new Vector2(0, -20);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            float age = TimeAlive / MaxLifespan;
            float fade = CalculateFade();
            Drawing.DrawSmoke(
                spriteBatch,
                Position,
                Size * (age + 0.5f),
                Color.Lerp(Color.DimGray, Colour, fade) * fade,
                Vector2.One,
                Rotation,
                1f);
        }
        public override float CalculateFade()
        {
            float age = TimeAlive / MaxLifespan;
            return MathF.Sin(MathF.PI * age);
        }
    }
}