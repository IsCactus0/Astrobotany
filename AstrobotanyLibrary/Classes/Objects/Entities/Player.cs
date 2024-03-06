using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Entities
{
    public class Player : Character
    {
        public Player() {
            Name = "Player";
            BaseMoveSpeed = 0.2f;
            Animations = new Dictionary<string, Animation>() {
                { "idle_down",  new Animation("entities/player", new Point(24, 26), 0, 2, 1.0f, true) },
                { "idle_left",  new Animation("entities/player", new Point(24, 26), 10, 12, 1.0f, true) },
                { "idle_up",    new Animation("entities/player", new Point(24, 26), 20, 20, 1.0f, false) },
                { "idle_right", new Animation("entities/player", new Point(24, 26), 30, 32, 1.0f, true) },
                { "run_down",   new Animation("entities/player", new Point(24, 26), 40, 49, BaseMoveSpeed / 3f, true) },
                { "run_left",   new Animation("entities/player", new Point(24, 26), 50, 59, BaseMoveSpeed / 3f, true) },
                { "run_up",     new Animation("entities/player", new Point(24, 26), 60, 69, BaseMoveSpeed / 3f, true) },
                { "run_right",  new Animation("entities/player", new Point(24, 26), 70, 79, BaseMoveSpeed / 3f, true) },
            };
        }
        public Player(Player copy) : base(copy) {
            Name = copy.Name;
            MoveSpeed = copy.MoveSpeed;
        }

        public override void Update(float delta) {
            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch) {
            base.Draw(spriteBatch);
        }
    }
}