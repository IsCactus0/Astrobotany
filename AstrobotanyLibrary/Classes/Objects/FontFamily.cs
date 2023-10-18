using AstrobotanyLibrary.Classes.Enums;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class FontFamily
    {
        public FontFamily()
        {
            Fonts = new Dictionary<FontWeight, SpriteFont>();
        }

        public Dictionary<FontWeight, SpriteFont> Fonts { get; set; }

        public SpriteFont GetFont(FontWeight weight = FontWeight.Regular)
        {
            return Fonts[weight];
        }
    }
}