using AstrobotanyLibrary.Classes.Managers;
using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AstrobotanyLibrary.Classes
{
    public class Main : Game
    {
        public static AssetManager AssetManager { get; private set; }
        public static InterfaceManager InterfaceManager { get; private set; }
        public static InputManager InputManager { get; private set; }

        public static GraphicsDeviceManager Graphics { get; private set; }
        public static SpriteBatch SpriteBatch { get; private set; }
        public static RenderTarget2D RenderTarget { get; private set; }
        public static OpenSimplexNoise OpenSimplexNoise { get; private set; }
        public static Random Random { get; private set; }
        
        public static Camera Camera { get; set; }
        public static Color BackgroundColour { get; set; }
        public static float GameSpeed { get; set; }

        public Main()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            Window.IsBorderless = true;
        }
        protected override void Initialize()
        {
            AssetManager = new AssetManager(this);
            InterfaceManager = new InterfaceManager(this);
            InputManager = new InputManager(this);
            OpenSimplexNoise = new OpenSimplexNoise();
            Random = new Random();

            Graphics.SynchronizeWithVerticalRetrace = false;
            Graphics.HardwareModeSwitch = false;
            Graphics.IsFullScreen = true;

            Components.Add(InterfaceManager);
            Components.Add(InputManager);

            Camera = new Camera();
            SetResolution(1920, 1080, true, false);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            BackgroundColour = new Color(46, 39, 48);
            GameSpeed = 1f;
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(RenderTarget);
            GraphicsDevice.Clear(BackgroundColour);

            base.Draw(gameTime);

            GraphicsDevice.SetRenderTarget(null);
            SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null);

            SpriteBatch.Draw(
                RenderTarget,
                new Rectangle(0, 0, Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight),
                Color.White);

            SpriteBatch.End();
        }
        public void SetResolution(int width, int height, bool fullscreen, bool vsync)
        {
            if (fullscreen)
                SetResolution(width, height, Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width, Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height, fullscreen, vsync);
            else
                SetResolution(width, height, width, height, fullscreen, vsync);
        }
        public void SetResolution(int resolutionWidth, int resolutionHeight, int windowWidth, int windowHeight, bool vsync)
        {
            SetResolution(resolutionWidth, resolutionHeight, windowWidth, windowHeight, false, vsync);
        }
        public void SetResolution(int resolutionWidth, int resolutionHeight, int windowWidth, int windowHeight, bool fullscreen, bool vsync)
        {
            RenderTarget = new RenderTarget2D(GraphicsDevice, resolutionWidth, resolutionHeight);
            GraphicsDevice.Clear(Color.Transparent);

            IsFixedTimeStep = vsync;
            Graphics.SynchronizeWithVerticalRetrace = vsync;
            Graphics.HardwareModeSwitch = false;

            Graphics.PreferredBackBufferWidth = windowWidth;
            Graphics.PreferredBackBufferHeight = windowHeight;
            Graphics.IsFullScreen = fullscreen;
            Graphics.ApplyChanges();

            Camera.Viewport = new Viewport(
                    resolutionWidth / 2,
                    resolutionHeight / 2,
                    resolutionWidth,
                    resolutionHeight);

            Camera.Scale = 1f;
        }
        private void Graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            Graphics.PreferMultiSampling = true;
            e.GraphicsDeviceInformation.PresentationParameters.MultiSampleCount = 8;
        }
        public void Quit(bool save = true)
        {
            if (save)
            {

            }

            Exit();
        }
    }
}