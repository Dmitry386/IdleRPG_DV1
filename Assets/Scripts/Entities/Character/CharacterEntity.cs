using Assets.Scripts.Configs.EntityConfig;
using Assets.Scripts.Entities.Items.Weapons;
using DVUnityUtilities.Other.Pools;
using UnityEngine;

namespace Assets.Scripts.Entities.Enemy
{
    internal class CharacterEntity : WCacheAutoRegistrationMonoBehaviour
    {
        [SerializeField]
        public CharacterConfig Config;

        [SerializeField]
        private Transform _weaponParent;

        [SerializeField]
        private WeaponEntity _activeWeapon;

        public void SetWeapon(WeaponEntity weapon)
        {
            _activeWeapon = weapon;
            if (_activeWeapon && _weaponParent)
            {
                _activeWeapon.transform.SetParent(_weaponParent, true);
                _activeWeapon.transform.localPosition = Vector3.zero;
                _activeWeapon.transform.localEulerAngles = Vector3.zero;
            }
        }

        public bool IsHaveWeapon(out WeaponEntity weapon)
        {
            weapon = _activeWeapon;
            return weapon;
        }
    }
}