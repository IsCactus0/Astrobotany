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
        public static EntityManager EntityManager { get; private set; }
        public static SceneManager SceneManager { get; private set; }
        public static ParticleManager ParticleManager { get; private set; }
        public static InterfaceManager InterfaceManager { get; private set; }

        public static GraphicsDeviceManager Graphics { get; private set; }
        public static SpriteBatch SpriteBatch { get; private set; }
        public static RenderTarget2D RenderTarget { get; set; }
        public static RenderTarget2D LightsRenderTarget { get; set; }
        public static BlendState LightingBlendState { get; set; }
        public static Effect ActiveEffect { get; set; }

        public static OpenSimplexNoise OpenSimplexNoise { get; private set; }
        public static Random Random { get; private set; }        
        public static Camera Camera { get; set; }
        public static float GameSpeed { get; set; }

        public Main()
        {
            Self = this;
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            EntityManager = new EntityManager(this);
            SceneManager = new SceneManager(this);
            ParticleManager = new ParticleManager(this);
            InterfaceManager = new InterfaceManager(this);

            Components.Add(InputManager);
            Components.Add(EntityManager);
            Components.Add(SceneManager);
            Components.Add(ParticleManager);
            Components.Add(InterfaceManager);

            // Settings.LoadControls();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            LightingBlendState = new BlendState()
            {
                AlphaBlendFunction = BlendFunction.ReverseSubtract,
                AlphaSourceBlend = Blend.One,
                AlphaDestinationBlend = Blend.One,
                ColorBlendFunction = BlendFunction.Add,
                ColorDestinationBlend = Blend.InverseSourceColor,
            };
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
            if (Settings.PauseOnLoseFocus && !IsActive)
                return;

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            if (Settings.PauseOnLoseFocus && !IsActive)
                return;

            GraphicsDevice.SetRenderTarget(RenderTarget);
            GraphicsDevice.Clear(SceneManager.Scene.BackgroundColour);
            SpriteBatch.Begin(
                sortMode: SpriteSortMode.FrontToBack,
                blendState: BlendState.AlphaBlend,
                samplerState: SamplerState.PointClamp,
                depthStencilState: DepthStencilState.Default,
                rasterizerState: RasterizerState.CullNone,
                transformMatrix: Camera.Transform);
            SceneManager.Draw(gameTime);
            EntityManager.Draw(gameTime);
            ParticleManager.Draw(gameTime);
            SpriteBatch.End();

            // GraphicsDevice.SetRenderTarget(LightsRenderTarget);
            // GraphicsDevice.Clear(new Color(0, 0, 0, Settings.Brightness * 256));
            // SpriteBatch.Begin(
            //     blendState: LightingBlendState,
            //     transformMatrix: Camera.Transform);
            // Drawing.DrawSprite(SpriteBatch, AssetManager.GetTexture("light"), new Vector2(-64), new Vector2(128), Color.White, false);
            // SpriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin(
                sortMode: SpriteSortMode.Deferred,
                samplerState: SamplerState.PointClamp,
                depthStencilState: DepthStencilState.None,
                rasterizerState: RasterizerState.CullNone,
                effect: ActiveEffect);
            SpriteBatch.Draw(RenderTarget, Settings.WindowSize, SceneManager.Scene.WorldColour());
            // SpriteBatch.Draw(LightsRenderTarget, Settings.WindowSize, Color.Red);
            SpriteBatch.End();

            InterfaceManager.Draw(gameTime);
        }
        public static void SaveQuit()
        {
            Quit();
        }
        public static void Quit()
        {
            Self.Exit();
        }
    }
}