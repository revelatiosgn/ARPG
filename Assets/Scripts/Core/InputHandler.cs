using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

using ARPG.Events;
using System;
using ARPG.Controller;

namespace ARPG.Core
{
    [CreateAssetMenu(fileName = "InputHandler", menuName = "Game/InputHandler")]
    public class InputHandler : ScriptableObject, InputActions.IPlayerMovementActions, InputActions.IPlayerActionsActions, InputActions.IUIActions
    {
        public InputActions inputActions { get; private set; }

        [SerializeField] Vector2Event onPlayerMove;
        [SerializeField] Vector2Event onPlayerRotateCamera;
        [SerializeField] VoidEvent onPlayerAttackBegin;
        [SerializeField] VoidEvent onPlayerAttackEnd;
        [SerializeField] VoidEvent onPlayerDefenceBegin;
        [SerializeField] VoidEvent onPlayerDefenceEnd;
        [SerializeField] VoidEvent onPlayerJump;
        [SerializeField] BoolEvent onPlayerSprint;
        [SerializeField] VoidEvent onPlayerInteract;
        [SerializeField] VoidEvent onPlayerRemoveWeapon;

        [SerializeField] VoidEvent onPlayerUIInvetory;
        [SerializeField] VoidEvent onPlayerUIUseItem;
        [SerializeField] VoidEvent onPlayerUIDropItem;

        [SerializeField] InputActionsEvent onInputActionsUpdate;
        [SerializeField] BoolEvent onLockPlayerActions;

        void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new InputActions();
                inputActions.PlayerMovement.SetCallbacks(this);
                inputActions.PlayerActions.SetCallbacks(this);
                inputActions.UI.SetCallbacks(this);

            }

            inputActions.Enable();

            onLockPlayerActions.onEventRaised += OnLockPlayerActions;

            onInputActionsUpdate.RaiseEvent(inputActions);
        }

        void OnDisable()
        {
            inputActions.Disable();

            onLockPlayerActions.onEventRaised -= OnLockPlayerActions;
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            onPlayerMove.RaiseEvent(context.ReadValue<Vector2>());
        }

        public void OnRotateCamera(InputAction.CallbackContext context)
        {
            onPlayerRotateCamera.RaiseEvent(context.ReadValue<Vector2>());
        }

        public void OnZoom(InputAction.CallbackContext context)
        {
        }

        public void OnWalk(InputAction.CallbackContext context)
        {
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                onPlayerJump.RaiseEvent();
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
                onPlayerSprint.RaiseEvent(true);
            else if (context.phase == InputActionPhase.Canceled)
                onPlayerSprint.RaiseEvent(false);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                onPlayerAttackBegin.RaiseEvent();

            if (context.phase == InputActionPhase.Canceled)
                onPlayerAttackEnd.RaiseEvent();
        }

        public void OnDefence(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                onPlayerDefenceBegin.RaiseEvent();

            if (context.phase == InputActionPhase.Canceled)
                onPlayerDefenceEnd.RaiseEvent();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                onPlayerInteract.RaiseEvent();
        }

        public void OnRemoveWeapon(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                onPlayerRemoveWeapon.RaiseEvent();
        }

        public void OnInventory(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                onPlayerUIInvetory.RaiseEvent();
        }

        public void OnUseItem(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                onPlayerUIUseItem.RaiseEvent();
        }

        public void OnDropItem(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                onPlayerUIDropItem.RaiseEvent();
        }

        private void OnLockPlayerActions(bool value)
        {
            if (value)
            {
                inputActions.PlayerMovement.Disable();
                inputActions.PlayerActions.Disable();
            }
            else
            {
                inputActions.PlayerMovement.Enable();
                inputActions.PlayerActions.Enable();
            }
        }
    }
}

