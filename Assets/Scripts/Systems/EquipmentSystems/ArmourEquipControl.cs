using Assets.Scripts.Configs.EntityConfig;
using Packages.DVParameters.Source.Mono;
using UnityEngine;

namespace Assets.Scripts.Systems.EquipmentSystems
{
    internal class ArmourEquipControl : MonoBehaviour
    {
        [SerializeField]
        private FloatDataParameters _parameters;

        [SerializeField]
        private EquipSystem _equipment;

        private void Awake()
        {
            _equipment.OnEquipmendChanged += OnEquipmentChanged;
            UpdateArmour();
        }

        private void OnEquipmentChanged(EquipSystem obj)
        {
            UpdateArmour();
        }

        private void UpdateArmour()
        {
            _parameters.DataContainer.SetData("Armour", CalculateArmourValue());
        }

        private float CalculateArmourValue()
        {
            float res = 0;

            var eq = _equipment.GetEquipedContainer().GetItems();
            foreach (var item in eq)
            {
                if (item.ItemConfig is ArmourConfig armour)
                {
                    res += armour.Armour;
                }
            }

            return res;
        }

        private void OnDestroy()
        {
            _equipment.OnEquipmendChanged -= OnEquipmentChanged;
        }
    }
}