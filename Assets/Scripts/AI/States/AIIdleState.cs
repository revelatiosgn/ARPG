using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Combat;

namespace ARPG.AI
{
    public class AIIdleState : AIState
    {
        float stateTime = 0f;

        public override void OnEnter()
        {
            stateTime = 0f;
            fsm.AIMovement.Stop();
            fsm.AIMovement.IsRunning = false;
            fsm.AICombat.CombatState = BaseCombat.State.Idle;
            fsm.AICombat.Target = null;
        }

        public override void OnUpdate(float dt)
        {
            if (fsm.AICombat.Target != null)
            {
                fsm.ReturnPosition = transform.position;
                fsm.MakeTransition<AICombatState>();
                return;
            }

            stateTime += dt;
            if (stateTime > 3)
                fsm.MakeTransition<AIPatrolState>();
        }
    }
}

