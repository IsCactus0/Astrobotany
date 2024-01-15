using AstrobotanyLibrary.Classes.Objects;
using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Utility
{
    public struct Intersection
    {
        public Intersection(float time, Vector2 contact, Vector2 normal)
        {
            this.time = time;
            this.contact = contact;
            this.normal = normal;
        }

        float time;
        Vector2 contact;
        Vector2 normal;
    }
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
        public static Rectangle CenterRect(Vector2 position, int size)
        {
            return new Rectangle(
                (int)(position.X - size / 2f),
                (int)(position.Y - size / 2f),
                (int)size,
                (int)size);
        }
        public static Rectangle CenterRect(Vector2 position, Vector2 size)
        {
            return new Rectangle(
                (int)(position.X - size.X / 2f),
                (int)(position.Y - size.Y / 2f),
                (int)size.X,
                (int)size.Y);
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

        public static Vector2 CartesionToIsometric(Vector2 input, float width, float height)
        {
            return new Vector2(
                input.X / width + input.Y / height,
                -input.X / width + input.Y / height) * 0.5f;
        }
        public static Vector2 IsometricToCartesion(Vector2 input, float width, float height)
        {
            return new Vector2(
                (input.X - input.Y) * (width / 2),
                (input.X + input.Y) * (height / 2));
        }
        public static float LayerDepth(Point position, int maxDepth)
        {
            return (float)(position.X + position.Y) / maxDepth;
        }

        public static Vector2 Reflect(Vector2 direction, Vector2 normal)
        {
            return direction - 2f * normal * (direction * normal);
        }
        public static (bool Collision, float Time, Vector2 Contact, Vector2 Normal) RayIntersect(Vector2 rayOrigin, Vector2 rayEnd, Rectangle target)
        {
            Vector2 rayDirection = rayEnd - rayOrigin;
            Vector2 invertedDirection = new Vector2(1f / rayDirection.X, 1f / rayDirection.Y);

            Vector2 near = (target.Location.ToVector2() - rayOrigin) * invertedDirection;
            Vector2 far = ((target.Location + target.Size).ToVector2() - rayOrigin) * invertedDirection;

            if (float.IsNaN(far.Y) || float.IsNaN(far.X))
                return default;
            if (float.IsNaN(near.Y) || float.IsNaN(near.X))
                return default;

            if (near.X > far.X)
                (near.X, far.X) = (far.X, near.X);
            if (near.Y > far.Y)
                (near.Y, far.Y) = (far.Y, near.Y);

            if (near.X > far.Y || near.Y > far.X)
                return default;

            float hit_near = MathF.Max(near.X, near.Y);
            float hit_far = MathF.Min(far.X, far.Y);

            if (hit_far < 0)
                return default;

            Vector2 contact = rayOrigin + (rayDirection * hit_near);

            Vector2 normal = Vector2.Zero;
            if (near.X > near.Y)
                if (invertedDirection.X < 0)
                    normal = Vector2.UnitX;
                else normal = -Vector2.UnitX;
            else if (near.X < near.Y)
                if (invertedDirection.Y < 0)
                    normal = Vector2.UnitY;
                else normal = -Vector2.UnitY;

            return (true, hit_near, contact, normal);
        }
        public static (bool Collision, float Time, Vector2 Contact, Vector2 Normal) IntersectDynamic(PhysicsObject source, GameObject target, float delta)
        {
            Rectangle sourceHitbox = source.Hitbox;
            Rectangle targetHitbox = target.Hitbox;

            Rectangle expandedTargetHitbox = new Rectangle(
                targetHitbox.X - sourceHitbox.Width / 2,
                targetHitbox.Y - sourceHitbox.Height / 2,
                targetHitbox.Width + sourceHitbox.Width,
                targetHitbox.Height + sourceHitbox.Height);

            Vector2 start = source.Position + (sourceHitbox.Size.ToVector2() / 2f);
            return RayIntersect(start, start + source.Velocity * delta, expandedTargetHitbox);
        }
    }
}