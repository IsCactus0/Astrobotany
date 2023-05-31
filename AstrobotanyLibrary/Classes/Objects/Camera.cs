using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Camera
    {
        public float Scale { get; set; } = 1f;
        public float Rotation { get; set; } = 0f;
        public float ViewDistance { get; set; } = 1000f;
        public Matrix Transform { get; private set; } = Matrix.Identity;
        public Matrix InvertedTransform { get; private set; } = Matrix.Identity;
        public Vector2 Position { get; set; } = Vector2.Zero;
        public Vector2 Offset { get; set; } = Vector2.Zero;
        public Viewport Viewport { get; set; } = new Viewport();
        public SamplerState SamplerState { get; set; } = SamplerState.PointClamp;
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)(Position.X - (Viewport.Width / 2f) * (1f / Scale)),
                    (int)(Position.Y - (Viewport.Height / 2f) * (1f / Scale)),
                    (int)(Viewport.Width * (1f / Scale)),
                    (int)(Viewport.Height * (1f / Scale)));
            }
        }
        public Rectangle RenderBoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)((Position.X - (Viewport.Width / 2f) * (1f / Scale)) - ViewDistance),
                    (int)((Position.Y - (Viewport.Height / 2f) * (1f / Scale)) - ViewDistance),
                    (int)((Viewport.Width * (1f / Scale)) + ViewDistance * 2f),
                    (int)((Viewport.Height * (1f / Scale)) + ViewDistance * 2f));
            }
        }

        public void Update(float delta, float strength, Vector2 target)
        {
            Position = Vector2.Lerp(Position, Offset + target, delta * strength);
            Transform =
                Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(new Vector3(Scale, Scale, 1)) *
                Matrix.CreateTranslation(new Vector3(Viewport.Width / 2f, Viewport.Height / 2f, 0));
        }
        public bool WithinBounds(Vector2 position)
        {
            Rectangle bounds = BoundingBox;
            return (position.X >= bounds.X) && (position.X <= bounds.X + bounds.Width) &&
                    (position.Y >= bounds.Y) && (position.Y <= bounds.Y + bounds.Height);
        }
    }
}