using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Gear
{
    [CreateAssetMenu(fileName = "Eyebrows", menuName = "Traits/Eyebrows", order = 1)]
    public class EyebrowsTrait : FaceTrait, IEquipable
    {
        public void Equip(Equipment equipment)
        {
            if (equipment == null)
                return;

            EquipmentSlot slot = equipment.GetSlot(SlotType.Eyebrows);

            if (slot == null)
                return;

            slot.Equipable?.Unequip(equipment);

            SkinnedMeshRenderer baseMesh = slot.GetComponent<SkinnedMeshRenderer>();

            GameObject equipmentObject = GameObject.Instantiate(mesh.gameObject, slot.transform.parent);
            equipmentObject.name = name.ToString();
            equipmentObject.transform.position = slot.transform.parent.transform.position;
            equipmentObject.transform.parent = slot.transform.parent.transform.parent;

            SkinnedMeshRenderer meshRenderer = equipmentObject.GetComponent<SkinnedMeshRenderer>();
            meshRenderer.rootBone = baseMesh.rootBone;
            meshRenderer.bones = baseMesh.bones;
            meshRenderer.material = equipment.HairMaterial;

            slot.Equipable = this;
            slot.EquipmentObject = equipmentObject;

            equipment.onEquip?.Invoke(this);
        }

        public void Unequip(Equipment equipment)
        {
            if (equipment == null)
                return;

            EquipmentSlot slot = equipment.GetSlot(SlotType.Eyebrows);
            if (slot == null)
                return;

            slot.Equipable = null;
            if (Application.isPlaying)
                GameObject.Destroy(slot.EquipmentObject);
            else
                GameObject.DestroyImmediate(slot.EquipmentObject);
            slot.EquipmentObject = null;

            equipment.onUnequip?.Invoke(this);
        }

        public bool IsEquipped(Equipment equipment)
        {
            if (equipment == null)
                return false;

            return equipment.GetSlot(this) != null;
        }
    }
}