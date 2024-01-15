using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Objects;
using AstrobotanyLibrary.Classes.Objects.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;

namespace AstrobotanyLibrary.Classes.Utility
{
    public static class Drawing
    {
        public static Texture2D Noise(GraphicsDevice graphicsDevice, int width, int height)
        {
            Texture2D rectangle = new Texture2D(graphicsDevice, width, height);
            Color[] colors = new Color[width * height];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    colors[y * width + x] = Color.White * (float)Main.OpenSimplexNoise.Evaluate(
                        x / 100f,
                        y / 100f);

                }
            rectangle.SetData(colors);
            return rectangle;
        }
        public static Texture2D Circle(GraphicsDevice graphicsDevice, int radius)
        {
            return Circle(graphicsDevice, radius, Color.White);
        }
        public static Texture2D Circle(GraphicsDevice graphicsDevice, int radius, Color colour)
        {
            return Circle(graphicsDevice, radius, colour, FadeType.Edge);
        }
        public static Texture2D Circle(GraphicsDevice graphicsDevice, int radius, Color colour, FadeType fadeType)
        {
            Texture2D circle = new Texture2D(graphicsDevice, radius * 2 + 1, radius * 2 + 1);
            Color[] colors = new Color[circle.Width * circle.Height];
            Vector2 center = new Vector2(radius);
            Color finalColour;

            for (int y = 0; y < circle.Height; y++)
                for (int x = 0; x < circle.Width; x++)
                {
                    float distance = Vector2.Distance(new Vector2(x, y), center);
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

        public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color colour, float scale = 1f)
        {
            spriteBatch.Draw(
                Main.AssetManager.GetTexture("simple"),
                new Rectangle(rectangle.X, rectangle.Y, (int)(rectangle.Width * scale), (int)(rectangle.Height * scale)),
                null, colour, 0f, Vector2.Zero, SpriteEffects.None,
                0f);
        }
        public static void DrawLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, float thickness, Color colour, float scale = 1f)
        {
            float distance = Vector2.Distance(start, end);
            float angle = MathF.Atan2(end.Y - start.Y, end.X - start.X);
            Vector2 origin = new Vector2(0f, 0.5f);
            Vector2 length = new Vector2(distance, thickness);

            spriteBatch.Draw(
                Main.AssetManager.GetTexture("simple"),
                start, null, colour,
                angle, origin, length * scale,
                SpriteEffects.None, 0);
        }
        public static void DrawPoint(SpriteBatch spriteBatch, Vector2 position, float radius, Color colour, float scale = 1f)
        {
            spriteBatch.Draw(
                Main.AssetManager.GetTexture("circle"),
                new Rectangle(
                    (int)(position.X - radius),
                    (int)(position.Y - radius),
                    (int)(radius * 2),
                    (int)(radius * 2)),
                null, 
                colour);
        }
        public static void DrawRoundedLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, float thickness, Color colour, float scale = 1f)
        {
            Vector2 offset = new Vector2(thickness / 2f, 0f);
            start += offset;
            end -= offset;
            DrawLine(spriteBatch, start, end, thickness, colour, scale);
            DrawPoint(spriteBatch, start, thickness / 2f, colour, scale);
            DrawPoint(spriteBatch, end, thickness / 2f, colour, scale);
        }
        public static void DrawString(SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Color colour, Alignment alignment, float scale = 1f)
        {
            Vector2 origin;
            Vector2 size = font.MeasureString(text) * scale;

            switch (alignment)
            {
                case Alignment.Top:
                    origin = new Vector2(size.X / 2f, 0f);
                    break;
                case Alignment.TopLeft:
                    origin = new Vector2(0f, 0f);
                    break;
                case Alignment.TopRight:
                    origin = new Vector2(size.X, 0f);
                    break;
                case Alignment.Bottom:
                    origin = new Vector2(size.X / 2f, size.Y);
                    break;
                case Alignment.BottomLeft:
                    origin = new Vector2(0f, size.Y);
                    break;
                case Alignment.BottomRight:
                    origin = new Vector2(size.X, size.Y);
                    break;
                case Alignment.Left:
                    origin = new Vector2(0f, size.Y / 2f);
                    break;
                case Alignment.Right:
                    origin = new Vector2(size.X, size.Y / 2f);
                    break;
                default:
                    origin = new Vector2(size.X / 2f, size.Y / 2f);
                    break;
            }

            origin *= scale;

            spriteBatch.DrawString(font, text, position - origin, colour, 0f, origin, scale, SpriteEffects.None, 0f);
        }
    }
}