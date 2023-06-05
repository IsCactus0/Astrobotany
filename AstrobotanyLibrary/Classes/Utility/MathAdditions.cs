using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Utility
{
    public static class MathAdditions
    {
        public static float BezierCurve(float time)
        {
            return time * time * (3f - 2f * time);
        }
        public static float ParametricCurve(float time)
        {
            float timeSqrd = time * time;
            return timeSqrd / (2f * (timeSqrd - time) + 1f);
        }
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
        public static float Map(float value, float min1, float max1, float min2, float max2)
        {
            return (value - min1) / (max1 - min1) * (max2 - min2) + min2;
        }
        
        public static Vector2 RandomVector()
        {
            return RandomVector(1f);
        }
        public static Vector2 RandomVector(float length)
        {
            return RandomVector(0f, MathHelper.Tau, length);
        }
        public static Vector2 RandomVector(float minLength, float maxLength)
        {
            return RandomVector(0f, MathHelper.Tau, minLength, maxLength);
        }
        public static Vector2 RandomVector(float minAngle, float maxAngle, float length)
        {
            return RandomVector(minAngle, maxAngle, length, length);
        }
        public static Vector2 RandomVector(float minAngle, float maxAngle, float minLength, float maxLength)
        {
            float angle = Main.Random.NextSingle() * (maxAngle - minAngle);
            Vector2 vector = new Vector2(MathF.Cos(angle), MathF.Sin(angle));
            float length = minLength;
            if (minLength != maxLength)
                length = Main.Random.NextSingle() * (maxLength - minLength) + minLength;
            return vector * length;
        }
        public static Vector2 RandomLengthVector()
        {
            return new Vector2(0, Main.Random.NextSingle());
        }
        public static Vector2 RandomLengthVector(float minLength, float maxLength)
        {
            return new Vector2(1f, 0) * (Main.Random.NextSingle() * (maxLength - minLength) + minLength);
        }
        public static Vector2 RandomLengthVector(float angle, float minLength, float maxLength)
        {
            return new Vector2(MathF.Cos(angle), MathF.Sin(angle)) * (Main.Random.NextSingle() * (maxLength - minLength) + minLength);
        }
    }
}