using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ARPG.Gear
{
    public enum HandHolderType
    {
        LeftHand,
        RightHand
    }

    public enum BodyHolderType
    {
        Light,
        Heavy,
        Ranged,
        Shield
    }

    public class Equipment : MonoBehaviour
    {
        [System.Serializable]
        public class BodyHolder
        {
            public BodyHolderType type;
            public Transform transform;
        }

        [System.Serializable]
        public class HandHolder
        {
            public HandHolderType type;
            public Transform transform;
        }

        [SerializeField] List<EquipmentSlot> slots;

        [SerializeField] List<BodyHolder> bodyHolders;
        [SerializeField] List<HandHolder> handHolders;

        [SerializeField] Transform model;

        [SerializeField] Material skinMaterial;
        [SerializeField] Material hairMaterial;

        public Material SkinMaterial { get => skinMaterial; }
        public Material HairMaterial { get => hairMaterial; }

        public List<EquipmentSlot> Slots { get => slots; }

        public UnityAction<IEquipable> onEquip;
        public UnityAction<IEquipable> onUnequip;

        public EquipmentSlot GetSlot(SlotType slotType)
        {
            return slots.Find(slot => slot.SlotType == slotType);
        }

        public List<EquipmentSlot> GetSlots(SlotType slotTypes)
        {
            return slots.FindAll(slot => (slot.SlotType & slotTypes) != 0);
        }

        public EquipmentSlot GetSlot(IEquipable equipable)
        {
            if (equipable == null)
                return null;

            return slots.Find(slot => slot.Equipable == equipable);
        }

        public List<EquipmentSlot> GetSlots(IEquipable equipable)
        {
            if (equipable == null)
                return null;
                
            return slots.FindAll(slot => slot.Equipable == equipable);
        }

        public BodyHolder GetHolder(BodyHolderType type)
        {
            return bodyHolders.Find(bodyHolder => bodyHolder.type == type);
        }

        public HandHolder GetHolder(HandHolderType type)
        {
            return handHolders.Find(handHolder => handHolder.type == type);
        }

        public void UpdateMaterials()
        {
            foreach (Transform child in model)
            {
                SkinnedMeshRenderer mesh = child.GetComponent<SkinnedMeshRenderer>();
                if (mesh != null && skinMaterial != null)
                    mesh.material = skinMaterial;
            }

            slots.ForEach(slot => {
                slot.Equipable?.Equip(this);
            });
        }
    }
}
