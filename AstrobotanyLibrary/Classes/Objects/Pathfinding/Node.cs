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

            for (int ny = -1; ny <= 1; ny++)
                for (int nx = -1; nx <= 1; nx++)
                    if ((x + nx >= 0 && x + nx < width) && (y + ny >= 0 && y + ny < height))
                        Neighbours.Add(Position + new Point(nx, ny));

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
        public float fCost { get { return gCost + hCost; } }
        /// <summary>
        /// Distance from starting node.
        /// </summary>
        public float gCost { get; set; }
        /// <summary>
        /// Distance from end node.
        /// </summary>
        public float hCost { get; set; }
    }
}
