using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.AI
{
    public class AIChaseState : AIState
    {
        [SerializeField] float chaseTimeLimit = 5f;
        float chaseTimer = 0f;

        public override void OnEnter()
        {
            chaseTimer = 0f;
            
            if (fsm.AICombat.Target != null)
                fsm.AIMovement.Follow(fsm.AICombat.Target.transform, 3f);
        }
        

        public override void OnExit()
        {
            fsm.AICombat.AttackEnd();
            fsm.AICombat.DefenceEnd();
        }

        public override void OnUpdate(float dt)
        {
            if (fsm.AICombat.Target == null || fsm.AIMovement.Action == null)
            {
                fsm.MakeTransition<AIReturnState>();
                return;
            }

            if (fsm.AILook.Targets.Find(target => target == fsm.AICombat.Target) != null)
            {
                fsm.MakeTransition<AICombatState>();
                return;
            }

            if (fsm.AICombat.Target.CharacterStats.IsDead())
            {
                fsm.MakeTransition<AIReturnState>();
                return;
            }

            chaseTimer += dt;
            if (chaseTimer > chaseTimeLimit)
            {
                fsm.AICombat.Target = null;
                fsm.MakeTransition<AIReturnState>();
            }
        }
    }
}

