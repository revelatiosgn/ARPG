using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Animancer;
using Lightbug.CharacterControllerPro.Core;
using ARPG.Combat;

namespace ARPG.Movement
{
    public class GroundedState : MovementState
    {
        [SerializeField] LinearMixerTransition mixer;
        [SerializeField] float acceleration = 10f;
        
        LinearMixerState mixerState;

        Vector3 rotationVel;

        public override void OnEnter()
        {
            if (mixerState == null)
                mixerState = mixer.CreateState() as LinearMixerState;

            fsm.Animatrix.Play(mixerState, 0.2f);

            fsm.BaseMovement.onJump += OnJump;
        }

        public override void OnExit()
        {
            fsm.BaseMovement.onJump -= OnJump;
        }

        public override void OnUpdate(float dt)
        {
            if (fsm.CharacterActor.CurrentState == CharacterActorState.NotGrounded)
            {
                fsm.MakeTransition<FallState>();
                return;
            }
            else if (fsm.CharacterActor.CurrentState == CharacterActorState.UnstableGrounded)
            {
                fsm.MakeTransition<SlideState>();
                return;
            }

            fsm.CharacterActor.Forward = fsm.BaseMovement.DirectionInput;
            Vector2 parameter = fsm.BaseMovement.MovementInput;
            foreach (MixerState<Vector2> state in mixerState.ChildStates)
                state.Parameter = parameter;

            fsm.CharacterActor.Velocity = fsm.Animatrix.Animator.velocity;
            mixerState.Parameter = Mathf.MoveTowards(mixerState.Parameter, fsm.BaseCombat.CombatState == BaseCombat.State.Idle ? 0f : 1f, acceleration * Time.fixedDeltaTime);
        }

        void OnJump()
        {
           fsm.MakeTransition<JumpState>();
        }
    }   
}

