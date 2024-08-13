using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Packages.DVContainerSO.Source
{
    public class ItemContainer : MonoBehaviour
    {
        [SerializeField]
        [Min(0)]
        private int _maxItems = 10;

        [SerializeField]
        private List<Item> _items = new();

        public event Action<ItemContainer> OnChangedItems;

        public List<Item> GetItems()
        {
            return _items.ToList();
        }

        public bool TryAddItem(Item item)
        {
            if (item == null || item.ItemConfig == null) return false;

            // try stack
            if (item.ItemConfig.MaxStackCount > 1)
            {
                if (IsHaveItem(item.GetType(), out var same)
                    && same.Count < same.ItemConfig.MaxStackCount)
                {
                    same.Count++;

                    OnChangedItems?.Invoke(this);
                    return true;
                }
            }

            // no stack add possibility, create new
            if (_items.Contains(item)) return false;
            if (_items.Count >= _maxItems) return false;

            _items.Add(item);

            OnChangedItems?.Invoke(this);
            return true;
        }

        public bool TryRemoveItem(Item item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);

                OnChangedItems?.Invoke(this);
                return true;
            }
            return false;
        }

        public bool TryRemoveItem(Type type, int count)
        {
            if (IsHaveItem(type, out var same)
                && same.Count >= count)
            {
                same.Count--;

                OnChangedItems?.Invoke(this);
                return true;
            }
            return false;
        }

        public bool IsHaveItem(Item item)
        {
            if (_items.Contains(item)) return true;

            return false;
        }

        public bool IsHaveItem(Type type, out Item item)
        {
            item = _items.FirstOrDefault(x => x.ItemConfig.GetType() == type);
            return item != null;
        }
    }
}