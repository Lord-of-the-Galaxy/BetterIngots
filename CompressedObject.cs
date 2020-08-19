using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using UnityEngine;
using QModManager.Utility;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using Logger = QModManager.Utility.Logger;

namespace BetterIngots
{
    /// <summary>
    /// Base class for al compressed types (like ingots) added by the mod
    /// </summary>
    public class CompressedObject : Craftable
    {
        private readonly CompactType _type;
        private readonly TechType _baseType;
        private readonly TechType _ingredientType;

        /// <inheritdoc />
        public override CraftTree.Type FabricatorType { get; } = CraftTree.Type.Fabricator;

        /// <inheritdoc />
        public override string[] StepsToFabricatorTab
        {
            get { return new[]{ Names.FabricatorCategoryId, $"Pack{_type}" }; }
        } // a bit inefficient but ok

        /// <summary>
        /// [TODO]
        /// </summary>
        /// <param name="baseType"></param>
        /// <param name="type"></param>
        /// <param name="friendlyName"></param>
        /// <param name="description"></param>
        /// <param name="ingredientType"></param>
        public CompressedObject(TechType baseType, CompactType type, string friendlyName, string description, TechType ingredientType = TechType.None) :
            base($"{baseType.AsString()}{type}", friendlyName, description)
        {
            _type = type;
            _baseType = baseType;

            _ingredientType = ingredientType != TechType.None ? ingredientType : baseType;
        }

        /// <inheritdoc />
        public override GameObject GetGameObject()
        {
            switch (_type)
            {
                case CompactType.Ingot:
                    // ReSharper disable once AccessToStaticMemberViaDerivedType
                    var prefab = GameObject.Instantiate(CraftData.GetPrefabForTechType(TechType.TitaniumIngot));
                    Logger.Log(Logger.Level.Debug, $"Game Object instantiated for custom ingot ({ClassID})");
                    //try to use a custom material
                    if (ModAssets.Materials.TryGetValue(_baseType, out var mat))
                    {
                        //material exists
                        var renderer = prefab.GetComponentInChildren<Renderer>();
                        renderer.material = mat;
                    }

                    return prefab;
                default:
                    throw new NotImplementedException($"Compact type {_type.ToString()} does not exist yet.");
            }
        }

        /// <inheritdoc />
        protected override TechData GetBlueprintRecipe()
        {
            return new TechData(new Ingredient(_ingredientType, 10)) { craftAmount = 1 };
        }

        /// <inheritdoc />
        protected override Atlas.Sprite GetItemSprite()
        {
            return ModAssets.GetSprite(ClassID);
        }

        /// <summary>
        /// Add recipe for unpacking the compressed type into constituents
        /// </summary>
        protected internal void AddUnpackRecipe()
        {
            var tempType = TechTypeHandler.AddTechType($"Unpack{ClassID}", $"Unpack {FriendlyName}", $"Unpack {FriendlyName} back into {_ingredientType.AsString()}", SpriteManager.Get(_ingredientType));
            var unpackData = new TechData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient> { new Ingredient(this.TechType, 1) },
                LinkedItems = new List<TechType>(Enumerable.Repeat(_ingredientType, 10))
            };
            CraftDataHandler.SetTechData(tempType, unpackData);
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, tempType, Names.FabricatorCategoryId, $"Unpack{_type}");
        }

    }
}
