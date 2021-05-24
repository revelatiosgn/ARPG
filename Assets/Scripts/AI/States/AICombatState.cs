using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Combat;
using ARPG.Movement;

namespace ARPG.AI
{
    public class AICombatState : AIState
    {
        float attackTimer = 0f;
        float attackRange = 0f;
        float defenceRange = 0f;

        public override void OnEnter()
        {
            fsm.AICombat.CombatState = BaseCombat.State.Action;
            fsm.AIMovement.IsRunning = true;
            attackRange = 0f;
        }

        public override void OnExit()
        {
            fsm.AICombat.AttackEnd();
            fsm.AICombat.DefenceEnd();
        }

        public override void OnUpdate(float dt)
        {
            if (attackRange != fsm.AICombat.AttackRange)
            {
                attackRange = fsm.AICombat.AttackRange;
                defenceRange = attackRange * 3f;
                fsm.AIMovement.Follow(fsm.AICombat.Target.transform, fsm.AICombat.AttackRange);
            }

            if (fsm.AICombat.Target == null || fsm.AIMovement.Action == null)
            {
                fsm.MakeTransition<AIReturnState>();
                return;
            }

            if (fsm.AILook.Targets.Find(target => target == fsm.AICombat.Target) == null)
            {
                fsm.MakeTransition<AIChaseState>();
                return;
            }

            fsm.AICombat.AttackEnd();

            AIMovementAction movementAction = fsm.AIMovement.Action;
            Vector3 direction = fsm.AICombat.Target.transform.position - fsm.AICombat.transform.position;

            float sqrDistance = direction.sqrMagnitude;
            float sqrAttackRange = attackRange * attackRange;
            float sqrDefenceRange = defenceRange * defenceRange;

            if (sqrDistance < sqrDefenceRange)
            {
                fsm.AICombat.DefenceBegin();
            }
            else
            {
                fsm.AICombat.DefenceEnd();
            }

            if (sqrDistance < sqrAttackRange)
            {
                if (movementAction != null)
                    movementAction.IsPaused = true;

                fsm.AICombat.targetPosition = fsm.AICombat.Target.transform.position + Vector3.up * 1f;
                fsm.AICombat.aimRotation = Quaternion.FromToRotation(Vector3.forward, direction.normalized);

                if (attackTimer > 2f)
                {
                    attackTimer = 0f;
                    fsm.AICombat.AttackBegin();
                }
            }
            else
            {
                if (movementAction != null)
                    movementAction.IsPaused = false;
            }

            attackTimer += dt;
        }
    }
}

