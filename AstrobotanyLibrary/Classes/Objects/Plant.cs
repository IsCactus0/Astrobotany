using AstrobotanyLibrary.Classes.Enums;

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
            Width = 1;
            Height = 1;
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
            Width = 1;
            Height = 1;
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
            Width = 1;
            Height = 1;
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
            Width = 1;
            Height = 1;
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
        public float Age { get; protected set; }
        public float MaxAge { get; protected set; }
        public int GrowthStage
        {
            get { return (int)(Age / MaxAge * MaxGrowthStage); }
        }
        public int MaxGrowthStage { get; protected set; }
        public float PreferredLightIntensity { get; protected set; }
        public float PreferredTemperature { get; protected set; }
        public float PreferredHumidity { get; protected set; }
        public float PreferredSaturation { get; protected set; }
        public Dictionary<Substrate, float> SubstratePreferences { get; protected set; }

        public virtual float CalculateGrowthRate(float lightIntensity, float temperature, float humidity, float saturation, Substrate substrate, float soilNutrition)
        {
            float growthRate = lightIntensity - PreferredLightIntensity;

            growthRate += Math.Min(-(temperature * temperature), 0f);

            return growthRate;
        }
        public virtual void Update(float delta, Substrate substrate)
        {
            Age = Math.Min(Age + delta, MaxAge);
        }
    }
}