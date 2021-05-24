using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ARPG.Inventory
{
    public class ItemStorage : MonoBehaviour
    {
        [SerializeField] List<ItemSlot> itemSlots;
        public List<ItemSlot> ItemSlots { get => itemSlots; set => itemSlots = value; }

        public UnityAction<IConsumable> onConsume;
        public UnityAction onRemoveSlot;

        void Update()
        {
            for (int i = itemSlots.Count - 1; i >= 0; i--)
            {
                if (itemSlots[i].Count <= 0)
                {
                    RemoveSlot(itemSlots[i]);
                    onRemoveSlot?.Invoke();
                }
            }
        }

        public bool AddSlot(ItemSlot itemSlot)
        {
            ItemSlot targetSlot = GetSlot(itemSlot.Item);
            if (targetSlot != null)
            {
                targetSlot.Count += itemSlot.Count;
            }
            else
            {
                itemSlots.Add(itemSlot);
            }

            return true;
        }

        public bool AddSlots(List<ItemSlot> itemSlots)
        {
            foreach (ItemSlot itemSlot in itemSlots)
                AddSlot(itemSlot);

            return true;
        }

        public ItemSlot GetSlot(Item item)
        {
            return itemSlots.Find(slot => slot.Item == item);
        }

        public bool RemoveSlot(ItemSlot itemSlot)
        {
            return itemSlots.Remove(itemSlot);
        }

        public bool Merge(ItemStorage itemStorage)
        {
            return AddSlots(itemStorage.itemSlots);
        }
    }
}
