﻿using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Camera
    {
        public Camera()
        {
            Scale = 1f;
            Rotation = 0f;
            PhysicsDistance = 1000f;
            Position = Vector2.Zero;
            Offset = Vector2.Zero;
            Viewport = new Viewport();
            SamplerState = SamplerState.PointClamp;
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
                return new Rectangle(
                    (int)(Position.X - Viewport.Width / 2f * (1f / Scale)),
                    (int)(Position.Y - Viewport.Height / 2f * (1f / Scale)),
                    (int)(Viewport.Width * (1f / Scale)),
                    (int)(Viewport.Height * (1f / Scale)));
            }
        }
        public Rectangle PhysicsBoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)(Position.X - Viewport.Width / 2f * (1f / Scale) - PhysicsDistance),
                    (int)(Position.Y - Viewport.Height / 2f * (1f / Scale) - PhysicsDistance),
                    (int)((Viewport.Width * (1f / Scale)) + PhysicsDistance * 2f),
                    (int)((Viewport.Height * (1f / Scale)) + PhysicsDistance * 2f));
            }
        }

        public void Update(float delta, float strength)
        {
            Position = Vector2.Lerp(Position, Offset, delta * strength);
        }
        public void Update(float delta, float strength, Vector2 target)
        {
            Position = Vector2.Lerp(Position, Offset + target, delta * strength);
        }
        public bool WithinBounds(Vector2 position)
        {
            return MathAdditions.VectorIntersects(position, BoundingBox);
        }
    }
}