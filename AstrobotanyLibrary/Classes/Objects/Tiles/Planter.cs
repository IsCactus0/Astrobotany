using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Objects.Items;
using AstrobotanyLibrary.Classes.Objects.Particles;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Tiles
{
    public class Planter : Tile
    {
        public Planter() : base()
        {
            Name = "Planter";
            Substrate = Substrate.Soil;
            Saturation = 1f;
            Solid = true;
            Plant = new Plant("Sunflower", "Helianthus", "annuus", "A large flowering plant in the daisy family.", 1, 1, 10, 5);
        }
        public Planter(int x, int y) : base(x, y)
        {
            Name = "Planter";
            Substrate = Substrate.Soil;
            Saturation = 1f;
            Solid = true;
            Plant = new Plant("Sunflower", "Helianthus", "annuus", "A large flowering plant in the daisy family.", 1, 1, 10, 5);
        }

        public bool Enclosed { get; set; }
        public float LightIntensity { get; protected set; }
        public float Temperature { get; protected set; }
        public float Humidity { get; protected set; }
        public float Saturation { get; protected set; }
        public Substrate Substrate { get; set; }
        public Plant Plant { get; set; }

        public override void Drop(ItemStack stack)
        {
            if (stack.Item is not SeedItem)
                return;

            stack.DecreaseCount();
            Plant = ((SeedItem)stack.Item).Plant;
        }
        public override void Click(float delta, MouseButton button = MouseButton.Left)
        {
            if (button == MouseButton.Right)
                Saturation = 1f;

            base.Click(delta, button);
        }
        public override void Update(float delta)
        {
            Plant?.Update(delta, Substrate);

            if (!Enclosed)
            {
                float evaporation = GetSaturationRetention(Substrate) * (1f - Humidity) * delta;
                if (Saturation >= delta)
                    Saturation -= evaporation;

                Humidity += evaporation * 0.01f;
                Temperature -= (Temperature - 0.5f) * delta;
            }



            if (Main.Random.NextSingle() < 5f * delta)
            {
                Vector2 position = new Vector2(
                    (Position.X - Position.Y) * 16f,
                    (Position.X + Position.Y) * 8f);
                position += new Vector2(
                    Main.Random.NextSingle() * 5f + 2f,
                    Main.Random.NextSingle() * 2f + 22f);

                Main.ParticleManager.Particles.Add(
                    new Smoke(position.X, position.Y)
                    {
                        Velocity = new Vector2(-10, 0),
                        MaxLifespan = 0.6f + Main.Random.NextSingle() / 5f
                    });
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            Rectangle planter = Sprite;
            planter.Location = new Point((int)(planter.X + Position.X), (int)(planter.Y + Position.Y));
            int xPos = (int)((planter.X - planter.Y) * 16f);
            int yPos = (int)((planter.X + planter.Y) * 8f);

            float layerDepth = Main.SceneManager.Layer.LayerDepth(planter.Location.ToVector2());
            if (Substrate != Substrate.Empty)
            {
                Texture2D texture = Main.AssetManager.GetTexture(Enum.GetName(Substrate));
                spriteBatch.Draw(texture,
                    new Vector2(xPos, yPos), null,
                    Color.Lerp(Color.White, Color.DimGray, Saturation),
                    0f, Vector2.Zero, 1f, SpriteEffects.None, layerDepth + 0.01f);
            }

            if (Plant is not null)
            {
                Rectangle sprite = new(xPos, yPos, Plant.Width * 32, Plant.Height * 32);
                spriteBatch.Draw(Main.AssetManager.GetTexture($"Plants/{Plant.Name}_{Plant.GrowthStage}"),
                    new Rectangle(xPos, yPos - sprite.Height + 12, sprite.Width, sprite.Height), null,
                    Color.White, 
                    0f, Vector2.Zero, SpriteEffects.None, layerDepth + 0.02f);

                Drawing.DrawEllipse(spriteBatch,
                    new Vector2(xPos + 16f, yPos + 10f),
                    8f, Color.Black * 0.8f, new Vector2(1f, 0.5f), layerDepth + 0.015f);
            }

            Drawing.DrawBorderedProgressBar(spriteBatch,
                new Vector2(xPos + 12, yPos - 20),
                new Vector2(xPos + 12, yPos - 28),
                Color.DarkSeaGreen, Color.Beige, 2f, 1f, Humidity, 0.9f);

            Drawing.DrawBorderedProgressBar(spriteBatch,
                new Vector2(xPos + 16, yPos - 20),
                new Vector2(xPos + 16, yPos - 28),
                Color.RoyalBlue, Color.LightSteelBlue, 2f, 1f, Saturation, 0.91f);

            Drawing.DrawBorderedProgressBar(spriteBatch,
                new Vector2(xPos + 20, yPos - 20),
                new Vector2(xPos + 20, yPos - 28),
                Color.HotPink, Color.Pink, 2f, 1f, Temperature, 0.92f);
        }
        public static float GetSaturationRetention(Substrate substrate)
        {
            return substrate switch
            {
                Substrate.Clay => 2.5f,
                Substrate.Peat => 1.8f,
                Substrate.Vermiculite => 1.7f,
                Substrate.Soil => 1.6f,
                Substrate.Perlite => 1.5f,
                Substrate.Mulch => 1.4f,
                Substrate.Sand => 1.3f,
                Substrate.Gravel => 1.1f,
                Substrate.Empty => 0f,
                _ => 1f,
            };
        }
    }
}