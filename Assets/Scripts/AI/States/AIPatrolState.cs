using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Combat;

namespace ARPG.AI
{
    public class AIPatrolState : AIState
    {
        [SerializeField] List<Transform> waypoints;
        int currentWapointIndex = 0;

        public override void OnEnter()
        {
            if (waypoints.Count == 0)
            {
                fsm.MakeTransition<AIIdleState>();
                return;
            }

            fsm.AIMovement.Move(waypoints[currentWapointIndex].position);
            currentWapointIndex = (currentWapointIndex + 1) % waypoints.Count;
        }

        public override void OnUpdate(float dt)
        {
            if (fsm.AICombat.Target != null)
            {
                fsm.ReturnPosition = transform.position;
                fsm.MakeTransition<AICombatState>();
                return;
            }

            if (fsm.AIMovement.IsStopped())
                fsm.MakeTransition<AIIdleState>();
        }
    }
}

