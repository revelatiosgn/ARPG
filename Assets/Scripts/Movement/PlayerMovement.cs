using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;
using System;

using ARPG.Controller;
using ARPG.Events;
using Lightbug.CharacterControllerPro.Core;

namespace ARPG.Movement
{
    public class PlayerMovement : BaseMovement
    {
        [SerializeField] Vector2Event onPlayerMove;
        [SerializeField] VoidEvent onPlayerJump;

        Vector2 inputValue;

        protected void OnEnable()
        {
            onPlayerMove.onEventRaised += OnPlayerMove;
            onPlayerJump.onEventRaised += OnPlayerJump;
        }

        protected void OnDisable()
        {
            onPlayerMove.onEventRaised -= OnPlayerMove;
            onPlayerJump.onEventRaised -= OnPlayerJump;
        }

        void Update()
        {
            Vector3 targetDirectionInput = Vector3.zero;
            if (MovementState == State.Forward)
            {
                targetDirectionInput += Camera.main.transform.right * inputValue.x;
                targetDirectionInput += Camera.main.transform.forward * inputValue.y;
                targetDirectionInput.y = 0f;
                targetDirectionInput.Normalize();

                directionInput = Vector3.MoveTowards(directionInput, targetDirectionInput, 8f * Time.deltaTime);

                movementInput.x = 0f;
                movementInput.y = directionInput.sqrMagnitude * 2.5f;
            }
            else
            {
                directionInput = Camera.main.transform.forward;
                directionInput.y = 0f;
                directionInput.Normalize();

                movementInput.x = inputValue.x;
                movementInput.y = inputValue.y;
            }
        }

        void OnPlayerMove(Vector2 value)
        {
            inputValue = value;
        }

        void OnPlayerJump()
        {
            onJump?.Invoke();
        }
    }
}
