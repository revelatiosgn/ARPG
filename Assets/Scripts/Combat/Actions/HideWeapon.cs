using System.Collections;
using System.Collections.Generic;
using ARPG.Gear;
using UnityEngine;
using Animancer;

using ARPG.Inventory;

namespace ARPG.Combat
{
    public class HideWeapon : ICombatAction
    {
        bool isComplete = true;
        WeaponItem item;
        Equipment equipment;
        AnimancerLayer layer;
        AnimancerEvent.Sequence events;
        
        EquipmentSlot slot = null;
        Equipment.BodyHolder holder = null;

        public HideWeapon(WeaponItem item, BaseCombat baseCombat)
        {
            this.item = item;
            this.equipment = baseCombat.Equipment;
            layer = baseCombat.Animatrix.GetLayer(item.weaponAnimations.layer);

            if (this.equipment != null)
            {
                slot = equipment.GetSlot(item);
                holder = equipment.GetHolder(item.bodyHolder);
            }

            events = new AnimancerEvent.Sequence(item.weaponAnimations.remove.Events);
            events.SetCallback("RemoveWeapon", () => {
                Remove();
            });
            events.OnEnd = () => {
                Interrupt();
            };
        }

        public void Start()
        {
            if (slot == null || slot.EquipmentObject == null || holder == null || slot.EquipmentObject.transform.parent == holder.transform)
            {
                layer.StartFade(0f, 0.2f);
                return;
            }

            isComplete = false;

            AnimancerState state = layer.Play(item.weaponAnimations.remove);
            state.Events = events;
            state.Time = 0f;
        }

        public void Act()
        {
        }

        public bool IsComplete()
        {
            return isComplete;
        }

        public void Interrupt()
        {
            isComplete = true;
            layer.StartFade(0f, 0.2f);
        }

        void Remove()
        {
            slot.EquipmentObject.transform.parent = holder.transform;
            slot.EquipmentObject.transform.position = holder.transform.position;
            slot.EquipmentObject.transform.rotation = holder.transform.rotation;
        }
    }
}

