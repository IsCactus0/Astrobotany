﻿using AstrobotanyLibrary.Classes.Managers;
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
        public static InterfaceManager InterfaceManager { get; private set; }
        public static InputManager InputManager { get; private set; }
        public static PropManager PropManager { get; private set; }
        public static EntityManager EntityManager { get; private set; }
        public static ParticleManager ParticleManager { get; private set; }

        public static GraphicsDeviceManager Graphics { get; private set; }
        public static SpriteBatch SpriteBatch { get; private set; }
        public static RenderTarget2D RenderTarget { get; set; }
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
            AssetManager = new AssetManager(this);
            InterfaceManager = new InterfaceManager(this);
            InputManager = new InputManager(this);
            PropManager = new PropManager(this);
            EntityManager = new EntityManager(this);
            ParticleManager = new ParticleManager(this);

            OpenSimplexNoise = new OpenSimplexNoise();
            Random = new Random();
            Camera = new Camera();

            Components.Add(InterfaceManager);
            Components.Add(InputManager);
            Components.Add(PropManager);
            Components.Add(ParticleManager);

            Settings = new Settings();
            Settings.LoadSettings();
            Settings.LoadControls();

            base.Initialize();
        }
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            BackgroundColour = new Color(46, 39, 48);
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
                null);
            
            SpriteBatch.Draw(
                RenderTarget,
                new Rectangle(0, 0, Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight),
                Color.White);

            SpriteBatch.End();
        }
        public static void Quit(Game game, bool save = true)
        {
            if (save)
            {

            }

            game.Exit();
        }
    }
}