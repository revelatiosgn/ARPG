using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

using ARPG.Stats;
using ARPG.Events;
using ARPG.Interactions;
using ARPG.Core;

namespace ARPG.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] Text health;
        [SerializeField] Text physicArmor;
        [SerializeField] Text magicArmor;
        [SerializeField] Text interaction;

        [SerializeField] InteractableEvent onInteractableStay;
        [SerializeField] VoidEvent onPlayerInteract;
        [SerializeField] InputActionsEvent onInputActionsUpdate;

        [SerializeField] InputHandler inputHandler;

        GameObject player;
        CharacterStats playerStats;
        SphereCollider interactionCollider;
        LayerMask environmentMask;

        public List<Interactable> interactables = new List<Interactable>();


        void Start()
        {
            player = GameObject.FindGameObjectWithTag(Constants.Tags.Player);
            playerStats = player.GetComponent<CharacterStats>();
            interactionCollider = player.GetComponent<SphereCollider>();

            environmentMask = LayerMask.GetMask("Environment");
        }

        void OnEnable()
        {
            onInteractableStay.onEventRaised += OnInteractableStay;
            onPlayerInteract.onEventRaised += OnPlayerInteract;
            onInputActionsUpdate.onEventRaised += OnInputActionsUpdate;
        }

        void OnDisable()
        {
            onInteractableStay.onEventRaised -= OnInteractableStay;
            onPlayerInteract.onEventRaised -= OnPlayerInteract;
            onInputActionsUpdate.onEventRaised -= OnInputActionsUpdate;
        }

        void FixedUpdate()
        {
            UpdateHealth();
            UpdateInteractions();
        }

        void UpdateHealth()
        {
            health.text = playerStats.GetTotalHealth().ToString("F0");
            physicArmor.text = playerStats.GetPhysicArmor().ToString("F0");
            magicArmor.text = playerStats.GetMagicArmor().ToString("F0");
        }

        void UpdateInteractions()
        {
            Interactable interactable = GetInteractable();
            
            if (interactable != null)
            {
                interaction.gameObject.SetActive(true);
                interaction.text = inputHandler.inputActions.PlayerActions.Interact.GetBindingDisplayString();
                interactable.SetHintActive(true);
            }
            else
            {
                interaction.gameObject.SetActive(false);
            }

            interactables.Clear();
        }

        Interactable GetInteractable()
        {
            Interactable target = null;
            float minDot = float.MinValue;

            foreach (Interactable interactable in interactables)
            {
                if (interactable == null)
                    continue;

                interactable.SetHintActive(false);

                RaycastHit hit;
                Vector3 src = interactionCollider.transform.position + interactionCollider.center;
                Vector3 dir = (interactable.transform.position - src).normalized;
                if (!Physics.Raycast(src, dir, out hit, dir.magnitude, environmentMask))
                {
                    float dot = Vector3.Dot(dir, interactionCollider.transform.forward);
                    if (dot > minDot)
                    {
                        minDot = dot;
                        target = interactable;
                    }
                }
            }

            return target;
        }

        void OnInteractableStay(Interactable interactable)
        {
            interactables.Add(interactable);
        }

        void OnPlayerInteract()
        {
            Interactable interactable = GetInteractable();
            if (interactable != null)
                interactable.Interact(player);
        }

        void OnInputActionsUpdate(InputActions inputActions)
        {
        }
    }
}


