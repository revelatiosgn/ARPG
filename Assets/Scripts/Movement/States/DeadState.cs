using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lightbug.CharacterControllerPro.Core;
using Animancer;

namespace ARPG.Movement
{
    public class DeadState : MovementState
    {
        [SerializeField] ClipState.Transition death;

        public override void OnEnter()
        {
            fsm.Animatrix.Play(death, 0.2f);
            fsm.CharacterActor.Velocity = Vector3.zero;
            fsm.CharacterActor.ColliderComponent.enabled = false;
        }

        public override void OnUpdate(float dt)
        {
            if (!fsm.CharacterStats.IsDead())
            {
                fsm.CharacterActor.ColliderComponent.enabled = true;
                fsm.MakeTransition<GroundedState>();
                return;
            }

            fsm.CharacterActor.Velocity += Physics.gravity * dt;
        }
    }   
}

