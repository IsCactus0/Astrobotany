using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Camera
    {
        public Camera()
        {
            Scale = 5f;
            Rotation = 0f;
            PhysicsDistance = 1000f;
            Position = Vector2.Zero;
            Offset = Vector2.Zero;
            Viewport = new Viewport();
            SamplerState = SamplerState.PointClamp;
            ScreenShake = 1f;
        }

        public float Scale { get; set; }
        public float Rotation { get; set; }
        public float PhysicsDistance { get; set; }
        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
                       Matrix.CreateTranslation(-Offset.X, -Offset.Y, 0) *
                       Matrix.CreateRotationZ(Rotation) *
                       Matrix.CreateScale(Scale, Scale, 1) *
                       Matrix.CreateTranslation(Viewport.Width / 2f, Viewport.Height / 2f, 0);
            }
        }
        public Matrix InvertedTransform
        {
            get
            {
                return Matrix.Invert(Transform);
            }
        }
        public Vector2 Position { get; set; }
        public Vector2 Offset { get; set; }
        public Viewport Viewport { get; set; }
        public SamplerState SamplerState { get; set; }
        public Rectangle BoundingBox
        {
            get
            {
                Vector2 position = Vector2.Transform(
                    new Vector2(
                        Viewport.X - (Viewport.Width / 2f),
                        Viewport.Y - (Viewport.Height / 2f)),
                    InvertedTransform);

                return new Rectangle(
                    (int)MathF.Floor(position.X) - 1,
                    (int)MathF.Floor(position.Y) - 1,
                    (int)MathF.Ceiling(Main.Settings.Resolution.X / Scale) + 2,
                    (int)MathF.Ceiling(Main.Settings.Resolution.Y / Scale) + 2);
            }
        }
        public Rectangle PhysicsBoundingBox
        {
            get
            {
                Vector2 position = Vector2.Transform(
                    new Vector2(
                        Viewport.X - (Viewport.Width / 2f),
                        Viewport.Y - (Viewport.Height / 2f)),
                    InvertedTransform);
                
                return new Rectangle(
                    (int)MathF.Floor(position.X - PhysicsDistance) - 1,
                    (int)MathF.Floor(position.Y - PhysicsDistance) - 1,
                    (int)MathF.Ceiling(Main.Settings.Resolution.X / Scale + PhysicsDistance * 2f) + 2,
                    (int)MathF.Ceiling(Main.Settings.Resolution.Y / Scale + PhysicsDistance * 2f) + 2);
            }
        }
        public float ScreenShake { get; set; }

        public void Update(float delta, float strength, Vector2 target)
        {
            Vector2 shake = Vector2.Zero;
            if (Main.Settings.ScreenShake)
            {
                ScreenShake -= delta;
                if (ScreenShake < 0f)
                    ScreenShake = 0f;

                shake = MathAdditions.RandomVector((float)Main.OpenSimplexNoise.Evaluate(ScreenShake / 1000f, 0f)) * 100f;
                shake.X *= 3f;
            }

            Position = Vector2.Lerp(Position, Offset + target + shake, delta * strength);
        }
        public void Apply()
        {
            Position += Offset;
        }
        public bool WithinBounds(Vector2 position)
        {
            return MathAdditions.VectorIntersects(position, BoundingBox);
        }
    }
}