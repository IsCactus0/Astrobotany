using AstrobotanyLibrary.Classes.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects.Decorations
{
    public abstract class Planter : Decoration
    {
        protected Planter()
            : base()
        {
            Plants = new Plant[1, 1];
            Width = 1;
            Height = 1;
            Substrate = Substrate.Soil;
            Nutrition = 1f;
            LightIntensity = 100f;
            WaterSaturation = 0.3f;
            AtmosphericHumidity = 0.5f;
        }
        protected Planter(int size)
            : base()
        {
            Plants = new Plant[size, size];
            Width = size;
            Height = size;
            Substrate = Substrate.Soil;
            Nutrition = 1f;
            LightIntensity = 100f;
            WaterSaturation = 0.3f;
            AtmosphericHumidity = 0.5f;
        }
        protected Planter(int width, int height)
            : base()
        {
            Plants = new Plant[width, height];
            Width = width;
            Height = height;
            Substrate = Substrate.Soil;
            Nutrition = 1f;
            LightIntensity = 100f;
            WaterSaturation = 0.3f;
            AtmosphericHumidity = 0.5f;
        }
        protected Planter(int width, int height, Substrate substrate)
            : base()
        {
            Plants = new Plant[width, height];
            Width = width;
            Height = height;
            Substrate = substrate;
            Nutrition = 1f;
            LightIntensity = 100f;
            WaterSaturation = 0.3f;
            AtmosphericHumidity = 0.5f;
        }
        protected Planter(int width, int height, Substrate substrate, float nutrition)
            : base()
        {
            Plants = new Plant[width, height];
            Width = width;
            Height = height;
            Substrate = substrate;
            Nutrition = nutrition;
            LightIntensity = 100f;
            WaterSaturation = 0.3f;
            AtmosphericHumidity = 0.5f;
        }
        protected Planter(int width, int height, Substrate substrate, float nutrition, float lightIntensity)
            : base()
        {
            Plants = new Plant[width, height];
            Width = width;
            Height = height;
            Substrate = substrate;
            Nutrition = nutrition;
            LightIntensity = lightIntensity;
            WaterSaturation = 0.3f;
            AtmosphericHumidity = 0.5f;
        }
        protected Planter(int width, int height, Substrate substrate, float nutrition, float lightIntensity, float waterSaturation)
            : base()
        {
            Plants = new Plant[width, height];
            Width = width;
            Height = height;
            Substrate = substrate;
            Nutrition = nutrition;
            LightIntensity = lightIntensity;
            WaterSaturation = waterSaturation;
            AtmosphericHumidity = 0.5f;
        }
        protected Planter(int width, int height, Substrate substrate, float nutrition, float lightIntensity, float waterSaturation, float atmosphericHumidity)
            : base()
        {
            Plants = new Plant[width, height];
            Width = width;
            Height = height;
            Substrate = substrate;
            Nutrition = nutrition;
            LightIntensity = lightIntensity;
            WaterSaturation = waterSaturation;
            AtmosphericHumidity = atmosphericHumidity;
        }

        public Plant[,] Plants { get; set; }
        public Substrate Substrate { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float Nutrition { get; set; }
        public float LightIntensity { get; set; }
        public float WaterSaturation { get; set; }
        public float AtmosphericHumidity { get; set; }

        public override void Update(float delta)
        {
            foreach (Plant plant in Plants)
                if (plant is not null)
                    plant.Update(delta, Substrate);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Main.AssetManager.GetTexture($"{Name}"),
                new Rectangle(
                    (int)Position.X - Width * 32,
                    (int)Position.Y - Height * 32,
                    Width * 64,
                    Height * 64),
                Color.White);

            for (int x = 0; x < Plants.GetLength(0); x++)
                for (int y = 0; y < Plants.GetLength(1); y++)
                {
                    Plant plant = Plants[x, y];

                    spriteBatch.Draw(
                        Main.AssetManager.GetTexture($"{plant.Name}_{plant.GrowthStage}"),
                        new Rectangle(
                            (int)Position.X - 16,
                            (int)Position.Y - plant.Height * 32 + 8,
                            plant.Width * 32,
                            plant.Height * 32),
                        Color.White);
                }
        }
    }
}