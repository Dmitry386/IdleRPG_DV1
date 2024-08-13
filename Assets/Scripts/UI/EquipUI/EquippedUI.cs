using Assets.Scripts.UI.EquipUI.Cells;
using Packages.DVContainerSO.Source;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UI.EquipUI
{
    internal class EquippedUI : MonoBehaviour
    {
        [SerializeField]
        private ItemContainer _equppedContainer;

        [SerializeField]
        private EquipCell[] _equipCells = new EquipCell[0];

        private void Awake()
        {
            _equppedContainer.OnChangedItems += OnChangeItems;
        }

        private void OnChangeItems(ItemContainer obj)
        {
            UpdateVisualization();
        }

        private void OnEnable()
        {
            UpdateVisualization();
        }

        private void UpdateVisualization()
        {
            var items = _equppedContainer.GetItems();
            Array.ForEach(_equipCells, x => x.SetItem(null));

            foreach (var item in items)
            {
                SetItemToSlot(item);
            }
        }

        private void SetItemToSlot(Item item)
        {
            var slot = _equipCells.FirstOrDefault(x => x.OnlyForType == item.ItemConfig.Type);
            if (!slot)
            {
                Debug.LogError($"No slot for equipment of type {item.ItemConfig.Type}");
            }
            else
            {
                slot.SetItem(item);
            }
        }

        private void OnDestroy()
        {
            _equppedContainer.OnChangedItems -= OnChangeItems;
        }
    }
}