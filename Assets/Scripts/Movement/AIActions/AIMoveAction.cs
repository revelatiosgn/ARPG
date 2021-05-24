using System.Collections;
using System.Collections.Generic;
using ARPG.Controller;
using UnityEngine;
using UnityEngine.AI;

namespace ARPG.Movement
{
    public class AIMoveAction : AIMovementAction
    {
        float reachDistance = 0.5f;

        public AIMoveAction(Transform selfTransform, Vector3 destination) : base(selfTransform)
        {
            this.destination = destination;
        }

        public override void GetInput(ref Vector3 direction, ref Vector2 movement)
        {
            if (navMeshPath == null || navMeshPath.status != NavMeshPathStatus.PathComplete)
                return;

            if (navMeshPath.corners.Length >= 2)
            {
                direction = navMeshPath.corners[1] - navMeshPath.corners[0];
                direction.y = 0f;
                direction.Normalize();
                movement.x = direction.x;
                movement.y = direction.z;
            }
        }

        public override bool IsComplete()
        {
            if (navMeshPath == null || navMeshPath.status != NavMeshPathStatus.PathComplete)
                return true;

            if (navMeshPath.corners.Length <= 2)
            {
                if ((selfTransform.position - destination).sqrMagnitude < reachDistance * reachDistance)
                    return true;
            }

            return false;
        }
    }
}