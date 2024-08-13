using Assets.Scripts.Systems.EquipmentSystems;
using Assets.Scripts.UI.EquipUI.Cells;
using Assets.Scripts.UI.Inventory.Cells;
using UnityEngine;

namespace Assets.Scripts.UI.EquipUI
{
    internal class EquipActionsUI : MonoBehaviour
    {
        [SerializeField]
        private EquipSystem _equipSystem;

        [SerializeField]
        private EquipCell[] _equippedCells = new EquipCell[0];

        [SerializeField]
        private ItemCell[] _inventoryCells = new ItemCell[0];

        private void Awake()
        {
            foreach (var cell in _equippedCells)
            {
                cell.OnClicked.AddListener(OnEquippedClicked);
            }

            foreach (var cell in _inventoryCells)
            {
                cell.OnClicked.AddListener(OnNotEquippedClicked);
            }
        }

        private void OnNotEquippedClicked(ItemCell itemCell)
        {
            if (itemCell.GetItem() != null)
            {
                _equipSystem.TryEquip(itemCell.GetItem());
            }
        }

        private void OnEquippedClicked(ItemCell itemCell)
        {
            if (itemCell.GetItem() != null)
            {
                _equipSystem.FreeEquip(itemCell.GetItem());
            }
        }
    }
}