using System.Collections;
using System.Collections.Generic;
using ARPG.Controller;
using UnityEngine;
using UnityEngine.AI;

namespace ARPG.Movement
{
    public abstract class AIMovementAction
    {
        protected Transform selfTransform;
        protected Vector3 destination;
        protected NavMeshPath navMeshPath = null;

        float recalcDelay = 0.5f;
        float recalcElapsed = 0f;

        bool isPaused = false;
        public bool IsPaused { get => isPaused; set => isPaused = value; }

        public NavMeshPath NavMeshPath { get => navMeshPath; }

        public AIMovementAction(Transform selfTransform)
        {
            this.selfTransform = selfTransform;
            navMeshPath = new NavMeshPath();

            recalcElapsed = recalcDelay + Mathf.Epsilon;
        }

        public virtual void Act(float dt)
        {
            if (isPaused)
                return;

            recalcElapsed += dt;
            if (recalcElapsed >= recalcDelay)
            {
                recalcElapsed = 0f;
                NavMesh.CalculatePath(selfTransform.position, destination, NavMesh.AllAreas, navMeshPath);
            }
        }

        public bool IsDirectPath()
        {
            if (navMeshPath != null && navMeshPath.status == NavMeshPathStatus.PathComplete && navMeshPath.corners.Length == 2)
                return true;

            return false;
        }

        public abstract void GetInput(ref Vector3 direction, ref Vector2 movement);
        public abstract bool IsComplete();
    }
}