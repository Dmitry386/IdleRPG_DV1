using Packages.DVContainerSO.Source;
using UnityEngine;

namespace Assets.Scripts.Entities.Items.Weapons
{
    [CreateAssetMenu(fileName = "WeaponItemNA", menuName = "ScriptableObjects/Items/WeaponItemNA")]
    internal class WeaponItem : ItemConfig
    {
        public WeaponEntity WeaponPrefab;
    }
}