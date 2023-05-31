namespace AstrobotanyLibrary.Classes.Objects
{
    public class Plant
    {
        public Plant()
        {
            Name = "Unknown";
            Genus = "Unknown";
            Species = "Unknown";
            GrowthStage = 0;
            MaxGrowthStage = 1;
        }
        public Plant(string name, int maxGrowthStage)
        {
            Name = name;
            Genus = "Unknown";
            Species = "Unknown";
            GrowthStage = 0;
            MaxGrowthStage = maxGrowthStage;
        }
        public Plant(string name, string genus, string species, int maxGrowthStage)
        {
            Name = name;
            Genus = genus;
            Species = species;
            GrowthStage = 0;
            MaxGrowthStage = maxGrowthStage;
        }
        public Plant(string name, string genus, string species, int growthStage, int maxGrowthStage)
        {
            Name = name;
            Genus = genus;
            Species = species;
            GrowthStage = growthStage;
            MaxGrowthStage = maxGrowthStage;
        }

        public string Name { get; set; }
        public string Genus { get; set; }
        public string Species { get; set; }
        public int GrowthStage { get; set; }
        public int MaxGrowthStage { get; set; }
    }
}