using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class QuadTree
    {
        public QuadTree(Rectangle bounds)
        {
            Capacity = 32;
            Bounds = bounds;
            GameObjects = new List<GameObject>(Capacity);
            Divided = false;
        }
        public QuadTree(Rectangle bounds, int capacity)
        {
            Capacity = capacity;
            Bounds = bounds;
            GameObjects = new List<GameObject>(Capacity);
            Divided = false;
        }

        public int Capacity;
        public bool Divided;
        public Rectangle Bounds;
        public QuadTree[] SubTrees;
        public List<GameObject> GameObjects;

        public void AddRange(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
                Add(gameObject);
        }
        public void Add(GameObject gameObject)
        {
            if (gameObject.Hitbox.Intersects(Bounds))
            {
                if (Divided)
                    SubTrees[FindIndex(gameObject.Position)].Add(gameObject);
                else if (GameObjects.Count >= Capacity)
                {
                    if (Bounds.Height * Bounds.Width > 20)
                    {
                        Subdivide();
                        SubTrees[FindIndex(gameObject.Position)].Add(gameObject);
                    }
                    else GameObjects.Add(gameObject);
                }
                else GameObjects.Add(gameObject);
            }
        }
        public void Remove(GameObject gameObject)
        {
            if (gameObject.Hitbox.Intersects(Bounds))
            {
                if (Divided)
                    SubTrees[FindIndex(gameObject.Position)].Remove(gameObject);
                else if (!GameObjects.Remove(gameObject))
                    Console.WriteLine($"Object: {gameObject} does not exist in quadtree.");
            }
        }
        public void Subdivide()
        {
            // Create four sub trees...
            SubTrees = new QuadTree[4]
            {
                new QuadTree(new Rectangle(Bounds.X,                    Bounds.Y,                     Bounds.Width / 2, Bounds.Height / 2), Capacity), // Top Left (Index 0).                
                new QuadTree(new Rectangle(Bounds.X + Bounds.Width / 2, Bounds.Y,                     Bounds.Width / 2, Bounds.Height / 2), Capacity), // Top Right (Index 1).                
                new QuadTree(new Rectangle(Bounds.X,                    Bounds.Y + Bounds.Height / 2, Bounds.Width / 2, Bounds.Height / 2), Capacity), // Bottom Left (Index 2).                
                new QuadTree(new Rectangle(Bounds.X + Bounds.Width / 2, Bounds.Y + Bounds.Height / 2, Bounds.Width / 2, Bounds.Height / 2), Capacity)  // Bottom Right (Index 3).
            };

            // Move all objects down to leaves...
            for (int i = GameObjects.Count - 1; i >= 0; i--)
            {
                SubTrees[FindIndex(GameObjects[i].Position)].Add(GameObjects[i]);
                GameObjects.Remove(GameObjects[i]);
            }

            Divided = true;
        }
        public List<GameObject> Query(Rectangle bounds)
        {
            List<GameObject> found = new List<GameObject>();

            // Bounds dont overlap quad...
            if (!Bounds.Intersects(bounds))
                return found;

            // The bounds do overlap and the quad has subtrees...
            if (Divided)
                foreach (QuadTree subTree in SubTrees)
                    found.AddRange(subTree.Query(bounds));
            // This quad is a leaf and contains points to add...
            else
            {
                foreach (GameObject gameObject in GameObjects)
                    if (bounds.Intersects(gameObject.Hitbox))
                        found.Add(gameObject);
            }

            return found;
        }
        public bool QueryCollision(GameObject gameObject)
        {
            if (gameObject.Hitbox.Intersects(Bounds))
            {
                if (Divided)
                    SubTrees[FindIndex(gameObject.Position)].QueryCollision(gameObject);
                else return GameObjects.Contains(gameObject);
            }

            return false;
        }
        public int FindIndex(Vector2 searchPos)
        {
            Rectangle northWest = new Rectangle(Bounds.X, Bounds.Y, Bounds.Width / 2, Bounds.Height / 2);
            Rectangle northEast = new Rectangle(Bounds.X + Bounds.Width / 2, Bounds.Y, Bounds.Width / 2, Bounds.Height / 2);
            Rectangle southWest = new Rectangle(Bounds.X, Bounds.Y + Bounds.Height / 2, Bounds.Width / 2, Bounds.Height / 2);

            if (northWest.Contains(searchPos))
                return 0;
            else if (northEast.Contains(searchPos))
                return 1;
            else if (southWest.Contains(searchPos))
                return 2;
            else return 3;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Drawing.DrawRectangle(spriteBatch, Bounds, Color.CornflowerBlue);

            if (SubTrees is not null)
                for (int i = 0; i < 4; i++)
                    SubTrees[i].Draw(spriteBatch);
        }
    }
}