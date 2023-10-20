using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Objects
{
    public abstract class PhysicsObject : GameObject
    {
        protected PhysicsObject()
        {
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
            Force = Vector2.Zero;
            Rotation = 0f;
            RotationalVelocity = 0f;
            RotationalAcceloration = 0f;
            RotationalForce = 0f;
            Mass = 1f;
            Friction = 0.5f;
        }
        protected PhysicsObject(PhysicsObject copy)
        {
            Velocity = copy.Velocity;
            Acceleration = copy.Acceleration;
            Force = copy.Force;
            Rotation = copy.Rotation;
            RotationalVelocity = copy.RotationalVelocity;
            RotationalAcceloration = copy.RotationalAcceloration;
            RotationalForce = copy.RotationalForce;
            Mass = copy.Mass;
            Friction = copy.Friction;
        }

        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Vector2 Force { get; set; }
        public Vector2 LastPosition { get; protected set; }
        public float Rotation { get; set; }
        public float RotationalVelocity { get; set; }
        public float RotationalAcceloration { get; set; }
        public float RotationalForce { get; set; }
        public float Mass { get; set; }
        public float Friction { get; set; }

        public virtual List<GameObject> FindCollisions()
        {
            Rectangle hitbox = Hitbox;
            List<GameObject> colliding = Main.EntityManager.FindAllInBounds(hitbox);

            colliding.Remove(this);
            return colliding;
        }
        public virtual void ProcessCollisions(float delta)
        {
            if (!Solid)
                return;

            foreach (GameObject other in FindCollisions())
            {
                if (!other.Solid)
                    continue;

                var result = MathAdditions.IntersectDynamic(this, other, delta);
                if (result.Collision && result.Time < 1.0f)
                {
                    Vector2 difference = result.Normal * new Vector2(MathF.Abs(Velocity.X), MathF.Abs(Velocity.Y)) * (1f - result.Time) * delta;                    
                    if (other is not PhysicsObject)
                    {
                        Position += difference;
                        continue;
                    }

                    // Offset to correct for overlap.
                    Position += difference * 0.5f;
                    other.Position -= difference * 0.5f;
                } 
            }
        }
        public override void Reset()
        {
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
            Force = Vector2.Zero;

            Rotation = 0f;
            RotationalVelocity = 0f;
            RotationalAcceloration = 0f;
            RotationalForce = 0f;

            base.Reset();
        }
        public override void Update(float delta)
        {
            LastPosition = Position;

            RotationalAcceloration = RotationalForce / Mass;
            RotationalVelocity += RotationalAcceloration * delta;
            RotationalVelocity *= MathF.Pow(Friction, delta * Mass);
            if (Math.Abs(RotationalVelocity) < 0.01f)
                RotationalVelocity = 0f;
            Rotation += RotationalVelocity * delta;
            RotationalForce = 0f;

            Acceleration = Force / Mass;
            Velocity += Acceleration * delta;
            Velocity *= MathF.Pow(Friction, delta);
            if (Math.Abs(Velocity.X) < 0.01f)
                Velocity *= Vector2.UnitY;
            if (Math.Abs(Velocity.Y) < 0.01f) 
                Velocity *= Vector2.UnitX;
            Position += Velocity * delta;
            Force = Vector2.Zero;

            ProcessCollisions(delta);
        }
        public override string ToString()
        {
            string baseString = base.ToString();
            baseString = baseString.Replace(GetType().BaseType.Name, GetType().Name);

            return baseString +
                   $"\n   Velocity: {Velocity}" +
                   $"\n   Acceleration: {Acceleration}" +
                   $"\n   Force: {Force}" +
                   $"\n   Rotation: {Rotation}°" +
                   $"\n   Rotational Velocity: {RotationalVelocity}" +
                   $"\n   Rotational Acceloration: {RotationalAcceloration}" +
                   $"\n   Rotational Force: {RotationalForce}" +
                   $"\n   Mass: {Mass}" +
                   $"\n   Friction: {Friction}";
        }
    }
}