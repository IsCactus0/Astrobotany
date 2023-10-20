﻿using AstrobotanyLibrary.Classes.Objects.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Linq;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class InterfaceManager : DrawableGameComponent
    {
        public InterfaceManager(Game game)
                    : base(game)
        {
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
            Windows = new List<Window>();
            CursorSize = 8f;
            InterfaceScale = 0.2f;
        }

        public static SpriteBatch SpriteBatch { get; private set; }
        public Effect ActiveEffect { get; set; }
        public List<Window> Windows { get; private set; }
        public ContainerWindow InventoryWindow { get; private set; }
        public int SelectedIndex { get; set; }
        public float CursorSize { get; set; }
        public float InterfaceScale { get; set; }
        public int FPS { get; private set; }
        public float LastFPS { get; private set; }

        public const float FPSFreq = 0.5f;

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            LastFPS += delta;
            if (LastFPS >= FPSFreq)
            {
                FPS = (int)(1f / gameTime.ElapsedGameTime.TotalSeconds);
                LastFPS = 0f;
            }

            Main.Camera.Scale -= delta * Main.InputManager.MouseScrollValue() * 10f;
            Main.Camera.Scale = Math.Clamp(Main.Camera.Scale, 1f, 10f);
            Main.Camera.Update(delta, 8f, Vector2.Zero);

            if (SelectedIndex >= 0 && SelectedIndex < Windows.Count - 1)
            {
                Window window = Windows[SelectedIndex];
                Windows.Remove(window);
                Windows.Add(window);
                SelectedIndex = Windows.Count - 1;
            }

            foreach (Window window in Windows)
                if (window.Visible)
                    window.Update(delta);

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                Main.Camera.SamplerState,
                DepthStencilState.None,
                RasterizerState.CullNone,
                ActiveEffect, null);

            foreach (Window window in Windows)
                if (window.Visible)
                    window.Draw(SpriteBatch);

            SpriteBatch.Draw(
                Main.AssetManager.GetTexture("circle"),
                new Rectangle(
                    Main.InputManager.MouseScreenPositionP() - new Point((int)(CursorSize / 2f)),
                    new Point((int)CursorSize)),
                Color.White);

            SpriteBatch.DrawString(
                Main.AssetManager.GetFont("Montserrat"),
                $"FPS {FPS}",
                new Vector2(48, 24) * InterfaceScale,
                Color.White, 0f, Vector2.Zero,
                InterfaceScale, SpriteEffects.None, 0f);

            SpriteBatch.DrawString(
                Main.AssetManager.GetFont("Montserrat"),
                $"Offset [{Main.Camera.Offset}]",
                new Vector2(48, 128) * InterfaceScale,
                Color.White, 0f, Vector2.Zero,
                InterfaceScale, SpriteEffects.None, 0f);

            SpriteBatch.DrawString(
                Main.AssetManager.GetFont("Montserrat"),
                $"Zoom {Main.Camera.Scale}",
                new Vector2(48, 232) * InterfaceScale,
                Color.White, 0f, Vector2.Zero,
                InterfaceScale, SpriteEffects.None, 0f);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}