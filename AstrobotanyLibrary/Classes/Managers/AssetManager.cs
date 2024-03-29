﻿using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Managers
{
    public class AssetManager
    {
        public AssetManager(Game game)
        {
            AssetPath = @$"../../../../Assets/";
            Content = game.Content;
            Graphics = game.GraphicsDevice;
            Textures = new Dictionary<string, Texture2D>();
            Effects = new Dictionary<string, Effect>();
            Fonts = new Dictionary<string, FontFamily>();

            LoadContent();
        }

        private ContentManager Content { get; set; }
        private GraphicsDevice Graphics { get; set; }
        public string AssetPath { get; private set; }
        public Texture2D Atlas { get; private set; }
        public Dictionary<string, Texture2D> Textures { get; private set; }
        public Dictionary<string, Effect> Effects { get; private set; }
        public Dictionary<string, FontFamily> Fonts { get; private set; }

        public void LoadContent()
        {
            Textures.Add("empty", Drawing.Square(Graphics, 1, Color.Magenta));
            Textures.Add("simple", Drawing.Square(Graphics, 1, Color.White));
            Textures.Add("circle", Drawing.Circle(Graphics, 32, Color.White));
            Textures.Add("blur", Drawing.Circle(Graphics, 256, Color.White, FadeType.InverseSquare));
            Textures.Add("noise", Drawing.NoiseCircle(Graphics, 32, 0.1f, Color.White, FadeType.Edge));
            Textures.Add("light", Drawing.Circle(Graphics, 128, Color.Black, FadeType.InverseSquare));

            LoadFontFamily("MonomaniacOne");
            LoadFontFamily("Montserrat");
        }
        public void UnloadContent()
        {
            List<string> textures = Textures.Keys.ToList();
            foreach (string texture in textures)
            {
                Textures[texture].Dispose();
                Textures.Remove(texture);
            }
        }
        public bool LoadTexture(string name)
        {
            try
            {
                FileStream stream = File.OpenRead($@"{AssetPath}/Textures/{name}.png");
                Texture2D texture = Texture2D.FromStream(Graphics, stream);
                stream.Close();

                Color[] buffer = new Color[texture.Width * texture.Height];
                texture.GetData(buffer);
                for (int i = 0; i < buffer.Length; i++)
                    buffer[i] = Color.FromNonPremultiplied(buffer[i].R, buffer[i].G, buffer[i].B, buffer[i].A);
                texture.SetData(buffer);

                if (Fonts.ContainsKey(name))
                    Fonts.Remove(name);

                Textures.Add(name, texture);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Loading texture ({name}) failed:\n{exception.Message}");
                return false;
            }

            return true;
        }
        public Texture2D GetTexture(string name)
        {
            if (!Textures.ContainsKey(name))
                LoadTexture(name);

            return Textures[name];
        }
        public bool LoadEffect(string name)
        {
            try
            {
                Effect shader = Content.Load<Effect>($@"Effects/{name}");

                if (Effects.ContainsKey(name))
                    Effects.Remove(name);

                Effects.Add(name, shader);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Loading effect ({name}) failed:\n{exception.Message}");
                return false;
            }

            return true;
        }
        public Effect GetEffect(string name)
        {
            if (!Effects.ContainsKey(name))
                LoadEffect(name);

            return Effects[name];
        }
        public bool LoadFont(string name, FontWeight weight = FontWeight.Regular)
        {
            try
            {
                SpriteFont font = Content.Load<SpriteFont>($@"Fonts/{name}-{weight}");
                if (!Fonts.ContainsKey(name))
                    Fonts.Add(name, new FontFamily());
                Fonts[name].Fonts.Add(weight, font);
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.GetType().Name} while loading font ({name}-{weight}).\n{exception.Message}");
                return false;
            }
        }
        public SpriteFont GetFont(string name, FontWeight weight = FontWeight.Regular)
        {
            if (!Fonts.ContainsKey(name))
                LoadFont(name, weight);
                    
            return Fonts[name].GetFont(weight);
        }
        public bool LoadFontFamily(string name)
        {
            FontFamily fontFamily = new FontFamily();

            foreach (FontWeight weight in Enum.GetValues(typeof(FontWeight)))
            {
                try
                {
                    fontFamily.Fonts.Add(weight, Content.Load<SpriteFont>($@"Fonts/{name}-{weight}"));
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{exception.GetType().Name} while loading font ({name}-{weight}) of ({name} family).\n{exception.Message}");
                    continue;
                }
            }

            if (fontFamily.Fonts.Values.Count > 0)
            {
                if (Fonts.ContainsKey(name))
                    Fonts.Remove(name);
                Fonts.Add(name, fontFamily);
                return true;
            }
            
            return false;
        }
        public FontFamily GetFontFamily(string name)
        {
            if (!Fonts.ContainsKey(name))
                LoadFontFamily(name);

            return Fonts[name];
        }
        public static string FileName(string name)
        {
            return name.ToLower().Replace(' ', '_');
        }
    }
}