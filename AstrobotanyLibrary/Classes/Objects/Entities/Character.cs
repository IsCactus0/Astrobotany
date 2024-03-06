using AstrobotanyLibrary.Classes.Objects.Items;
using AstrobotanyLibrary.Classes.Objects.Pathfinding;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Entities
{
    public abstract class Character : AnimatedEntity {
        protected Character() : base() {
            BaseMoveSpeed = 1f;
            MoveSpeed = 1f;
            Queue = new Queue<NavPath>();
            Inventory = new Inventory();
        }
        protected Character(Character copy) {
            BaseMoveSpeed = copy.BaseMoveSpeed;
            MoveSpeed = copy.MoveSpeed;
            Queue = new Queue<NavPath>(copy.Queue);
            Inventory = copy.Inventory;
        }

        public float BaseMoveSpeed { get; protected set; }
        public float MoveSpeed { get; protected set; }
        public float LastMoved { get; protected set; }
        public bool IsMoving { get; protected set; }
        public Point Facing { get; set; }
        public Queue<NavPath> Queue { get; set; }
        public Inventory Inventory { get; protected set; }

        public override void Update(float delta) {
            IsMoving = false;
            string newAnimation = "idle_";
            MoveSpeed = BaseMoveSpeed;

            if (Queue.Count > 0) {
                newAnimation = "run_";
                if ((Facing.X == -1 && Facing.Y == 1) || (Facing.X == 1 && Facing.Y == -1))
                    MoveSpeed = BaseMoveSpeed * MathAdditions.SQUAREROOT2;

                if (Queue.Peek().Steps.Count > 0) {
                    IsMoving = true;
                    LastMoved += delta;
                    if (LastMoved >= MoveSpeed)
                        for (int i = 0; i < (int)Math.Floor(LastMoved / MoveSpeed); i++)
                            Move(delta);

                    if (IsMoving) {
                        Point newFacing = Position.ToPoint() - Queue.Peek().Steps.Peek();
                        if (Facing.X == newFacing.X * -1 && Facing.Y == newFacing.Y * -1)
                            Stop();
                        
                        Facing = newFacing;
                    }
                }
            }

            if (Facing.X == Facing.Y) {
                if (Facing.Y > 0)
                    newAnimation += "up";
                else newAnimation += "down";
            }
            else {
                if (Facing.X > 0 || Facing.Y < 0)
                    newAnimation += "left";
                else newAnimation += "right";
            }

            SetAnimation(newAnimation);

            base.Update(delta);
        }
        public virtual void Stop()
        {
            // Main.ParticleManager.Particles.Add(
            //     new Smoke()
            //     {
            //         Position = new Vector2(
            //             (Position.X - Position.Y + 1f) * 16f,
            //             (Position.X + Position.Y + 1f) * 8f),
            //         Velocity = new Vector2(
            //             (Facing.X - Facing.Y) * 16f,
            //             (Facing.X + Facing.Y) * 8f)
            //     });
        }
        public virtual void Move(float delta)
        {
            NavPath current = Queue.Peek();
            Point nextStep = current.Steps.Dequeue();

            Position = nextStep.ToVector2();
            LastMoved = 0f;

            if (Queue.Count > 1 || current.Steps.Count == 0)
            {
                Queue.Dequeue();
                IsMoving = false;
                return;
            }
        }
        public virtual void QueueMove(Point newTarget, Grid grid)
        {
            Point position = Position.ToPoint();
            if (newTarget == position)
                return;

            if (Queue.Count > 0)
            {
                NavPath current = Queue.Peek();
                if (current.Steps.Count == 0 || current.End == newTarget || current.Steps.Peek() == newTarget)
                    return;

                current = Queue.Dequeue();
                Queue.Clear();
                Queue.TrimExcess();
                Queue.Enqueue(current);
                Queue.Enqueue(new NavPath(current.Steps.Peek(), newTarget, grid));
                return;
            }

            NavPath path = new(position, newTarget, grid);
            if (path.Steps.Count > 0)
                Queue.Enqueue(path);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sprite = Sprite;
            Vector2 transition = IsMoving ?
                Vector2.Lerp(Position, Queue.Peek().Steps.Peek().ToVector2(), LastMoved / MoveSpeed) :
                Position;

            Animation animation = Animations[CurrentAnimation];
            Texture2D texture = animation.SpriteSheet;
            int framesX = texture.Bounds.Width / animation.FrameSize.X;
            int x = (int)animation.CurrentIndex % framesX;
            int y = (int)animation.CurrentIndex / framesX;
            int offsetX = (32 - animation.FrameSize.X) / 2 + 1;

            spriteBatch.Draw(
                texture,
                new Vector2(
                    sprite.X + offsetX + (transition.X - transition.Y) * 16f,
                    sprite.Y + (transition.X + transition.Y) * 8f),
                new Rectangle(
                    x * animation.FrameSize.X,
                    y * animation.FrameSize.Y,
                    animation.FrameSize.X,
                    animation.FrameSize.Y),
                Color.White,
                0f, Vector2.Zero, 1f,
                SpriteEffects.None,
                Main.SceneManager.Layer.LayerDepth(transition));

            base.Draw(spriteBatch);
        }
        public override string ToString()
        {
            string baseString = base.ToString().Replace(GetType().BaseType.Name, GetType().Name);

            return baseString +
                   $"\n   MoveSpeed: {MoveSpeed} / {BaseMoveSpeed}" +
                   $"\n   Inventory: {DamageResistance}" +
                   $"\n   Facing: {Facing}";
        }
    }
}