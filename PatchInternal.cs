using System.Collections.Generic;

namespace BetterIngots
{
    internal static class PatchInternal
    {
        private static readonly List<TechType> IngotBaseTechTypes = new List<TechType> { TechType.Copper, TechType.Gold, TechType.Lead, TechType.Silver, TechType.AluminumOxide, TechType.UraniniteCrystal, TechType.Salt, TechType.Quartz, TechType.CrashPowder, TechType.Sulphur, TechType.Diamond, TechType.Magnetite, TechType.Magnesium, TechType.Kyanite, TechType.Lithium, TechType.Nickel };
        private static readonly List<string> IngotNames = new List<string> { "Copper Ingot", "Gold Ingot", "Lead Ingot", "Silver Ingot", "Ruby Ingot", "Uraninite Ingot", "Packed Salt", "Quartz Ingot", "Packed Cave Sulfur", "Packed Crystalline Sulfur", "Packed Diamonds", "Magnetite Ingot", "Magnesium Ingot", "Kyanite Ingot", "Lithium Ingot", "Nickel Ingot" };

        private static readonly List<string> IngotDesc = new List<string>
        {
            "Pure copper, condensed into an ingot",
            "Pure gold, condensed into an ingot",
            "Pure lead, condensed into an ingot",
            "Pure silver, condensed into an ingot",
            "Ruby crystals formed into an ingot",
            "Uraninite crystals formed into an ingot",
            "Salt packed tightly into an ingot shape",
            "Pure quartz cast into an ingot",
            "Cave sulfur, densely packed into in ingot shape",
            "Crystalline sulfur, formed into an ingot",
            "Diamonds packed into an ingot",
            "Magnetite condensed into an ingot",
            "Pure magnesium, condensed into an ingot",
            "Kyanite crystals formed into an ingot",
            "Pure lithium, condensed into an ingot",
            "Pure nickel, condensed into an ingot"
        };
        internal static void PatchIngots()
        {
            var tempIngots = new List<CompressedObject>(IngotBaseTechTypes.Count);
            for (var i = 0; i < IngotBaseTechTypes.Count; i++)
            {
                tempIngots.Add(new CompressedObject(IngotBaseTechTypes[i], CompactType.Ingot, IngotNames[i], IngotDesc[i]));
                tempIngots[i].Patch();
                tempIngots[i].AddUnpackRecipe();
            }
        }
    }
}