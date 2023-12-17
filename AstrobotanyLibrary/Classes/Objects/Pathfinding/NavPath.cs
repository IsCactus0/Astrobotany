using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Pathfinding
{
    public class NavPath
    {
        public NavPath()
        {
            Start = new Point();
            End = new Point();
            Steps = new List<Point>();
        }
        public NavPath(NavPath copy)
        {
            Start = new Point();
            End = new Point();
            Steps = new List<Point>(copy.Steps);
        }

        public Point Start { get; set; }
        public Point End { get; set; }
        public List<Point> Steps { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Point step in Steps)
            {
                spriteBatch.Draw(
                Main.AssetManager.GetTexture("square"),
                new Rectangle(
                    (int)((step.X - step.Y) * 16f),
                    (int)((step.X + step.Y) * 8f),
                    32, 32),
                Color.PowderBlue * 0.3f);
            }
        }
    }
}