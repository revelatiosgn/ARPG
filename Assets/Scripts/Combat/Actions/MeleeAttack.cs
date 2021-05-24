using System.Collections;
using System.Collections.Generic;
using ARPG.Gear;
using UnityEngine;
using Animancer;

using ARPG.Inventory;
using ARPG.Core;
using ARPG.Controller;

namespace ARPG.Combat
{
    public class MeleeAttack : ICombatAction
    {
        bool isComplete = true;
        MeleeWeaponItem item;
        BaseCombat baseCombat;
        BaseController baseController;
        AnimancerLayer layer;
        int attackIndex = 0;
        AnimancerEvent.Sequence events;
        LayerMask weaponMask;

        public MeleeAttack(MeleeWeaponItem item, BaseCombat baseCombat)
        {
            this.item = item;
            this.baseCombat = baseCombat;
            this.baseController = baseCombat.GetComponent<BaseController>();
            layer = baseCombat.Animatrix.GetLayer(Animatrix.LayerName.Body);

            events = new AnimancerEvent.Sequence(item.meleeAnimations.attacks[attackIndex].Events);
            events.SetCallback("AttackReady", () => {
                attackIndex = (attackIndex + 1) % item.meleeAnimations.attacks.Length;
                isComplete = true;
            });
            events.SetCallback("AttackHit", () => {
                AttackHit();
            });
            events.OnEnd = () => {
                layer.StartFade(0f, 0.2f);
                attackIndex = 0;
            };

            baseCombat.AttackRange = item.range;
            weaponMask = LayerMask.GetMask("Character");
        }

        public void Start()
        {
            isComplete = false;

            AnimancerState state = layer.Play(item.meleeAnimations.attacks[attackIndex]);
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

        void AttackHit()
        {
            Collider[] colliders = Physics.OverlapSphere(baseCombat.transform.position, item.range, weaponMask, QueryTriggerInteraction.Ignore);
            for (int i = 0; i < colliders.Length; i++)
            {
                BaseController controller = colliders[i].GetComponent<BaseController>();
                if (controller == null || baseController.CharacterGroup == controller.CharacterGroup)
                    continue;

                AttackDamage attackDamage = new AttackDamage(AttackDamageType.Physic, item.damage, baseCombat.transform.forward);
                attackDamage.Source = baseController;
                controller.BaseCombat.TakeDamage(attackDamage);
            }
        }
    }
}

