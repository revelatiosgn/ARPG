using System.Collections;
using System.Collections.Generic;
using ARPG.Controller;
using UnityEngine;
using UnityEngine.AI;

namespace ARPG.Movement
{
    public class AIFollowAction : AIMovementAction
    {
        Transform targetTransform;
        float minDistance = 0.5f;
        float maxDistance = 1f;
        bool isInDistance = false;

        public AIFollowAction(Transform selfTransform, Transform targetTransform, float minDistance, float maxDistance) : base(selfTransform)
        {
            this.targetTransform = targetTransform;
            this.minDistance = minDistance;
            this.maxDistance = maxDistance;
            this.destination = targetTransform.position;
        }

        public override void Act(float dt)
        {
            if (IsPaused)
                return;

            base.Act(dt);

            destination = targetTransform.position;
        }

        public override void GetInput(ref Vector3 direction, ref Vector2 movement)
        {
            if (IsPaused)
            {
                direction = targetTransform.position - selfTransform.position;
                direction.y = 0f;
                direction.Normalize();
                return;
            }

            if (navMeshPath == null || navMeshPath.status == NavMeshPathStatus.PathInvalid)
                return;

            if (navMeshPath.status == NavMeshPathStatus.PathPartial)
            {
                direction = targetTransform.position - selfTransform.position;
                direction.y = 0f;
                direction.Normalize();
                return;
            }

            if (navMeshPath.corners.Length > 2)
            {
                direction = navMeshPath.corners[1] - navMeshPath.corners[0];
                direction.y = 0f;
                direction.Normalize();
                movement.x = direction.x;
                movement.y = direction.z;
            }
            else
            {
                direction = targetTransform.position - selfTransform.position;
                float sqrDistance = direction.sqrMagnitude;
                direction.y = 0f;
                direction.Normalize();
                if (isInDistance)
                {
                    if (sqrDistance > maxDistance * maxDistance)
                        isInDistance = false;
                }
                else
                {
                    if (sqrDistance <= minDistance * minDistance)
                    {
                        isInDistance = true;
                    }
                    else
                    {
                        movement.x = direction.x;
                        movement.y = direction.z;
                    }
                }
            }
        }

        public override bool IsComplete()
        {
            return false;
        }
    }
}