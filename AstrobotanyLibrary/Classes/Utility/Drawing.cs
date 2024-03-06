using AstrobotanyLibrary.Classes.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Utility
{
    public static class Drawing
    {
        public static Texture2D Noise(GraphicsDevice graphicsDevice, int size)
        {
            return Noise(graphicsDevice, size, size, 1f, Color.White);
        }
        public static Texture2D Noise(GraphicsDevice graphicsDevice, int width, int height, float scale)
        {
            return Noise(graphicsDevice, width, height, scale, Color.White);
        }
        public static Texture2D Noise(GraphicsDevice graphicsDevice, int width, int height, float scale, Color colour)
        {
            Texture2D rectangle = new Texture2D(graphicsDevice, width, height);
            Color[] colors = new Color[width * height];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    colors[y * width + x] = colour * (float)Main.OpenSimplexNoise.Evaluate(
                        x * scale,
                        y * scale);

                }
            rectangle.SetData(colors);
            return rectangle;
        }
        public static Texture2D NoiseCircle(GraphicsDevice graphicsDevice, int radius, float scale, Color colour, FadeType fadeType = FadeType.Edge)
        {
            Texture2D circle = new Texture2D(graphicsDevice, radius * 2 + 1, radius * 2 + 1);
            Color[] colors = new Color[circle.Width * circle.Height];
            Vector2 centre = new Vector2(radius);
            Color finalColour;

            for (int y = 0; y < circle.Height; y++)
                for (int x = 0; x < circle.Width; x++)
                {
                    float distance = Vector2.Distance(new Vector2(x, y), centre);
                    if (distance <= radius)
                    {
                        finalColour = colour * (float)Main.OpenSimplexNoise.Evaluate(x * scale, y * scale);
                        switch (fadeType)
                        {
                            case FadeType.Edge:
                                finalColour *= (radius - distance);
                                break;
                            case FadeType.Linear:
                                finalColour *= 1f - (distance / radius);
                                break;
                            case FadeType.InverseSquare:
                                finalColour *= 1f - ((distance / radius) * (distance / radius));
                                break;
                        }
                        colors[y * circle.Width + x] = finalColour;
                    }
                }

            circle.SetData(colors);
            return circle;
        }
        public static Texture2D Circle(GraphicsDevice graphicsDevice, int radius)
        {
            return Circle(graphicsDevice, radius, Color.White);
        }
        public static Texture2D Circle(GraphicsDevice graphicsDevice, int radius, Color colour)
        {
            return Circle(graphicsDevice, radius, colour, FadeType.None);
        }
        public static Texture2D Circle(GraphicsDevice graphicsDevice, int radius, Color colour, FadeType fadeType)
        {
            Texture2D circle = new Texture2D(graphicsDevice, radius * 2 + 1, radius * 2 + 1);
            Color[] colors = new Color[circle.Width * circle.Height];
            Vector2 centre = new Vector2(radius);
            Color finalColour;

            for (int y = 0; y < circle.Height; y++)
                for (int x = 0; x < circle.Width; x++)
                {
                    float distance = Vector2.Distance(new Vector2(x, y), centre);
                    if (distance <= radius)
                    {
                        finalColour = colour;
                        switch (fadeType)
                        {
                            case FadeType.Edge:
                                finalColour *= (radius - distance);
                                break;
                            case FadeType.Linear:
                                finalColour *= 1f - (distance / radius);
                                break;
                            case FadeType.InverseSquare:
                                finalColour *= 1f - ((distance / radius) * (distance / radius));
                                break;
                        }

                        colors[y * circle.Width + x] = finalColour;
                    }
                }

            circle.SetData(colors);
            return circle;
        }
        public static Texture2D Ellipse(GraphicsDevice graphicsDevice, int width, int height)
        {
            return Ellipse(graphicsDevice, width, height, Color.White);
        }
        public static Texture2D Ellipse(GraphicsDevice graphicsDevice, int width, int height, Color colour)
        {
            Texture2D ellipse = new Texture2D(graphicsDevice, width, height);
            Color[] colors = new Color[width * height];

            Vector2 center = new Vector2(width / 2f, height / 2f);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    if (Math.Abs(x - center.X) <= width && Math.Abs(y - center.Y) <= height)
                        colors[y * width + x] = colour;
                }

            ellipse.SetData(colors);
            return ellipse;
        }
        public static Texture2D Square(GraphicsDevice graphicsDevice, int size)
        {
            return Rectangle(graphicsDevice, size, size, Color.White);
        }
        public static Texture2D Square(GraphicsDevice graphicsDevice, int size, Color colour)
        {
            return Rectangle(graphicsDevice, size, size, colour);
        }
        public static Texture2D Rectangle(GraphicsDevice graphicsDevice, int width, int height)
        {
            return Rectangle(graphicsDevice, width, height, Color.White);
        }
        public static Texture2D Rectangle(GraphicsDevice graphicsDevice, int width, int height, Color colour)
        {
            Texture2D rectangle = new Texture2D(graphicsDevice, width, height);
            Color[] colors = new Color[width * height];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    colors[y * width + x] = colour;
            rectangle.SetData(colors);
            return rectangle;
        }

        public static void DrawSprite(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Vector2 size, Color colour, bool flipped = false, float layerDepth = 0f) {
            spriteBatch.Draw(
                texture,
                position, null, colour,
                0f, Vector2.Zero,
                new Vector2(size.X / texture.Width, size.Y / texture.Height),
                flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                layerDepth);
        }
        public static void DrawSprite(SpriteBatch spriteBatch, Texture2D texture, Rectangle rectangle, Color colour, bool flipped = false, float layerDepth = 0f)
        {
            spriteBatch.Draw(
                texture,
                rectangle,
                null,
                colour,
                0f, Vector2.Zero,
                flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                layerDepth);
        }
        public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color colour, float layerDepth = 0f)
        {
            spriteBatch.Draw(
                Main.AssetManager.GetTexture("simple"),
                rectangle, null, colour,
                0f, Vector2.Zero,
                SpriteEffects.None, layerDepth);
        }
        public static void DrawRectangle(SpriteBatch spriteBatch, Vector2 position, Vector2 size, Color colour, float layerDepth = 0f)
        {
            spriteBatch.Draw(
                Main.AssetManager.GetTexture("simple"),
                position, null, colour,
                0f, Vector2.Zero, size,
                SpriteEffects.None, layerDepth);
        }
        public static void DrawLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, float thickness, Color colour, float layerDepth = 0f)
        {
            float distance = Vector2.Distance(start, end);
            float angle = MathF.Atan2(end.Y - start.Y, end.X - start.X);
            Vector2 origin = new(0f, 0.5f);
            Vector2 length = new(distance, thickness);

            spriteBatch.Draw(
                Main.AssetManager.GetTexture("simple"),
                new Vector2(start.X, start.Y),
                null, colour,
                angle, origin, length,
                SpriteEffects.None, layerDepth);
        }
        public static void DrawPoint(SpriteBatch spriteBatch, Vector2 position, float radius, Color colour, float layerDepth = 0f)
        {
            Texture2D sprite = Main.AssetManager.GetTexture("circle");
            spriteBatch.Draw(
                sprite,
                new Vector2(position.X - radius, position.Y - radius),
                null, 
                colour,
                0f,
                Vector2.Zero,
                radius * 2f / sprite.Width,
                SpriteEffects.None, layerDepth);
        }
        public static void DrawEllipse(SpriteBatch spriteBatch, Vector2 position, float radius, Color colour, Vector2 scale, float rotation = 0f, float layerDepth = 0f)
        {
            Texture2D sprite = Main.AssetManager.GetTexture("circle");
            spriteBatch.Draw(
                sprite,
                new Vector2(position.X - radius * scale.X, position.Y - radius * scale.Y),
                null,
                colour,
                rotation,
                Vector2.Zero,
                new Vector2(radius * 2 * scale.X / sprite.Width, radius * 2 * scale.Y / sprite.Height),
                SpriteEffects.None,
                layerDepth);
        }
        public static void DrawSmoke(SpriteBatch spriteBatch, Vector2 position, float radius, Color colour, Vector2 scale, float rotation = 0f, float layerDepth = 0f)
        {
            Texture2D sprite = Main.AssetManager.GetTexture("noise");
            spriteBatch.Draw(
                sprite,
                new Vector2(position.X - radius * scale.X, position.Y - radius * scale.Y),
                null,
                colour,
                rotation,
                Vector2.Zero,
                new Vector2(radius * 2 * scale.X / sprite.Width, radius * 2 * scale.Y / sprite.Height),
                SpriteEffects.None,
                layerDepth);
        }
        public static void DrawRoundedLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, float thickness, Color colour, float layerDepth = 0f)
        {
            DrawLine(spriteBatch, start, end, thickness, colour, layerDepth);
            DrawPoint(spriteBatch, start, thickness / 2f, colour, layerDepth);
            DrawPoint(spriteBatch, end, thickness / 2f, colour, layerDepth);
        }
        public static void DrawPolygon(SpriteBatch spriteBatch, List<Vector2> vertices, float thickness, Color colour)
        {
            DrawLine(spriteBatch, vertices[vertices.Count - 1], vertices[0], thickness, colour);
            for (int i = 1; i < vertices.Count - 1; i++)
            {
                DrawLine(spriteBatch, vertices[i], vertices[i + 1], thickness, colour);
            }
        }
        public static void DrawRoundedPolygon(SpriteBatch spriteBatch, List<Vector2> vertices, float thickness, Color colour)
        {
            DrawPolygon(spriteBatch, vertices, thickness, colour);
            foreach (Vector2 vertice in vertices)
                DrawPoint(spriteBatch, vertice, thickness / 2f, colour);
        }
        public static void DrawString(SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Color colour, AlignmentVertical vertical, AlignmentHorizontal horizontal, float scale = 1f, float layerDepth = 0f)
        {
            Vector2 origin = Vector2.Zero;
            Vector2 size = font.MeasureString(text);
            switch (vertical)
            {
                case AlignmentVertical.Centre:
                    origin += new Vector2(0f, size.Y * 0.5f);
                    break;
                case AlignmentVertical.Bottom:
                    origin += new Vector2(0f, size.Y);
                    break;
            }

            switch (horizontal)
            {
                case AlignmentHorizontal.Centre:
                    origin += new Vector2(size.X * 0.5f, 0f);
                    break;
                case AlignmentHorizontal.Right:
                    origin += new Vector2(size.X, 0f);
                    break;
            }

            origin /= scale;
            spriteBatch.DrawString(font, text, position + size * scale * 0.5f, colour, 0f, origin, scale, SpriteEffects.None, layerDepth);
        }
        
        public static void DrawProgressBar(SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color colour, float thickness = 3f, float value = 0f, float layerDepth = 0f)
        {
            Vector2 direction = end - start;
            DrawRoundedLine(spriteBatch, start, start + direction * value, thickness, colour, layerDepth);
        }
        public static void DrawBorderedProgressBar(SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color colour, Color borderColour, float thickness = 3f, float offset = 0f, float value = 0f, float layerDepth = 0f)
        {
            if (offset > 0 && value < 1)
                DrawRoundedLine(spriteBatch, start, end, thickness + offset, borderColour, layerDepth);
            DrawProgressBar(spriteBatch, start, end, colour, thickness, value, layerDepth + 0.001f);
        }
    }
}