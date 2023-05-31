using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class AssetManager : GameComponent
    {
        public AssetManager(Game game)
            : base(game)
        {
            AssetPath = @$"../../../Assets/";
            Content = game.Content;
            Device = game.GraphicsDevice;
            Textures = new Dictionary<string, Texture2D>();
            Fonts = new Dictionary<string, SpriteFont>();
        }

        public string AssetPath { get; private set; }
        private ContentManager Content { get; set; }
        private GraphicsDevice Device { get; set; }
        public Dictionary<string, Texture2D> Textures { get; private set; }
        public Dictionary<string, SpriteFont> Fonts { get; private set; }

        public bool LoadTexture(string file)
        {
            try
            {
                FileStream stream = File.OpenRead($@"{AssetPath}/Textures/{file}.png");
                Texture2D texture = Texture2D.FromStream(Device, stream);
                stream.Close();

                Color[] buffer = new Color[texture.Width * texture.Height];
                texture.GetData(buffer);
                for (int i = 0; i < buffer.Length; i++)
                    buffer[i] = Color.FromNonPremultiplied(buffer[i].R, buffer[i].G, buffer[i].B, buffer[i].A);
                texture.SetData(buffer);

                Textures.Add(file, texture);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Loading texture ({file}) failed:\n{e.Message}");
                return false;
            }

            return true;
        }
        public Texture2D GetTexture(string file)
        {
            if (!Textures.ContainsKey(file))
                LoadTexture(file);

            return Textures[file];
        }
    }
}