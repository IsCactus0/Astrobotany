using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class ColourRamp
    {
        public ColourRamp(Color start, Color end)
        {
            Colours = new List<Color>() { start, end };
        }
        public ColourRamp(List<Color> colours)
        {
            Colours = new List<Color>(colours);
        }

        public List<Color> Colours;
        
        public Color GetColour(float value)
        {
            int count = Colours.Count;
            int start = (int)Math.Floor(value * count);
            int end = (int)Math.Ceiling(value * count) % count;
            float relative = value * count - start;

            return Color.Lerp(Colours[start], Colours[end], relative);
        }
    }
}