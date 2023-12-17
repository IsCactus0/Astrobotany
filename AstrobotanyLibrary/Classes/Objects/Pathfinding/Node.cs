using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Objects.Pathfinding
{
    public class Node
    {
        public Node(int x, int y, int width, int height, bool solid)
        {
            Position = new Point(x, y);
            Parent = null;
            Neighbours = new List<Point>();

            if (x > 0)
                Neighbours.Add(Position + new Point(-1, 0));
            if (x < width - 1)
                Neighbours.Add(Position + new Point(1, 0));
            if (y > 0)
                Neighbours.Add(Position + new Point(0, -1));
            if (y < height - 1)
                Neighbours.Add(Position + new Point(0, 1));

            Solid = solid;
            gCost = 0;
            hCost = 0;
        }

        public Point Position { get; set; }
        public Point? Parent { get; set; }
        public List<Point> Neighbours { get; private set; }
        public bool Solid { get; set; }
        /// <summary>
        /// The value of the node based on it's distance and heuristic.
        /// With lower values being better than higher values.
        /// </summary>
        public int fCost { get { return gCost + hCost; } }
        /// <summary>
        /// Distance from starting node.
        /// </summary>
        public int gCost { get; set; }
        /// <summary>
        /// Distance from end node.
        /// </summary>
        public int hCost { get; set; }
    }
}
