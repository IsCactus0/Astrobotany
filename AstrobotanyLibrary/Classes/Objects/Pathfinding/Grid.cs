using AstrobotanyLibrary.Classes.Objects.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Pathfinding
{
    public class Grid
    {
        public Grid(int width, int height, Tile[,] tiles)
        {
            Width = width;
            Height = height;
            Nodes = new Node[width, height];

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    Nodes[x, y] = new Node(x, y, width, height, tiles[x, y] is not null && tiles[x, y].Solid);
        }

        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public Node[,] Nodes { get; protected set; }

        public List<Point> CreatePath(Point start, Point end)
        {
            List<Point> path = new();
            Point current = end;

            while (current != start)
            {
                path.Add(current);
                current = (Point)Nodes[current.X, current.Y].Parent;
            }

            path.Reverse();
            return path;
        }
        public static int Heuristic(Point start, Point end)
        {
            int x = Math.Abs(start.X - end.X);
            int y = Math.Abs(start.Y - end.Y);

            if (x > y)
                return 14 * y + 10 * (x - y);
            return 14 * x + 10 * (y - x);
        }
        public static int FindLowest(List<Node> openSet)
        {
            int lowest = 0;
            for (int i = 1; i < openSet.Count; i++)
                if (openSet[i].fCost < openSet[lowest].fCost ||
                    (openSet[i].fCost == openSet[lowest].fCost && openSet[i].hCost < openSet[lowest].hCost))
                    lowest = i;

            return lowest;
        }
        public List<Node> GetNeighbouring(Node node)
        {
            List<Node> nodes = new();
            foreach (Point point in node.Neighbours)
                nodes.Add(Nodes[point.X, point.Y]);

            return nodes;
        }
        public List<Point> Evaluate(Point start, Point end)
        {
            List<Node> openSet = new();
            HashSet<Node> closedSet = new();

            openSet.Add(Nodes[start.X, start.Y]);

            while (openSet.Count > 0)
            {
                int index = FindLowest(openSet);
                Node current = openSet[index];
                openSet.RemoveAt(index);
                closedSet.Add(current);

                if (current.Position == end)
                    return CreatePath(start, end);

                foreach (Node node in GetNeighbouring(current))
                {
                    if (node.Solid || closedSet.Contains(node))
                        continue;

                    int newDistance = current.gCost + Heuristic(current.Position, node.Position);
                    bool inOpenset = openSet.Contains(node);
                    if (newDistance < node.gCost || !inOpenset)
                    {
                        node.gCost = newDistance;
                        node.hCost = Heuristic(node.Position, end);
                        node.Parent = current.Position;

                        if (!inOpenset)
                            openSet.Add(node);
                    }
                }
            }

            return new List<Point>();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    spriteBatch.Draw(
                        Main.AssetManager.GetTexture("square"),
                        new Rectangle(
                            (int)((x - y) * 16f),
                            (int)((x + y) * 8f),
                            32, 32),
                        (Nodes[x, y].Solid ? Color.Red : Color.White) * 0.25f);
        }
    }
}