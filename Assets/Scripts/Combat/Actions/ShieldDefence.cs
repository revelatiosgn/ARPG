using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

using ARPG.Inventory;
using ARPG.Core;

namespace ARPG.Combat
{
    public class ShieldDefence : ICombatAction
    {
        bool isComplete = true;
        ShieldItem item;
        AnimancerLayer layer;
        BaseCombat baseCombat;
        AnimancerEvent.Sequence events;

        public ShieldDefence(ShieldItem item, BaseCombat baseCombat)
        {
            this.item = item;
            this.baseCombat = baseCombat;
            layer = baseCombat.Animatrix.GetLayer(Animatrix.LayerName.Torso);

            events = new AnimancerEvent.Sequence(item.shieldAnimations.damageImpact.Events);
            events.OnEnd = () => {
                layer.Play(item.shieldAnimations.defence);
            };
        }

        public void Start()
        {
            isComplete = false;
            AnimancerState state = layer.Play(item.shieldAnimations.defence);
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
                AnimancerState state = layer.Play(item.shieldAnimations.damageImpact);
                state.Events = events;
            }
        }
    }
}
