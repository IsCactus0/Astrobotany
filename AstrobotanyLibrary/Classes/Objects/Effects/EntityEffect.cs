using AstrobotanyLibrary.Classes.Objects.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Effects
{
    public abstract class EntityEffect
    {
        public float TimeActive { get; set; }
        public float MaxTime { get; set; }

        public virtual void Remove(Entity target)
        {
            target.Effects.Remove(this);
        }
        public virtual void Update(float delta, Entity target)
        {
            TimeActive += delta;
            if (TimeActive > MaxTime)
                Remove(target);
        }
        public abstract void Draw(SpriteBatch spriteBatch, Entity target);
        public override string ToString()
        {
            return $"\n      {GetType().Name}" +
                   $"\n         Time Active: {TimeActive}" +
                   $"\n         Max Time: {MaxTime}";
        }
    }
}