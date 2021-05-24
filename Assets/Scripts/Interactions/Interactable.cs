using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ARPG.Events;

namespace ARPG.Interactions
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] InteractableEvent onInteractableStay;
        [SerializeField] Canvas canvas;
        [SerializeField] Text hintText;

        void Start()
        {
            if (canvas != null)
                canvas.worldCamera = GameObject.FindGameObjectWithTag(Constants.Tags.InteractionCamera).GetComponent<Camera>();

            if (hintText != null)
                hintText.text = GetHintText();

            SetHintActive(false);
        }
        
        public void SetHintActive(bool isHintActive)
        {
            if (canvas != null)
                canvas.gameObject.SetActive(isHintActive);
        }

        void OnTriggerStay(Collider other)
        {
            if (other.tag == Constants.Tags.Player == other.isTrigger)
            {
                onInteractableStay.RaiseEvent(this);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.tag == Constants.Tags.Player == other.isTrigger)
            {
                SetHintActive(false);
            }
        }

        public abstract void Interact(GameObject target);
        protected abstract string GetHintText();
    }
}


