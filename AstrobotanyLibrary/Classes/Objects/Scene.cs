using AstrobotanyLibrary.Classes.Objects.Entities;
using AstrobotanyLibrary.Classes.Objects.Pathfinding;
using AstrobotanyLibrary.Classes.Objects.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Scene
    {
        public Scene()
        {
            Width = 8;
            Height = 8;
            Tiles = new Tile[Width, Height];
            Entities = new List<Entity>();
            Background = Main.AssetManager.GetTexture("grid");
            Bounds = new Rectangle((Height - 1) * -16, 0, (Width + Height) * 16, (Width + Height + 2) * 8);
            BackgroundColour = Color.White;

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    if (Main.Random.Next(10) == 0)
                        Tiles[x, y] = new WoodenCrate(x, y);

            Grid = new Grid(Width, Height, Tiles);
        }
          
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int MaxLayerDepth 
        {
            get
            {
                return Width + Height;
            }
        }
        public Tile[,] Tiles { get; private set; }
        public Grid Grid { get; private set; }
        public List<Entity> Entities { get; private set; }
        public Texture2D Background { get; private set; }
        public Rectangle Bounds { get; set; }
        public Color BackgroundColour { get; private set; }

        public void LoadRoom()
        {
            Main.ParticleManager.Particles.Clear();
            Main.EntityManager.Entities.Clear();
            Main.EntityManager.Entities.AddRange(Entities);
        }
        public Point? CartesionToGrid(Vector2 hover)
        {
            int selectX = (int)Math.Floor(hover.X - 0.5f) - 1;
            int selectY = (int)Math.Floor(hover.Y + 0.5f) - 1;

            if (selectX >= 0 && selectX < Width &&
                selectY >= 0 && selectY < Height)
                return new Point(selectX, selectY);

            return null;
        }
        public void Update(float delta)
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    if (Tiles[x, y] is not null && Tiles[x, y].Remove)
                        Tiles[x, y] = null;
                    else Tiles[x, y]?.Update(delta);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Background, Bounds, Background.Bounds,
                Color.White,
                0f, Vector2.Zero, SpriteEffects.None, 0);

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    Tiles[x, y]?.Draw(spriteBatch);
        }
    }
}