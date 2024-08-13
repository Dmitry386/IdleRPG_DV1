using Assets.Scripts.Entities.Enemy;
using Assets.Scripts.Entities.Items.Weapons;
using Assets.Scripts.Systems.AttackSystems;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Systems.EquipmentSystems
{
    internal class WeaponEquipSystem : MonoBehaviour
    {
        [SerializeField]
        [Min(0)]
        [Tooltip("In seconds")]
        private float _switchWeaponTime = 2;

        [SerializeField]
        private EquipSystem _equipSystem;

        [SerializeField]
        private CharacterEntity _character;

        [SerializeField]
        private IntervalDamager _damager;

        [SerializeField]
        private string _selectedEquipType;

        private void Awake()
        {
            _equipSystem.OnEquipmendChanged += OnEquipmentChanged;
        }

        private void OnEquipmentChanged(EquipSystem obj)
        {
            UpdateCurrentEquipment();
        }

        private void UpdateCurrentEquipment()
        { 
            var equipped = _equipSystem.GetEquipedContainer();

            var equippedSelectedType = equipped.GetItems().FirstOrDefault(x => x.ItemConfig.Type == _selectedEquipType);
            if (equippedSelectedType != null)
            {
                DestroyEquippedWeapon();

                if (equippedSelectedType.ItemConfig is WeaponItem wi)
                {
                    var newWeapon = Instantiate(wi.WeaponPrefab);
                    _character.SetWeapon(newWeapon);
                }
            }
            else
            {
                DestroyEquippedWeapon();
            }
        }  

        private void DestroyEquippedWeapon()
        {
            if (_character.IsHaveWeapon(out var weapon))
            {
                GameObject.Destroy(weapon.gameObject);
            }
            _character.SetWeapon(null);
        }

        public void SetSelectedEquipType(string type = "Melee")
        {
            StopAllCoroutines();
            StartCoroutine(ChangeWeaponProcessing(type)); 
        }

        public IEnumerator ChangeWeaponProcessing(string type)
        {
            if(_damager.GetDamageState() == IntervalDamagerState.Preparing)
            {
                _damager.StopAttackProcessing();
                _damager.SetDamageState(IntervalDamagerState.WeaponChange, _switchWeaponTime);
                yield return new WaitForSeconds(_switchWeaponTime);
                _damager.SetDamageState(IntervalDamagerState.None, 0);
            }
            else if(_damager.GetDamageState()== IntervalDamagerState.Attacking)
            {
                while(_damager.GetDamageState() == IntervalDamagerState.Attacking)
                {
                    yield return null;
                } 
            } 

            _selectedEquipType = type;
            UpdateCurrentEquipment();
        }

        private void OnDestroy()
        {
            _equipSystem.OnEquipmendChanged -= OnEquipmentChanged;
        }
    }
}