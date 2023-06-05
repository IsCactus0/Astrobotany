using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework;

namespace AstrobotanyLibrary.Classes.Objects
{
    public class Plant
    {
        public Plant()
        {
            Name = "Unknown";
            Genus = "Unknown";
            Species = "Unknown";
            Description = "";
            Width = 16;
            Height = 16;
            Age = 0f;
            MaxAge = 1f;
            MaxGrowthStage = 1;
            SubstratePreferences = Enum.GetValues(typeof(Substrate))
                .Cast<Substrate>().ToDictionary(x => x, x => 1f);
        }
        public Plant(string name)
        {
            Name = name;
            Genus = "Unknown";
            Species = "Unknown";
            Description = "";
            Width = 16;
            Height = 16;
            Age = 0f;
            MaxAge = 1f;
            MaxGrowthStage = 1;
            SubstratePreferences = Enum.GetValues(typeof(Substrate))
                .Cast<Substrate>().ToDictionary(x => x, x => 1f);
        }
        public Plant(string name, string genus, string species)
        {
            Name = name;
            Genus = genus;
            Species = species;
            Description = "";
            Width = 16;
            Height = 16;
            Age = 0f;
            MaxAge = 1f;
            MaxGrowthStage = 1;
            SubstratePreferences = Enum.GetValues(typeof(Substrate))
                .Cast<Substrate>().ToDictionary(x => x, x => 1f);
        }
        public Plant(string name, string genus, string species, string description)
        {
            Name = name;
            Genus = genus;
            Species = species;
            Description = description;
            Width = 16;
            Height = 16;
            Age = 0f;
            MaxAge = 1f;
            MaxGrowthStage = 1;
            SubstratePreferences = Enum.GetValues(typeof(Substrate))
                .Cast<Substrate>().ToDictionary(x => x, x => 1f);
        }
        public Plant(string name, string genus, string species, string description, int size)
        {
            Name = name;
            Genus = genus;
            Species = species;
            Description = description;
            Width = size;
            Height = size;
            Age = 0f;
            MaxAge = 1f;
            MaxGrowthStage = 1;
            SubstratePreferences = Enum.GetValues(typeof(Substrate))
                .Cast<Substrate>().ToDictionary(x => x, x => 1f);
        }
        public Plant(string name, string genus, string species, string description, int width, int height)
        {
            Name = name;
            Genus = genus;
            Species = species;
            Description = description;
            Width = width;
            Height = height;
            Age = 0f;
            MaxAge = 1f;
            MaxGrowthStage = 1;
            SubstratePreferences = Enum.GetValues(typeof(Substrate))
                .Cast<Substrate>().ToDictionary(x => x, x => 1f);
        }
        public Plant(string name, string genus, string species, string description, int width, int height, int maxAge)
        {
            Name = name;
            Genus = genus;
            Species = species;
            Description = description;
            Width = width;
            Height = height;
            Age = 0f;
            MaxAge = maxAge;
            MaxGrowthStage = 1;
            SubstratePreferences = Enum.GetValues(typeof(Substrate))
                .Cast<Substrate>().ToDictionary(x => x, x => 1f);
        }
        public Plant(string name, string genus, string species, string description, int width, int height, int maxAge, int maxGrowthStage)
        {
            Name = name;
            Genus = genus;
            Species = species;
            Description = description;
            Width = width;
            Height = height;
            Age = 0f;
            MaxAge = maxAge;
            MaxGrowthStage = maxGrowthStage;
            SubstratePreferences = Enum.GetValues(typeof(Substrate))
                .Cast<Substrate>().ToDictionary(x => x, x => 1f);
        }

        public string Name { get; protected set; }
        public string Genus { get; protected set; }
        public string Species { get; protected set; }
        public string Description { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public Rectangle Rectangle
        {
            get { return new Rectangle(0, 0, Width, Height); }
        }
        public float Age { get; protected set; }
        public float MaxAge { get; protected set; }
        public int GrowthStage
        {
            get { return (int)Math.Floor(MathAdditions.Map(Age, 0, MaxAge, 0, GrowthStage)); }
        }
        public int MaxGrowthStage { get; protected set; }
        public float PreferredLightIntensity { get; protected set; }
        public float PreferredTemperature { get; protected set; }
        public float PreferredHumidity { get; protected set; }
        public Dictionary<Substrate, float> SubstratePreferences { get; protected set; }

        public virtual float CalculateGrowthRate(float lightIntensity, float temperature, float humidity, float waterSaturation, Substrate substrate, float soilNutrition)
        {
            float growthRate = lightIntensity - PreferredLightIntensity;

            growthRate += Math.Min(-(float)Math.Pow(temperature, 2), 0f);
            growthRate += Math.Min(-(float)Math.Pow(temperature, 2), 0f);

            return growthRate;
        }
        public virtual void Update(float delta, Substrate substrate)
        {
            float growthRate = 1;
            Age += delta * growthRate;
        }
    }
}