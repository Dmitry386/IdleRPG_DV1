using Assets.Scripts.UI.Inventory.Cells;
using UnityEngine;

namespace Assets.Scripts.UI.EquipUI.Cells
{
    internal class EquipCell : ItemCell
    {
        [SerializeField]
        public string OnlyForType;
    }
}