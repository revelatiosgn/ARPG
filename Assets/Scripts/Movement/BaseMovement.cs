using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;
using UnityEngine.Events;

using ARPG.Combat;

namespace ARPG.Movement
{
    public class BaseMovement : MonoBehaviour
    {
        public enum State
        {
            Forward,
            Strafe
        }

        protected const float walkSpeed = 1f;
        protected const float runSpeed = 2f;
        protected const float strafeSpeed = 3f;

        State movementState = State.Forward;
        public State MovementState { get => movementState; set {
            movementState = value;
            movementInput = Vector2.zero;
            directionInput = Vector3.zero;
        }}

        [SerializeField] float jumpHeight = 3;

        protected Vector2 movementInput = Vector2.zero;
        protected Vector3 directionInput = Vector3.zero;

        public Vector2 MovementInput { get => movementInput; }
        public Vector3 DirectionInput { get => directionInput; }
        public float JumpHeight { get => jumpHeight; set => jumpHeight = value; }

        public UnityAction onJump;
    }
}
