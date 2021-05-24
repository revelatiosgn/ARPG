using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Inventory;

namespace ARPG.Interactions
{
    public class ItemPickup : Interactable
    {
        [SerializeField] ItemSlot itemSlot;
        
        public override void Interact(GameObject target)
        {
            target.GetComponent<ItemStorage>().AddSlot(itemSlot);
            Destroy(gameObject);
        }

        protected override string GetHintText()
        {
            return itemSlot.Item.title;
        }

        // void Grab(ItemsContainer destination)
        // {
        //     List<ItemSlot> itemSlots = itemsContainer.GetItemSlots();
        //     foreach (ItemSlot itemSlot in itemSlots)
        //     {
        //         destination.AddItem(itemSlot.item, itemSlot.count);
        //     }

        //     Destroy(gameObject);
        // }
    }
}
