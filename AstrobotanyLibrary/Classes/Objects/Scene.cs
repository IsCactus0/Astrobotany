using AstrobotanyLibrary.Classes.Objects.Entities;
using AstrobotanyLibrary.Classes.Objects.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Scene
    {
        public Scene()
        {
            Width = 8;
            Height = 8;
            LayerCount = 1;
            Tiles = new Tile[Width, Height, LayerCount];
            Entities = new List<Entity>();
            Background = Main.AssetManager.GetTexture("grid");
            BackgroundColour = Color.White;

            for (int z = 0; z < LayerCount; z++)
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                        Tiles[x, y, z] = new Tile(x, y);

            Debug.WriteLine("Width: " + Background.Width);
            Debug.WriteLine("Height: " + Background.Height);
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int LayerCount { get; private set; }
        public Tile[,,] Tiles { get; private set; }
        public List<Entity> Entities { get; private set; }
        public Texture2D Background { get; private set; }
        public Color BackgroundColour { get; private set; }
        public Point Offset { get; set; }

        public void LoadRoom()
        {
            Main.ParticleManager.Particles.Clear();
            Main.EntityManager.Entities.Clear();

            Main.EntityManager.Entities.AddRange(Entities);
        }
        public Vector3 SelectProp(Vector2 hover)
        {
            int selectX = (int)Math.Floor(hover.X - 0.5f);
            int selectY = (int)Math.Floor(hover.Y + 0.5f);

            for (int z = 0; z < LayerCount; z++)
                if (selectX + z >= 0 && selectX + z < Width &&
                    selectY + z >= 0 && selectY + z < Height)
                    return new Vector3(selectX + z, selectY + z, z);

            return Vector3.Down;
        }
        public void Update(float delta)
        {
            for (int z = 0; z < LayerCount; z++)
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                        Tiles[x, y, z]?.Update(delta);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background,
                new Rectangle(
                    (Height - 1) * -16, 0,
                    (Width + Height) * 16,
                    (Width + Height + 2) * 8),
                Color.White);

            for (int z = 0; z < LayerCount; z++)
                for (int y = 0; y < Height; y++)
                    for (int x = 0; x < Width; x++)
                        Tiles[x, y, z]?.Draw(spriteBatch);
        }
    }
}