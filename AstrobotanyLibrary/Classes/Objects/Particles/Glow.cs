using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Particles
{
    public class Glow : Particle
    {
        public Glow()
            : base()
        {

        }

        public Color GlowColour { get; set; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Main.AssetManager.GetTexture("blur"),
                Sprite, null, GlowColour);

            base.Draw(spriteBatch);
        }
    }
}