using Packages.DVContainerSO.Source;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Inventory.Cells
{
    internal class ItemCell : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        protected Image _icon;

        [SerializeField]
        protected TMP_Text _count;

        [SerializeField]
        public UnityEvent<ItemCell> OnClicked;

        private Item _item;

        public void SetItem(Item item)
        {
            _item = item;
            if (item != null)
            {
                if (_count)
                {
                    if (_item.Count > 1) _count.text = item.Count.ToString();
                    else _count.text = string.Empty;
                }
                if (_icon)
                {
                    if (item.ItemConfig != null) _icon.sprite = item.ItemConfig.Icon;
                    _icon.enabled = true;
                }
            }
            else
            {
                if (_count)
                {
                    _count.text = string.Empty;
                }
                if (_icon)
                {
                    _icon.sprite = null;
                    _icon.enabled = false;
                }
            }
        }

        public Item GetItem()
        {
            return _item;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke(this);
        }
    }
}