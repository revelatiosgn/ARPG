using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lightbug.CharacterControllerPro.Core;
using Animancer;

namespace ARPG.Movement
{
    public class SlideState : MovementState
    {
        [SerializeField] ClipState.Transition slide;

        public override void OnEnter()
        {
            fsm.Animatrix.Play(slide, 0.2f);
        }

        public override void OnUpdate(float dt)
        {
            if (fsm.CharacterActor.CurrentState != CharacterActorState.UnstableGrounded)
            {
                fsm.MakeTransition<GroundedState>();
                return;
            }

            fsm.CharacterActor.Velocity += Physics.gravity * Time.deltaTime;
            fsm.CharacterActor.Forward = Vector3.ProjectOnPlane(fsm.CharacterActor.Velocity, fsm.CharacterActor.Up);
        }
    }   
}

