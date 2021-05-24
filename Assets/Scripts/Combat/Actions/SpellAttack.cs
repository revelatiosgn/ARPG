using System.Collections;
using System.Collections.Generic;
using ARPG.Gear;
using UnityEngine;
using Animancer;

using ARPG.Inventory;
using ARPG.Core;
using ARPG.Controller;
using ARPG.Spells;
using ARPG.Movement;

namespace ARPG.Combat
{
    public class SpellAttack : ICombatAction
    {
        bool isComplete = true;
        bool isAiming = false;
        AttackSpell spell;
        BaseCombat baseCombat;
        BaseController baseController;
        BaseMovement baseMovement;
        AnimancerLayer layer;
        AnimancerEvent.Sequence beginEvents;
        AnimancerEvent.Sequence launchEvents;

        public SpellAttack(AttackSpell spell, BaseCombat baseCombat)
        {
            this.spell = spell;
            this.baseCombat = baseCombat;
            this.baseController = baseCombat.GetComponent<BaseController>();
            this.baseMovement = baseCombat.GetComponent<BaseMovement>();
            layer = baseCombat.Animatrix.GetLayer(Animatrix.LayerName.Torso);

            beginEvents = new AnimancerEvent.Sequence(spell.spellAnimations.begin.Events);
            beginEvents.OnEnd = () => {
                Aim();
            };
            
            launchEvents = new AnimancerEvent.Sequence(spell.spellAnimations.launch.Events);
            launchEvents.OnEnd = () => {
                layer.StartFade(0f, 0.2f);
                baseMovement.MovementState = BaseMovement.State.Forward;
                baseCombat.AimEnd();
                isComplete = true;
            };
        }

        public void Start()
        {
            isComplete = false;

            AnimancerState state = layer.Play(spell.spellAnimations.begin);
            state.Events = beginEvents;

            baseMovement.MovementState = BaseMovement.State.Strafe;
        }

        public void Act()
        {
            if (isAiming && !baseCombat.IsAttacking)
                Launch();
        }

        public bool IsComplete()
        {
            return isComplete;
        }

        public void Interrupt()
        {
        }

        void Aim()
        {
            isAiming = true;

            AnimancerState state = layer.Play(spell.spellAnimations.aim);
            state.Time = 0f;

            if (!baseCombat.IsAttacking)
                Launch();
        }

        void Launch()
        {
            isAiming = false;

            AnimancerState state = layer.Play(spell.spellAnimations.launch);
            state.Events = launchEvents;
            state.Time = 0f;
            state.ApplyAnimatorIK = true;
            // isIKPass = false;

            // projectile.gameObject.transform.parent = null;
            // projectile.AttackDamage.Damage += item.damage;
            // projectile.AttackDamage.Source = baseController;
            // Vector3 targetPosition = baseCombat.targetPosition;
            // Vector3 direction = targetPosition - projectile.transform.position;
            // projectile.transform.rotation = Quaternion.LookRotation(direction);
            // projectile.Launch();
        }
    }
}

