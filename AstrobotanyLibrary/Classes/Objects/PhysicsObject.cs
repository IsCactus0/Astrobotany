using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public abstract class PhysicsObject : GameObject
    {
        protected PhysicsObject()
        {
            Velocity = Vector2.Zero;
            RotationalVelocity = 0f;
            Acceleration = Vector2.Zero;
            RotationalAcceloration = 0f;
            Force = Vector2.Zero;
            RotationalForce = 0f;
            Mass = 1f;
            Friction = 0.5f;
        }
        protected PhysicsObject(string name)
            : base(name)
        {
            Velocity = Vector2.Zero;
            RotationalVelocity = 0f;
            Acceleration = Vector2.Zero;
            RotationalAcceloration = 0f;
            Force = Vector2.Zero;
            RotationalForce = 0f;
            Mass = 1f;
            Friction = 0.5f;
        }
        protected PhysicsObject(string name, bool solid)
            : base(name, solid)
        {
            Velocity = Vector2.Zero;
            RotationalVelocity = 0f;
            Acceleration = Vector2.Zero;
            RotationalAcceloration = 0f;
            Force = Vector2.Zero;
            RotationalForce = 0f;
            Mass = 1f;
            Friction = 0.5f;
        }
        protected PhysicsObject(string name, bool solid, int size)
            : base(name, solid, size)
        {
            Velocity = Vector2.Zero;
            RotationalVelocity = 0f;
            Acceleration = Vector2.Zero;
            RotationalAcceloration = 0f;
            Force = Vector2.Zero;
            RotationalForce = 0f;
            Mass = 1f;
            Friction = 0.5f;
        }
        protected PhysicsObject(string name, bool solid, int width, int height)
            : base(name, solid, width, height)
        {
            Velocity = Vector2.Zero;
            RotationalVelocity = 0f;
            Acceleration = Vector2.Zero;
            RotationalAcceloration = 0f;
            Force = Vector2.Zero;
            RotationalForce = 0f;
            Mass = 1f;
            Friction = 0.5f;
        }
        protected PhysicsObject(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight)
        {
            Velocity = Vector2.Zero;
            RotationalVelocity = 0f;
            Acceleration = Vector2.Zero;
            RotationalAcceloration = 0f;
            Force = Vector2.Zero;
            RotationalForce = 0f;
            Mass = 1f;
            Friction = 0.5f;
        }
        protected PhysicsObject(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y)
        {
            Velocity = Vector2.Zero;
            RotationalVelocity = 0f;
            Acceleration = Vector2.Zero;
            RotationalAcceloration = 0f;
            Force = Vector2.Zero;
            RotationalForce = 0f;
            Mass = 1f;
            Friction = 0.5f;
        }
        protected PhysicsObject(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {
            Velocity = Vector2.Zero;
            RotationalVelocity = 0f;
            Acceleration = Vector2.Zero;
            RotationalAcceloration = 0f;
            Force = Vector2.Zero;
            RotationalForce = 0f;
            Mass = 1f;
            Friction = 0.5f;
        }
        protected PhysicsObject(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {
            Velocity = new Vector2(vx, vy);
            RotationalVelocity = vr;
            Acceleration = Vector2.Zero;
            RotationalAcceloration = 0f;
            Force = Vector2.Zero;
            RotationalForce = 0f;
            Mass = 1f;
            Friction = 0.5f;
        }
        protected PhysicsObject(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {
            Velocity = new Vector2(vx, vy);
            RotationalVelocity = vr;
            Acceleration = new Vector2(ax, ay);
            RotationalAcceloration = ar;
            Force = Vector2.Zero;
            RotationalForce = 0f;
            Mass = 1f;
            Friction = 0.5f;
        }
        protected PhysicsObject(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {
            Velocity = new Vector2(vx, vy);
            RotationalVelocity = vr;
            Acceleration = new Vector2(ax, ay);
            RotationalAcceloration = ar;
            Force = Vector2.Zero;
            RotationalForce = 0f;
            Mass = mass;
            Friction = 0.5f;
        }
        protected PhysicsObject(string name, bool solid, int spriteWidth, int spriteHeight, int hitboxWidth, int hitboxHeight, float x, float y, float r, float vx, float vy, float vr, float ax, float ay, float ar, float mass, float friction)
            : base(name, solid, spriteWidth, spriteHeight, hitboxWidth, hitboxHeight, x, y, r)
        {
            Velocity = new Vector2(vx, vy);
            RotationalVelocity = vr;
            Acceleration = new Vector2(ax, ay);
            RotationalAcceloration = ar;
            Force = Vector2.Zero;
            RotationalForce = 0f;
            Mass = mass;
            Friction = friction;
        }

        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Vector2 Force { get; set; }
        public float RotationalVelocity { get; set; }
        public float RotationalAcceloration { get; set; }
        public float RotationalForce { get; set; }
        public float Mass { get; set; }
        public float Friction { get; set; }

        public virtual List<GameObject> FindCollisions()
        {
            Rectangle hitbox = Hitbox;
            List<GameObject> colliding = Main.DecorationManager.FindAllInBounds(hitbox)
                                 .Concat(Main.EntityManager.FindAllInBounds(hitbox)).ToList();

            colliding.Remove(this);
            return colliding;
        }
        public virtual void HandleCollisions(float delta)
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
            ResetForces();
            base.Reset();
        }
        public virtual void ResetForces()
        {
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
            Force = Vector2.Zero;

            RotationalVelocity = 0f;
            RotationalAcceloration = 0f;
            RotationalForce = 0f;
        }
        public override void Update(float delta)
        {
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

            HandleCollisions(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public override string ToString()
        {
            string baseString = base.ToString();
            baseString.Replace(GetType().BaseType.Name, GetType().Name);

            return baseString +
                   $"\n   Velocity: {Velocity}" +
                   $"\n   Acceleration: {Acceleration}" +
                   $"\n   Force: {Force}" +
                   $"\n   Rotational Velocity: {RotationalVelocity}" +
                   $"\n   Rotational Acceloration: {RotationalAcceloration}" +
                   $"\n   Rotational Force: {RotationalForce}" +
                   $"\n   Mass: {Mass}" +
                   $"\n   Friction: {Friction}";
        }
    }
}