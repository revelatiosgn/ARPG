using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Gear;
using Animancer;
using ARPG.Inventory;

namespace ARPG.Combat
{
    public class ShowWeapon : ICombatAction
    {
        bool isComplete = true;
        WeaponItem item;
        Equipment equipment;
        AnimancerLayer layer;
        AnimancerEvent.Sequence events;

        EquipmentSlot slot = null;
        Equipment.HandHolder holder = null;

        public ShowWeapon(WeaponItem item, BaseCombat baseCombat)
        {
            this.item = item;
            this.equipment = baseCombat.Equipment;
            layer = baseCombat.Animatrix.GetLayer(item.weaponAnimations.layer);

            if (this.equipment != null)
            {
                slot = equipment.GetSlot(item);
                holder = equipment.GetHolder(item.handHolder);
            }

            events = new AnimancerEvent.Sequence(item.weaponAnimations.grab.Events);
            events.SetCallback("GrabWeapon", () => {
                Grab();
            });
            events.OnEnd = () => {
                PlayIdle();
                isComplete = true;
            };
        }

        public void Start()
        {
            if (slot == null || slot.EquipmentObject == null || holder == null || slot.EquipmentObject.transform.parent == holder.transform)
            {
                PlayIdle();
                return;
            }

            isComplete = false;

            AnimancerState state = layer.Play(item.weaponAnimations.grab);
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

        void PlayIdle()
        {
            layer.Play(item.weaponAnimations.idle);
            // layer.StartFade(item.weaponAnimations.idleWeight, 0.2f);
        }

        void Grab()
        {
            slot.EquipmentObject.transform.parent = holder.transform;
            slot.EquipmentObject.transform.position = holder.transform.position;
            slot.EquipmentObject.transform.rotation = holder.transform.rotation;
        }
    }
}

