using UnityEngine;

namespace Assets.Scripts.Configs.EntityConfig
{
    [CreateAssetMenu(fileName = "WeaponCFG", menuName = "ScriptableObjects/Cfg/WeaponCFG")]
    internal class WeaponConfig : ScriptableObject
    {
        public bool IsMelee = true;

        [Min(0)]
        public float Damage = 10;

        [Tooltip("In seconds")]
        [Min(0)]
        public float DurationOfAttack = 2f; 
    }
}