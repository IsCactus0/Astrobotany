using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Utility;
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
            Steps = new Queue<Point>();
        }
        public NavPath(Point start, Point end)
        {
            Start = start;
            End = end;
            Steps = new Queue<Point>();
        }
        public NavPath(Point start, Point end, Grid grid)
        {
            Start = start;
            End = end;
            Steps = grid.Evaluate(start, end);
        }
        public NavPath(NavPath copy)
        {
            Start = new Point();
            End = new Point();
            Steps = new Queue<Point>(copy.Steps);
        }

        public Point Start { get; set; }
        public Point End { get; set; }
        public Queue<Point> Steps { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            Point step, next;
            for (int i = 0; i < Steps.Count - 1; i++)
            {
                step = Steps.ElementAt(i);
                next = Steps.ElementAt(i + 1);

                Drawing.DrawRoundedLine(spriteBatch,
                    new Vector2(
                        (step.X - step.Y + 1f) * 16f,
                        (step.X + step.Y + 2f) * 8f),
                    new Vector2(
                        (next.X - next.Y + 1f) * 16f,
                        (next.X + next.Y + 2f) * 8f),
                    2f, Color.PowderBlue, 1f);
            }
        }
        public static Vector2 DirectionToVector(Direction direction)
        {
            return direction switch
            {
                Direction.North =>     new Vector2(0, -1),
                Direction.NorthEast => new Vector2(1, -1),
                Direction.East =>      new Vector2(1, 0),
                Direction.SouthEast => new Vector2(1, 1),
                Direction.South =>     new Vector2(1, -1),
                Direction.SouthWest => new Vector2(-1, 1),
                Direction.West =>      new Vector2(-1, 0),
                Direction.NorthWest => new Vector2(-1, -1),
                _ => Vector2.Zero
            };
        }
    }
}