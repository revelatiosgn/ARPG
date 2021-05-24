using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Animancer;
using Lightbug.CharacterControllerPro.Core;
using ARPG.Gear;

namespace ARPG.Combat
{
    public class AttackState : CombatState
    {
        public override void OnEnter()
        {
            fsm.BaseCombat.AttackAction?.Start();
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate(float dt)
        {
            if (fsm.BaseCombat.CombatState == BaseCombat.State.Idle)
            {
                fsm.BaseCombat.IsAttacking = false;
                fsm.BaseCombat.AttackAction?.Interrupt();
                fsm.MakeTransition<HideState>();
                return;
            }

            fsm.BaseCombat.AttackAction?.Act();
            if (fsm.BaseCombat.AttackAction != null && fsm.BaseCombat.AttackAction.IsComplete())
                fsm.MakeTransition<ActionState>();
        }

        void OnAnimatorIK()
        {
            // foreach (WeaponAction weaponBehaviour in fsm.WeaponBehaviours)
            //     weaponBehaviour.OnAnimatorIK();
        }
    }   
}

