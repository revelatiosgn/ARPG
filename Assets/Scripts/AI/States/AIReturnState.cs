using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Combat;

namespace ARPG.AI
{
    public class AIReturnState : AIState
    {
        float stateTime = 0f;

        public override void OnEnter()
        {
            stateTime = 0f;
            fsm.AIMovement.IsRunning = false;
            fsm.AICombat.CombatState = BaseCombat.State.Idle;
            fsm.AICombat.Target = null;
            fsm.AIMovement.Move(fsm.ReturnPosition);
        }

        public override void OnUpdate(float dt)
        {
            if (fsm.AICombat.Target != null)
            {
                fsm.MakeTransition<AICombatState>();
                return;
            }

            if (fsm.AIMovement.IsStopped())
                fsm.MakeTransition<AIIdleState>();
        }
    }
}

