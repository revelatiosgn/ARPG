using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Gear;
using ARPG.Combat;
using Animancer;

namespace ARPG.Spells
{
    public abstract class Spell : ScriptableObject, IEquipable, ICombating
    {
        public string title = "Unnamed Spell";

        public GameObject prefab;
        public HandHolderType handHolder;

        [System.Serializable]
        public class SpellAnimations
        {
            public ClipState.Transition begin;
            public ClipState.Transition aim;
            public ClipState.Transition launch;
            public ClipState.Transition idle;
        }

        public SpellAnimations spellAnimations;

        public void Equip(Equipment equipment)
        {
            if (equipment == null)
                return;

            SlotType slotType = handHolder == HandHolderType.LeftHand ? SlotType.LCombat : SlotType.RCombat;
            EquipmentSlot slot = equipment.GetSlot(slotType);

            if (slot == null)
                return;

            Transform holderTransform = equipment.GetHolder(handHolder).transform;
            if (holderTransform == null)
                return;

            GameObject equipmentObject = Instantiate(prefab, holderTransform);
            slot.Equipable?.Unequip(equipment);
            slot.Equipable = this;
            slot.EquipmentObject = equipmentObject;
            equipmentObject.SetActive(false);

            BaseCombat baseCombat = equipment.GetComponent<BaseCombat>();
            if (baseCombat != null)
                baseCombat.AddCombating(this);

            equipment.onEquip?.Invoke(this);
        }

        public bool IsEquipped(Equipment equipment)
        {
            if (equipment == null)
                return false;

            return equipment.GetSlot(this) != null;
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

        public abstract void AddActions(BaseCombat baseCombat);
    }
}

