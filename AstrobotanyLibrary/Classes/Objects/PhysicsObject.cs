using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public abstract class PhysicsObject : GameObject
    {
        public PhysicsObject()
            : base()
        {
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
        }
        public PhysicsObject(float x, float y)
            : base(x, y)
        {
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
        }
        public PhysicsObject(float x, float y, float vx, float vy)
            : base(x, y)
        {
            Velocity = new Vector2(vx, vy);
            Acceleration = Vector2.Zero;
        }
        public PhysicsObject(float x, float y, float vx, float vy, float ax, float ay)
            : base(x, y)
        {
            Velocity = new Vector2(vx, vy);
            Acceleration = new Vector2(ax, ay);
        }

        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public override void Update(float delta)
        {
            Velocity += Acceleration * delta;
            Position += Velocity * delta;
            Acceleration = Vector2.Zero;
        }
    }
}