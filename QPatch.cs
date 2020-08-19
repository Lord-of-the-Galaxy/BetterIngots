using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using QModManager.API.ModLoading;
using QModManager.Utility;

namespace BetterIngots
{
    /// <summary>
    /// For future use, when objects like water might be compacted (which won't be ingots)
    /// </summary>
    public enum CompactType
    {
        /// <summary>
        /// An ingot, borrowing the prefab from the titanium ingot (but with a different material)
        /// </summary>
        Ingot, // more types later
    }
    /// <summary>
    /// List of constant names and folder locations
    /// </summary>
    public static class Names
    {
        /// <summary>
        /// Friendly (display) name for the mod
        /// </summary>
        public static readonly string ModFriendlyName = "Better Ingots (Test)";
        /// <summary>
        /// ID for the base fabricator tab
        /// </summary>
        public static readonly string FabricatorCategoryId = "BetterIngots";
        /// <summary>
        /// Friendly (display) name for the base tab
        /// </summary>
        public static readonly string FabricatorCategoryName = "Better Ingots";
        /// <summary>
        /// The folder that contains the mod assembly (dll)
        /// </summary>
        public static readonly string FolderRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        /// <summary>
        /// Assets folder of the mod
        /// </summary>
        public static readonly string AssetsFolder = Path.Combine(FolderRoot, "Assets");
        /// <summary>
        /// Folder containing the sprites (located in the assets folder)
        /// </summary>
        public static readonly string SpritesFolder = Path.Combine(AssetsFolder, "Sprites");
    }

    /// <summary>
    /// Core patching class that contains the <see cref="Patch"/> method called by <see cref="QModManager"/>.
    /// <para><seealso cref="QModCoreAttribute"/></para>
    /// </summary>
    [QModCore]
    public static class QPatch
    {
        /// <summary>
        /// Core patching method called by <see cref="QModManager"/>.
        /// <para>All the patching of game code is handled here by calling various <see cref="SMLHelper"/> methods.</para>
        /// <see cref="QModPatch"/>
        /// </summary>
        [QModPatch]
        public static void Patch()
        {
            ModAssets.LoadMaterials();
            Logger.Log(Logger.Level.Debug, "Assets loaded.");
            PatchInternal.PatchFabricatorTabs();
            Logger.Log(Logger.Level.Debug, "Fabricator tabs added!");
            PatchInternal.PatchIngots();
            Logger.Log(Logger.Level.Debug, "All ingots patched!");
            Logger.Log(Logger.Level.Info, $"{Names.ModFriendlyName} patched!", showOnScreen: true);
        }
    }
}