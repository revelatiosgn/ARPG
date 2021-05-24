using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Gear;
using ARPG.Stats;

namespace ARPG.Inventory
{
    [CreateAssetMenu(fileName = "Armor", menuName = "Items/Equipment/Armor", order = 1)]
    public class ArmorItem : Item, IEquipable, IModifierProvider
    {
        public enum ArmorType
        {
            Head = SlotType.HeadArmor,
            Chest = SlotType.ChestArmor,
            Hands = SlotType.HandsArmor,
            Legs = SlotType.LegsArmor,
            Foots = SlotType.FootsArmor
        }

        public ArmorType armorType;
        public SkinnedMeshRenderer mesh;
        public float physicArmor;
        public float magicArmor;

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

            EquipmentSlot slot = equipment.GetSlot((SlotType) armorType);

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
            meshRenderer.material = equipment.SkinMaterial;

            if (armorType != ArmorType.Head)
            {
                baseMesh.enabled = false;
            }
            else
            {
                EquipmentSlot hairSlot = equipment.GetSlot(SlotType.Hair);
                if (hairSlot != null && hairSlot.EquipmentObject != null)
                    hairSlot.EquipmentObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
            }

            slot.Equipable = this;
            slot.EquipmentObject = equipmentObject;

            CharacterStats characterStats = equipment.GetComponent<CharacterStats>();
            if (characterStats != null)
                characterStats.AddProvider(this);

            equipment.onEquip?.Invoke(this);
        }

        public void Unequip(Equipment equipment)
        {
            if (equipment == null)
                return;

            EquipmentSlot slot = equipment.GetSlot((SlotType) armorType);
            if (slot == null)
                return;

            slot.Equipable = null;
            if (Application.isPlaying)
                GameObject.Destroy(slot.EquipmentObject);
            else
                GameObject.DestroyImmediate(slot.EquipmentObject);
            slot.EquipmentObject = null;

            slot.GetComponent<SkinnedMeshRenderer>().enabled = true;

            EquipmentSlot hairSlot = equipment.GetSlot(SlotType.Hair);
            if (hairSlot != null && hairSlot.EquipmentObject != null)
                hairSlot.EquipmentObject.GetComponent<SkinnedMeshRenderer>().enabled = true;

            CharacterStats characterStats = equipment.GetComponent<CharacterStats>();
            if (characterStats != null)
                characterStats.RemoveProvider(this);

            equipment.onUnequip?.Invoke(this);
        }

        public bool IsEquipped(Equipment equipment)
        {
            if (equipment == null)
                return false;

            return equipment.GetSlot(this) != null;
        }

        public void Modify(CharacterStats characterStats)
        {
            characterStats.GetStat(StatType.PhysicArmor)?.AddModifier(new StatModifier(this, physicArmor));
            characterStats.GetStat(StatType.MagicArmor)?.AddModifier(new StatModifier(this, magicArmor));
        }
    }
}

