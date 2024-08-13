using Assets.Scripts.UI.Inventory.Cells;
using DVUnityUtilities;
using Packages.DVContainerSO.Source;
using UnityEngine;

namespace Assets.Scripts.UI.Inventory
{
    internal class InventoryUI : MonoBehaviour
    {
        [SerializeField]
        private ItemContainer _container;

        [SerializeField]
        private ItemCell[] _cells = new ItemCell[0];

        private void Awake()
        {
            _container.OnChangedItems += OnChangedItems;
        }

        private void OnChangedItems(ItemContainer obj)
        {
            UpdateVisualization();
        }

        private void OnEnable()
        {
            UpdateVisualization();
        }

        private void UpdateVisualization()
        {
            var items = _container.GetItems();

            for (int i = 0; i < _cells.Length; i++)
            {
                if (items.IsHaveElement(i, out var el))
                {
                    _cells[i].SetItem(el);
                }
                else
                {
                    _cells[i].SetItem(null);
                }
            }
        }

        private void OnDestroy()
        {
            _container.OnChangedItems -= OnChangedItems;
        }
    }
}