using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Gear;
using ARPG.Combat;

namespace ARPG.Inventory
{
    [CreateAssetMenu(fileName = "Quiver", menuName = "Items/Equipment/Quiver", order = 1)]
    public class QuiverItem : Item, IEquipable, IProjectile
    {
        public GameObject quiverPrefab;
        public GameObject arrowPrefab;

        public float arrowSpeed;
        public float arrowDamage;

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

            EquipmentSlot slot = equipment.GetSlot(SlotType.Quiver);

            if (slot == null)
                return;
                
            slot.Equipable?.Unequip(equipment);

            GameObject equipmentObject = Instantiate(quiverPrefab, slot.transform);
            slot.Equipable = this;
            slot.EquipmentObject = equipmentObject;

            BaseCombat baseCombat = equipment.GetComponent<BaseCombat>();
            if (baseCombat != null)
                baseCombat.Projectile = new IProjectileReference(this);

            equipment.onEquip?.Invoke(this);
        }

        public void Unequip(Equipment equipment)
        {
            if (equipment == null)
                return;

            EquipmentSlot slot = equipment.GetSlot(SlotType.Quiver);
            if (slot == null)
                return;

            slot.Equipable = null;
            if (Application.isPlaying)
                GameObject.Destroy(slot.EquipmentObject);
            else
                GameObject.DestroyImmediate(slot.EquipmentObject);
            slot.EquipmentObject = null;

            BaseCombat baseCombat = equipment.GetComponent<BaseCombat>();
            if (baseCombat != null)
                baseCombat.Projectile = null;

            equipment.onUnequip?.Invoke(this);
        }

        public bool IsEquipped(Equipment equipment)
        {
             if (equipment == null)
                return false;

            return equipment.GetSlot(this) != null;
        }
        
        public Projectile GetProjectile()
        {
            Projectile projectile = GameObject.Instantiate(arrowPrefab).GetComponent<Projectile>();
            projectile.Speed = arrowSpeed;
            projectile.AttackDamage = new AttackDamage(AttackDamageType.Physic, arrowDamage);
            
            return projectile;
        }
    }
}

