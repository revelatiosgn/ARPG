using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

using ARPG.Gear;
using ARPG.Combat;
using ARPG.Core;

namespace ARPG.Inventory
{
    [System.Serializable]
    public abstract class WeaponItem : Item, IEquipable, ICombating
    {
        public enum Occupy
        {
            OneHanded,
            TwoHanded
        }
        
        [System.Serializable]
        public class WeaponAnimations
        {
            public ClipState.Transition idle;
            public ClipState.Transition grab;
            public ClipState.Transition remove;
            public Animatrix.LayerName layer;
            [Range(0f, 1f)] public float idleWeight; 
        }

        public GameObject prefab;
        public HandHolderType handHolder;
        public BodyHolderType bodyHolder;
        public Occupy occupy;

        public WeaponAnimations weaponAnimations;

        public override void Use(GameObject target)
        {
            Equipment equipment = target.GetComponent<Equipment>();
            if (IsEquipped(equipment))
                Unequip(equipment);
            else
                Equip(equipment);
        }

        public void Equip(Equipment equipment)
        {
            if (equipment == null)
                return;

            SlotType slotType = handHolder == HandHolderType.LeftHand ? SlotType.LCombat : SlotType.RCombat;
            EquipmentSlot slot = equipment.GetSlot(slotType);

            if (slot == null)
                return;

            Transform holderTransform = equipment.GetHolder(bodyHolder).transform;
            if (holderTransform == null)
                return;

            GameObject equipmentObject = Instantiate(prefab, holderTransform);
            equipment.GetSlots(occupy == Occupy.OneHanded ? slotType : SlotType.LCombat | SlotType.RCombat).ForEach(slot =>
            {
                slot.Equipable?.Unequip(equipment);
                slot.Equipable = this;
                slot.EquipmentObject = equipmentObject;
            });

            BaseCombat baseCombat = equipment.GetComponent<BaseCombat>();
            if (baseCombat != null)
                baseCombat.AddCombating(this);

            equipment.onEquip?.Invoke(this);
        }

        public void Unequip(Equipment equipment)
        {
            if (equipment == null)
                return;

            equipment.GetSlots(this).ForEach(slot => {
                slot.Equipable = null;
                if (Application.isPlaying)
                    GameObject.Destroy(slot.EquipmentObject);
                else
                    GameObject.DestroyImmediate(slot.EquipmentObject);
                slot.EquipmentObject = null;
            });

            BaseCombat baseCombat = equipment.GetComponent<BaseCombat>();
            if (baseCombat != null)
                baseCombat.RemoveCombating(this);

            equipment.onUnequip?.Invoke(this);
        }

        public bool IsEquipped(Equipment equipment)
        {
            if (equipment == null)
                return false;

            return equipment.GetSlot(this) != null;
        }

        public abstract void AddActions(BaseCombat baseCombat);
    }
}

