using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Layer
    {
        public Layer(float minDepth, float maxDepth)
        {
            MinDepth = minDepth;
            MaxDepth = maxDepth;
        }

        public float MinDepth;
        public float MaxDepth;

        public float LayerDepth(Vector2 location)
        {
            return LayerDepth(location.X, location.Y);
        }
        public float LayerDepth(float x, float y)
        {
            return ((x + y) / (MaxDepth - MinDepth)) + MinDepth;
        }
    }
}