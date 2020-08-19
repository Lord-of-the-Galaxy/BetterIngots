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
    /// 
    /// </summary>
    public static class Names
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly string ModFriendlyName = "Better Ingots (Test)";
        /// <summary>
        /// 
        /// </summary>
        public static readonly string FolderRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        /// <summary>
        /// 
        /// </summary>
        public static readonly string AssetsFolder = Path.Combine(FolderRoot, "Assets");
        /// <summary>
        /// 
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
            PatchInternal.PatchIngots();
            Logger.Log(Logger.Level.Info, "All ingots patched!", showOnScreen: true);
        }
    }
}