using System.Collections;
using System.Collections.Generic;
using ARPG.Controller;
using UnityEngine;
using UnityEngine.AI;

namespace ARPG.Movement
{
    public class AIMovement : BaseMovement
    {
        AIMovementAction action = null;
        public AIMovementAction Action { get => action; }

        bool isRunning = false;
        public bool IsRunning { get => isRunning; set => isRunning = value; }

        void Update()
        {
            Vector3 targetDirection = Vector3.zero;
            Vector2 targetMovement = Vector2.zero;

            if (action != null)
            {
                action.Act(Time.deltaTime);
                action.GetInput(ref targetDirection, ref targetMovement);
                if (action.IsComplete())
                    action = null;
            }
            else
            {
                movementInput.y = 0f;
            }

            float speed = isRunning ? runSpeed : walkSpeed;
            directionInput = Vector3.MoveTowards(directionInput, targetDirection, 8f * Time.deltaTime);
            movementInput.y = Mathf.MoveTowards(movementInput.y, targetMovement.sqrMagnitude * speed, 8f * Time.deltaTime);
        }

        public void Move(Vector3 destination)
        {
            action = new AIMoveAction(transform, destination);
        }

        public void Follow(Transform target, float distance)
        {
            action = new AIFollowAction(transform, target, distance - 0.5f, distance);
        }

        public void Stop()
        {
            action = null;
        }

        public bool IsStopped()
        {
            return action == null;
        }

        void OnDrawGizmos()
        {
            if (action == null)
                return;

            NavMeshPath navMeshPath = action.NavMeshPath;
            if (navMeshPath != null && navMeshPath.corners.Length >= 2)
            {
                Gizmos.color = Color.magenta;
                for (int i = 0; i < navMeshPath.corners.Length - 1; i++)
                    Gizmos.DrawLine(navMeshPath.corners[i], navMeshPath.corners[i + 1]);
            }
        }
    }
}