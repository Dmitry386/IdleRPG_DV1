using Packages.DVContainerSO.Source;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Systems.EquipmentSystems
{
    internal class EquipSystem : MonoBehaviour
    {
        [SerializeField]
        private ItemContainer _equipedContainer;

        [SerializeField]
        private ItemContainer _defaultContainer;

        [SerializeField]
        private string[] _possibleToEquipTypes = new string[0];

        [SerializeField]
        public event Action<EquipSystem> OnEquipmendChanged;

        public bool TryEquip(Item itemToEquip)
        {
            if (_possibleToEquipTypes.Contains(itemToEquip.ItemConfig.Type))
            {
                if (_defaultContainer.IsHaveItem(itemToEquip)
                    && !_equipedContainer.IsHaveItem(itemToEquip))
                {
                    if (IsHaveEquipedItemOfType(itemToEquip.ItemConfig.Type, out var oldEquipedItem))
                    {
                        _equipedContainer.TryRemoveItem(oldEquipedItem);
                    }

                    _defaultContainer.TryRemoveItem(itemToEquip);
                    _equipedContainer.TryAddItem(itemToEquip);

                    _defaultContainer.TryAddItem(oldEquipedItem);

                    OnEquipmendChanged?.Invoke(this);
                    return true;
                }
            }

            return false;
        }

        internal bool FreeEquip(Item item)
        {
            if (_defaultContainer.TryAddItem(item))
            {
                if( _equipedContainer.TryRemoveItem(item))
                {
                    OnEquipmendChanged?.Invoke(this);
                    return true;
                }
            }
            return false;
        }

        public ItemContainer GetEquipedContainer()
        {
            return _equipedContainer;
        }

        private bool IsHaveEquipedItemOfType(string type, out Item item)
        {
            item = _equipedContainer.GetItems().FirstOrDefault(x => x.ItemConfig.Type == type);
            return item != null;
        }

        private void OnDestroy()
        {
            OnEquipmendChanged = null;
        }
    }
}