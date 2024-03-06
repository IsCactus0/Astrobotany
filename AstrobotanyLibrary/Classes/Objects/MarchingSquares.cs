using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class MarchingSquares
    {
        public MarchingSquares()
        {
            Bounds = new Rectangle(0, 0, Main.RenderTarget.Width, Main.RenderTarget.Height);
            Resolution = new Point(Main.RenderTarget.Width / 40, Main.RenderTarget.Height / 40);
            Field = new float[Resolution.X, Resolution.Y];
            for (int y = 0; y < Resolution.Y; y++)
                for (int x = 0; x < Resolution.X; x++)
                    Field[x, y] = 0f;
        }

        public Rectangle Bounds { get; set; }
        public Point Resolution { get; set; }
        public float[,] Field { get; set; }
        public float Elapsed { get; set; }

        public void Update(float delta)
        {
            Elapsed += delta;
            for (int y = 0; y < Resolution.Y; y++)
            {
                for (int x = 0; x < Resolution.X; x++)
                {
                    float loss = delta * 0.4f;
                    Field[x, y] = Math.Clamp(Field[x, y] - loss, 0f, 1f);
                }
            }

            Point mouse = Main.InterfaceManager.Cursor.Position.ToPoint();
            float fx = (float)mouse.X / (Main.RenderTarget.Width / Resolution.X);
            float fy = (float)mouse.Y / (Main.RenderTarget.Height / Resolution.Y);
            mouse.X = (int)Math.Clamp(fx, 0, Resolution.X - 1);
            mouse.Y = (int)Math.Clamp(fy, 0, Resolution.Y - 1);
            float xMouseValue = fx % 1f;
            float yMouseValue = fy % 1f;

            Field[mouse.X, mouse.Y] += (1f - xMouseValue + 1f - yMouseValue) / 2f * delta * 10f;
            Field[mouse.X, mouse.Y] = Math.Clamp(Field[mouse.X, mouse.Y], 0f, 1f);
            if (mouse.X + 1 < Resolution.X)
            {
                Field[mouse.X + 1, mouse.Y] += (xMouseValue + 1f - yMouseValue) / 2f * delta * 10f;
                Field[mouse.X + 1, mouse.Y] = Math.Clamp(Field[mouse.X + 1, mouse.Y], 0f, 1f);
                if (mouse.Y + 1 < Resolution.Y)
                {
                    Field[mouse.X + 1, mouse.Y + 1] += (xMouseValue + yMouseValue) / 2f * delta * 10f;
                    Field[mouse.X + 1, mouse.Y + 1] = Math.Clamp(Field[mouse.X + 1, mouse.Y + 1], 0f, 1f);
                }
            }
            if (mouse.Y + 1 < Resolution.Y)
            {
                Field[mouse.X, mouse.Y + 1] += (1f - xMouseValue + yMouseValue) / 2f * delta * 10f;
                Field[mouse.X, mouse.Y + 1] = Math.Clamp(Field[mouse.X, mouse.Y + 1], 0f, 1f);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < Resolution.Y - 1; y++)
            {
                for (int x = 0; x < Resolution.X - 1; x++)
                {
                    float aVal = Field[x, y];
                    float bVal = Field[x + 1, y];
                    float cVal = Field[x + 1, y + 1];
                    float dVal = Field[x, y + 1];

                    float state = GetState(
                        MathF.Ceiling(aVal),
                        MathF.Ceiling(bVal),
                        MathF.Ceiling(cVal),
                        MathF.Ceiling(dVal));

                    float xStep = Bounds.Width / Resolution.X;
                    float yStep = Bounds.Height / Resolution.Y;
                    float xScaled = x * xStep;
                    float yScaled = y * yStep;

                    Drawing.DrawRectangle(
                        spriteBatch,
                        new Vector2(xScaled + Bounds.Location.X - xStep * 0.5f, yScaled + Bounds.Location.Y - yStep * 0.5f),
                        new Vector2(xStep, yStep),
                        Color.White * aVal);

                    aVal += 1;
                    bVal += 1;
                    cVal += 1;
                    dVal += 1;

                    Vector2 a = new Vector2(
                        MathHelper.Lerp(xScaled, xScaled + xStep, (1 - aVal) / (bVal - aVal)),
                        yScaled)
                        + Bounds.Location.ToVector2();

                    Vector2 b = new Vector2(
                        xScaled + xStep,
                        MathHelper.Lerp(yScaled, yScaled + yStep, (1 - bVal) / (cVal - bVal)))
                        + Bounds.Location.ToVector2();

                    Vector2 c = new Vector2(
                        MathHelper.Lerp(xScaled, xScaled + xStep, (1 - dVal) / (cVal - dVal)),
                        yScaled + yStep)
                        + Bounds.Location.ToVector2();

                    Vector2 d = new Vector2(
                        xScaled,
                        MathHelper.Lerp(yScaled, yScaled + yStep, (1 - aVal) / (dVal - aVal)))
                        + Bounds.Location.ToVector2();

                    switch (state)
                    {
                        case 1:  Drawing.DrawLine(spriteBatch, c, d, 3f, Color.HotPink); break;
                        case 2:  Drawing.DrawLine(spriteBatch, b, c, 3f, Color.HotPink); break;
                        case 3:  Drawing.DrawLine(spriteBatch, b, d, 3f, Color.HotPink); break;
                        case 4:  Drawing.DrawLine(spriteBatch, a, b, 3f, Color.HotPink); break;
                        case 5:  Drawing.DrawLine(spriteBatch, a, d, 3f, Color.HotPink);
                                 Drawing.DrawLine(spriteBatch, b, c, 3f, Color.HotPink); break;
                        case 6:  Drawing.DrawLine(spriteBatch, a, c, 3f, Color.HotPink); break;
                        case 7:  Drawing.DrawLine(spriteBatch, a, d, 3f, Color.HotPink); break;
                        case 8:  Drawing.DrawLine(spriteBatch, a, d, 3f, Color.HotPink); break;
                        case 9:  Drawing.DrawLine(spriteBatch, a, c, 3f, Color.HotPink); break;
                        case 10: Drawing.DrawLine(spriteBatch, a, b, 3f, Color.HotPink);
                                 Drawing.DrawLine(spriteBatch, c, d, 3f, Color.HotPink); break;
                        case 11: Drawing.DrawLine(spriteBatch, a, b, 3f, Color.HotPink); break;
                        case 12: Drawing.DrawLine(spriteBatch, b, d, 3f, Color.HotPink); break;
                        case 13: Drawing.DrawLine(spriteBatch, b, c, 3f, Color.HotPink); break;
                        case 14: Drawing.DrawLine(spriteBatch, c, d, 3f, Color.HotPink); break;
                    }
                }
            }
        }
        public float GetState(float a, float b, float c, float d)
        {
            return a * 8 + b * 4 + c * 2 + d * 1;
        }
    }
}