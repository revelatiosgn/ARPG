using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Animancer;

namespace ARPG.Movement
{
    public class JumpState : MovementState
    {
        [SerializeField] ClipState.Transition jump;
        AnimancerEvent.Sequence events = null;

        public override void OnEnter()
        {
            if (events == null)
            {
                events = new AnimancerEvent.Sequence(jump.Events);
                events.OnEnd = () => {
                    fsm.MakeTransition<FallState>();
                };
            }

            AnimancerState jumpState = fsm.Animatrix.Play(jump, 0.2f);
            jumpState.Events = events;
            jumpState.Time = 0f;

            fsm.CharacterActor.ForceNotGrounded();
            Vector3 velocity = fsm.CharacterActor.Velocity;
            velocity.y = Mathf.Sqrt(2 * fsm.BaseMovement.JumpHeight * -Physics.gravity.y);
            fsm.CharacterActor.Velocity = velocity;
        }

        public override void OnUpdate(float dt)
        {
            fsm.CharacterActor.Velocity += Physics.gravity * dt;
        }
    }   
}

