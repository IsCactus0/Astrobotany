using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Utility
{
    public static class MathAdditions
    {
        public static bool PointIntersects(Point point, Rectangle rectangle)
        {
            return (point.X >= rectangle.Left) && (point.X <= rectangle.Right) &&
                    (point.Y >= rectangle.Top) && (point.Y <= rectangle.Bottom);
        }
        public static bool VectorIntersects(Vector2 vector, Rectangle rectangle)
        {
            return (vector.X >= rectangle.Left) && (vector.X <= rectangle.Right) &&
                    (vector.Y >= rectangle.Top) && (vector.Y <= rectangle.Bottom);
        }
        public static Point ToPointCeiling(Vector2 vector)
        {
            return new Point(
                (int)Math.Ceiling(vector.X),
                (int)Math.Ceiling(vector.Y));
        }
        public static Point ToPointFloor(Vector2 vector)
        {
            return new Point(
                (int)Math.Floor(vector.X),
                (int)Math.Floor(vector.Y));
        }
    }
}