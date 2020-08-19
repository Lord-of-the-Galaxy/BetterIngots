using System;
using System.Collections.Generic;
using System.IO;
using SMLHelper.V2.Utility;
using UnityEngine;
using QModManager.Utility;
using Logger = QModManager.Utility.Logger;

namespace BetterIngots
{
    /// <summary>
    /// Assets for the mod
    /// </summary>
    public static class ModAssets
    {
        private static readonly List<TechType> SupportedTypes = new List<TechType> { TechType.Copper, TechType.Gold, TechType.Lead, TechType.Silver, TechType.AluminumOxide, TechType.UraniniteCrystal, TechType.Salt, TechType.Quartz, TechType.CrashPowder, TechType.Sulphur, TechType.Diamond, TechType.Magnetite, TechType.Magnesium, TechType.Kyanite, TechType.Lithium };
        /// <summary>
        /// Dictionary of all materials loaded
        /// </summary>
        public static IDictionary<TechType, Material> Materials { get; internal set; } = new Dictionary<TechType, Material>();

        internal static void LoadMaterials()
        {
            var materialsBundle = AssetBundle.LoadFromFile(Path.Combine(Names.AssetsFolder, "defaultmaterials"));
            foreach (var type in SupportedTypes)
            {
                Logger.Log(Logger.Level.Debug, $"Loading material: {type.AsString()}");
                Materials[type] = materialsBundle.LoadAsset<Material>(type.AsString());
                if (Materials[type] is null)
                {
                    Logger.Log(Logger.Level.Error, $"Material not found: {type.AsString()}");
                }
            }
        }

        /// <summary>
        /// Load and get the sprite for a given name, looking inside the Sprites folder in the Assets folder of the mod
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Atlas.Sprite GetSprite(string name)
        {
            var path = Path.Combine(Names.SpritesFolder, $"{name}.png");

            if (File.Exists(path))
            {
                return ImageUtils.LoadSpriteFromFile(path);
            }

            Logger.Log(Logger.Level.Error, $"Sprite for {name} not found.");
            return SpriteManager.defaultSprite;
        }
    }
}