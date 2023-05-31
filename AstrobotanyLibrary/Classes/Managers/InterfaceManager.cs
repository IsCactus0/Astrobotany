using AstrobotanyLibrary.Classes.Objects;
using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class InterfaceManager : DrawableGameComponent
    {
        public InterfaceManager(Game game)
            : base(game)
        {
            Windows = new List<Window>();
        }

        public List<Window> Windows { get; set; }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Window window in Windows)
                window.Update(delta);

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}