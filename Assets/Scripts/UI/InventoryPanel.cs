using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ARPG.Inventory;
using ARPG.Gear;
using ARPG.Events;

namespace ARPG.UI
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] VoidEvent onPlayerUIInventory;
        [SerializeField] VoidEvent onPlayerUIUseItem;
        [SerializeField] VoidEvent onPlayerUIDropItem;

        [SerializeField] GridLayoutGroup grid;
        [SerializeField] Text UseHint;
        [SerializeField] Text DropHint;

        ItemStorage itemStorage;
        Equipment equipment;
        InventorySlot selectedSlot;

        void Awake()
        {
            GameObject player = GameObject.FindGameObjectWithTag(Constants.Tags.Player);
            itemStorage = player.GetComponent<ItemStorage>();
            equipment = player.GetComponent<Equipment>();
        }

        void Start()
        {
            UpdateSlots();
        }

        void OnEnable()
        {
            UseHint.gameObject.SetActive(false);
            DropHint.gameObject.SetActive(false);

            equipment.onEquip += OnEquip;
            equipment.onUnequip += OnUnequip;
            itemStorage.onConsume += OnConsume;
            itemStorage.onRemoveSlot += UpdateSlots;
            onPlayerUIUseItem.onEventRaised += OnPlayerUIUseItem;
            onPlayerUIDropItem.onEventRaised += OnPlayerUIDropItem;
            
            UpdateSlots();
        }

        void OnDisable()
        {
            foreach (Transform child in grid.transform)
                child.GetComponent<InventorySlot>().ItemSlot = null;

            equipment.onEquip -= OnEquip;
            equipment.onUnequip -= OnUnequip;
            itemStorage.onConsume -= OnConsume;
            itemStorage.onRemoveSlot -= UpdateSlots;
            onPlayerUIUseItem.onEventRaised -= OnPlayerUIUseItem;
            onPlayerUIDropItem.onEventRaised -= OnPlayerUIDropItem;
        }

        void Update()
        {
            UseHint.gameObject.SetActive(selectedSlot != null);
            DropHint.gameObject.SetActive(selectedSlot != null);
        }

        void UpdateSlots()
        {
            List<ItemSlot> itemSlots = itemStorage.ItemSlots;
            for (int i = 0; i < grid.transform.childCount; i++)
            {
                InventorySlot slot = grid.transform.GetChild(i).GetComponent<InventorySlot>();
                if (i < itemSlots.Count)
                {
                    slot.ItemSlot = itemSlots[i];
                    Item item = slot.ItemSlot.Item;
                    IEquipable equipable = item as IEquipable;
                    if (equipable != null)
                        slot.SetEquipped(equipable.IsEquipped(equipment));
                }
                else
                {
                    slot.ItemSlot = null;
                }
                slot.SetSelected(false);
            }

            if (selectedSlot != null && selectedSlot.ItemSlot == null)
                selectedSlot = null;

            if (selectedSlot != null)
                selectedSlot.SetSelected(true);
        }

        public void OnSlotSelected(InventorySlot slot)
        {
            if (selectedSlot != null)
                selectedSlot.SetSelected(false);

            selectedSlot = slot;
            selectedSlot.SetSelected(true);
        }

        public void OnClose()
        {
            onPlayerUIInventory.RaiseEvent();
        }

        InventorySlot GetInventorySlot(Item item)
        {
            foreach(Transform child in grid.transform)
            {
                InventorySlot inventorySlot = child.GetComponent<InventorySlot>();
                if (inventorySlot.ItemSlot != null && inventorySlot.ItemSlot.Item == item)
                {
                    return inventorySlot;
                }
            }

            return null;
        }

        void OnEquip(IEquipable equipable)
        {
            UpdateSlots();
        }

        void OnUnequip(IEquipable equipable)
        {
            UpdateSlots();
        }

        void OnConsume(IConsumable consumable)
        {
            UpdateSlots();
        }

        void OnPlayerUIUseItem()
        {
            if (selectedSlot != null)
                selectedSlot.UseItem();
        }

        void OnPlayerUIDropItem()
        {
            // if (selectedSlot != null && selectedSlot.ItemSlot != null)
            // {
            //     equipment.UnEquip(selectedSlot.ItemSlot.item);
            //     itemsContainer.ReduceItemSlot(selectedSlot.ItemSlot);
            //     UpdateSlots();
            // }
        }
    }
}

