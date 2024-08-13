using Packages.DVContainerSO.Source;
using UnityEngine;

namespace Assets.Scripts.Configs.EntityConfig
{
    [CreateAssetMenu(fileName = "ArmourCFG", menuName = "ScriptableObjects/Cfg/ArmourCFG")]
    internal class ArmourConfig : ItemConfig
    { 
        [Range(0, 100)]
        public float Armour = 50;
    }
}