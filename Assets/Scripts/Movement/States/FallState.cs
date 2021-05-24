using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lightbug.CharacterControllerPro.Core;
using Animancer;

namespace ARPG.Movement
{
    public class FallState : MovementState
    {
        [SerializeField] ClipState.Transition fall;

        public override void OnEnter()
        {
            fsm.Animatrix.Play(fall, 0.2f);
        }

        public override void OnUpdate(float dt)
        {
            if (fsm.CharacterActor.CurrentState != CharacterActorState.NotGrounded)
            {
                fsm.MakeTransition<GroundedState>();
                return;
            }

            fsm.CharacterActor.Velocity += Physics.gravity * dt;
        }
    }   
}

