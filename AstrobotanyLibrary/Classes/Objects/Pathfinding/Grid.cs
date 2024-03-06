using AstrobotanyLibrary.Classes.Objects.Tiles;
using AstrobotanyLibrary.Classes.Utility;
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

        public Queue<Point> CreatePath(Point start, Point end)
        {
            Queue<Point> path = new();
            Point current = end;

            while (current != start)
            {
                path.Enqueue(current);
                current = (Point)Nodes[current.X, current.Y].Parent;
            }

            path = new Queue<Point>(path.Reverse());

            return path;
        }
        public static float Heuristic(Point start, Point end)
        {
            int x = Math.Abs(start.X - end.X);
            int y = Math.Abs(start.Y - end.Y);

            return 10 * (x + y) - 6 * Math.Min(x, y);
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
            {
                Point dir = point - node.Position;
                if (dir.X != 0 && dir.Y != 0)
                    if (Nodes[point.X, node.Position.Y].Solid || Nodes[node.Position.X, point.Y].Solid)
                        continue;

                nodes.Add(Nodes[point.X, point.Y]);
            }
                
            return nodes;
        }
        public Queue<Point> Evaluate(Point start, Point end)
        {
            List<Node> openSet = new();
            List<Node> closedSet = new();

            openSet.Add(Nodes[start.X, start.Y]);
            while (openSet.Count > 0)
            {
                int index = FindLowest(openSet);
                Node current = openSet[index];
                openSet.RemoveAt(index);
                closedSet.Add(current);

                if (current.Position == end)
                    return CreatePath(start, end);

                List<Node> neighbours = GetNeighbouring(current);
                foreach (Node node in neighbours)
                {
                    if (node.Solid || closedSet.Contains(node))
                        continue;

                    float newDistance = current.gCost + Heuristic(current.Position, node.Position);
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

            return new Queue<Point>();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    float gCost = Nodes[x, y].gCost;
                    float fCost = Nodes[x, y].fCost;
                    float hCost = Nodes[x, y].hCost;
                    Vector2 pos = new Vector2((x - y + 1f) * 16f, (x + y + 2.9f) * 8f);
                    if (gCost != 0 || fCost != 0 || hCost != 0)
                    {
                        Drawing.DrawSprite(spriteBatch,
                            Main.AssetManager.GetTexture("Square"),
                            pos - new Vector2(16f, 23.2f),
                            new Vector2(32),
                            Color.MintCream * (2f / hCost), false, 1f);
                    }

                    Drawing.DrawString(spriteBatch,
                        Main.AssetManager.GetFont("Montserrat", Enums.FontWeight.Black),
                        $"F{fCost}",
                        pos - new Vector2(0, 2f),
                        Color.HotPink * 0.5f,
                        Enums.AlignmentVertical.Centre, Enums.AlignmentHorizontal.Centre, 0.025f, 1f);

                    Drawing.DrawString(spriteBatch,
                        Main.AssetManager.GetFont("Montserrat", Enums.FontWeight.Black),
                        $"G{gCost}",
                        pos,
                        Color.DeepSkyBlue * 0.5f,
                        Enums.AlignmentVertical.Centre, Enums.AlignmentHorizontal.Centre, 0.025f, 1f);

                    Drawing.DrawString(spriteBatch,
                        Main.AssetManager.GetFont("Montserrat", Enums.FontWeight.Black),
                        $"H{hCost}",
                        pos + new Vector2(0, 2f),
                        Color.YellowGreen * 0.5f,
                        Enums.AlignmentVertical.Centre, Enums.AlignmentHorizontal.Centre, 0.025f, 1f);
                }
            }
        }
    }
}