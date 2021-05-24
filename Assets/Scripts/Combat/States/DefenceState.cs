using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Animancer;
using Lightbug.CharacterControllerPro.Core;
using ARPG.Gear;

namespace ARPG.Combat
{
    public class DefenceState : CombatState
    {
        public override void OnEnter()
        {
            fsm.BaseCombat.DefenceAction?.Start();
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate(float dt)
        {
            if (fsm.BaseCombat.CombatState == BaseCombat.State.Idle)
            {
                fsm.BaseCombat.IsDefending = false;
                fsm.BaseCombat.DefenceAction?.Interrupt();
                fsm.MakeTransition<HideState>();
                return;
            }

            fsm.BaseCombat.DefenceAction?.Act();
            if (fsm.BaseCombat.DefenceAction != null && fsm.BaseCombat.DefenceAction.IsComplete())
            {
                fsm.MakeTransition<ActionState>();
                return;
            }

            if (fsm.BaseCombat.IsAttacking)
            {
                fsm.BaseCombat.DefenceAction?.Interrupt();
                fsm.MakeTransition<AttackState>();
            }
        }
    }   
}

