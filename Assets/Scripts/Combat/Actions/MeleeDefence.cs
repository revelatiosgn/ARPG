using System.Collections;
using System.Collections.Generic;
using ARPG.Gear;
using UnityEngine;
using Animancer;

using ARPG.Inventory;
using ARPG.Core;

namespace ARPG.Combat
{
    public class MeleeDefence : ICombatAction
    {
        bool isComplete = true;
        MeleeWeaponItem item;
        AnimancerLayer layer;
        BaseCombat baseCombat;
        AnimancerEvent.Sequence events;

        public MeleeDefence(MeleeWeaponItem item, BaseCombat baseCombat)
        {
            this.item = item;
            this.baseCombat = baseCombat;
            layer = baseCombat.Animatrix.GetLayer(Animatrix.LayerName.Torso);

            events = new AnimancerEvent.Sequence(item.meleeAnimations.damageImpact.Events);
            events.OnEnd = () => {
                layer.Play(item.meleeAnimations.defence);
            };
        }

        public void Start()
        {
            isComplete = false;
            AnimancerState state = layer.Play(item.meleeAnimations.defence);
            baseCombat.onTakeDamage += OnTakeDamage;
        }

        public void Act()
        {
            if (!baseCombat.IsDefending)
                Interrupt();
        }

        public bool IsComplete()
        {
            return isComplete;
        }

        public void Interrupt()
        {
            isComplete = true;
            layer.StartFade(0f, 0.2f);
            baseCombat.onTakeDamage -= OnTakeDamage;
        }
        
        public void OnTakeDamage(AttackDamage attackDamage)
        {
            if (Vector3.Angle(-attackDamage.Direction, baseCombat.transform.forward) < item.defenceAngle * 0.5f)
            {
                attackDamage.Damage *= item.defenceValue;
                attackDamage.IsReduced = true;
                AnimancerState state = layer.Play(item.meleeAnimations.damageImpact);
                state.Events = events;
            }
        }
    }
}

