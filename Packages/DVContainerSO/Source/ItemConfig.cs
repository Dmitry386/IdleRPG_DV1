using UnityEngine;

namespace Packages.DVContainerSO.Source
{
    [CreateAssetMenu(fileName = "ItemNA", menuName = "ScriptableObjects/Items/ItemNA", order = 1)]
    public class ItemConfig : ScriptableObject
    {
        [Header(nameof(ItemConfig))]
        public string Name;

        public string Type;

        public Sprite Icon;

        [Min(0)]
        public int MaxStackCount = 1; 
    }
}