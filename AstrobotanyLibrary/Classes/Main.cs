using AstrobotanyLibrary.Classes.Managers;
using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes
{
    public class Main : Game
    {
        public static Game Self { get; private set; }
        public static Settings Settings { get; set; }
        
        public static AssetManager AssetManager { get; private set; }
        public static InputManager InputManager { get; private set; }
        public static TileManager TileManager { get; private set; }
        public static DecorationManager DecorationManager { get; private set; }
        public static EntityManager EntityManager { get; private set; }
        public static ParticleManager ParticleManager { get; private set; }
        public static InterfaceManager InterfaceManager { get; private set; }

        public static GraphicsDeviceManager Graphics { get; private set; }
        public static SpriteBatch SpriteBatch { get; private set; }
        public static RenderTarget2D RenderTarget { get; set; }
        public static Effect ActiveEffect { get; set; }
        public static OpenSimplexNoise OpenSimplexNoise { get; private set; }
        public static Random Random { get; private set; }        
        public static Camera Camera { get; set; }
        public static Color BackgroundColour { get; set; }
        public static float GameSpeed { get; set; }

        public Main()
        {
            Self = this;
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Graphics.GraphicsProfile = GraphicsProfile.HiDef;
        }
        protected override void Initialize()
        {
            OpenSimplexNoise = new OpenSimplexNoise();
            Random = new Random();
            Camera = new Camera();

            Settings = new Settings();
            Settings.LoadSettings();

            AssetManager = new AssetManager(this);
            InputManager = new InputManager(this);
            TileManager = new TileManager(this);
            DecorationManager = new DecorationManager(this);
            EntityManager = new EntityManager(this);
            ParticleManager = new ParticleManager(this);
            InterfaceManager = new InterfaceManager(this);

            Components.Add(InputManager);
            Components.Add(TileManager);
            Components.Add(DecorationManager);
            Components.Add(EntityManager);
            Components.Add(ParticleManager);
            Components.Add(InterfaceManager);

            Settings.LoadControls();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            BackgroundColour = new Color(60, 70, 80);
            ActiveEffect = null;
            GameSpeed = 1f;
        }
        protected override void UnloadContent()
        {
            AssetManager.UnloadContent();
            base.UnloadContent();
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (InputManager.InputPressed(Enums.Action.MoveUp))
                Camera.Offset -= Vector2.UnitY * delta * 1000f;
            else if (InputManager.InputPressed(Enums.Action.MoveDown))
                Camera.Offset += Vector2.UnitY * delta * 1000f;
            if (InputManager.InputPressed(Enums.Action.MoveLeft))
                Camera.Offset -= Vector2.UnitX * delta * 1000f;
            else if (InputManager.InputPressed(Enums.Action.MoveRight))
                Camera.Offset += Vector2.UnitX * delta * 1000f;
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(RenderTarget);
            GraphicsDevice.Clear(BackgroundColour);

            base.Draw(gameTime);

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                ActiveEffect);
            
            SpriteBatch.Draw(
                RenderTarget,
                new Rectangle(
                    0, 0,
                    Graphics.PreferredBackBufferWidth,
                    Graphics.PreferredBackBufferHeight),
                Color.White);

            SpriteBatch.End();
        }
        
        public static void SaveQuit(object sender, EventArgs e)
        {
            Quit(sender, e);
        }
        public static void Quit(object sender, EventArgs e)
        {
            Self.Exit();
        }
    }
}