using AstrobotanyLibrary.Classes.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Planter : Prop
    {
        public Planter()
            : base()
        {
            Plant = null;
            Substrate = Substrate.Soil;
            Nutrition = 1f;
            LightIntensity = 100f;
            WaterSaturation = 0.3f;
            AtmosphericHumidity = 0.5f;
        }
        public Planter(Plant plant)
            : base()
        {
            Plant = plant;
            Substrate = Substrate.Soil;
            Nutrition = 1f;
            LightIntensity = 100f;
            WaterSaturation = 0.3f;
            AtmosphericHumidity = 0.5f;
        }
        public Planter(Plant plant, Substrate substrate)
            : base()
        {
            Plant = plant;
            Substrate = substrate;
            Nutrition = 1f;
            LightIntensity = 100f;
            WaterSaturation = 0.3f;
            AtmosphericHumidity = 0.5f;
        }
        public Planter(Plant plant, Substrate substrate, float nutrition)
            : base()
        {
            Plant = plant;
            Substrate = substrate;
            Nutrition = nutrition;
            LightIntensity = 100f;
            WaterSaturation = 0.3f;
            AtmosphericHumidity = 0.5f;
        }
        public Planter(Plant plant, Substrate substrate, float nutrition, float lightIntensity)
            : base()
        {
            Plant = plant;
            Substrate = substrate;
            Nutrition = nutrition;
            LightIntensity = lightIntensity;
            WaterSaturation = 0.3f;
            AtmosphericHumidity = 0.5f;
        }
        public Planter(Plant plant, Substrate substrate, float nutrition, float lightIntensity, float waterSaturation)
            : base()
        {
            Plant = plant;
            Substrate = substrate;
            Nutrition = nutrition;
            LightIntensity = lightIntensity;
            WaterSaturation = waterSaturation;
            AtmosphericHumidity = 0.5f;
        }
        public Planter(Plant plant, Substrate substrate, float nutrition, float lightIntensity, float waterSaturation, float atmosphericHumidity)
            : base()
        {
            Plant = plant;
            Substrate = substrate;
            Nutrition = nutrition;
            LightIntensity = lightIntensity;
            WaterSaturation = waterSaturation;
            AtmosphericHumidity = atmosphericHumidity;
        }

        public Plant Plant { get; set; }
        public Substrate Substrate { get; set; }
        public float Nutrition { get; set; }
        public float LightIntensity { get; set; }
        public float WaterSaturation { get; set; }
        public float AtmosphericHumidity { get; set; }

        public override void Update(float delta)
        {
            if (Plant is not null)
                Plant.Update(delta, Substrate);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Plant is not null)
                spriteBatch.Draw(
                    Main.AssetManager.GetTexture($"{Plant.Name}_{Plant.GrowthStage}"),
                    new Rectangle((int)Position.X, (int)Position.Y, Plant.Width, Plant.Height),
                    Color.White);
        }
    }
}