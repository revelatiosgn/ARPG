using UnityEngine;
using UnityEngine.Events;

using ARPG.Interactions;

namespace ARPG.Events
{
    [CreateAssetMenu(menuName = "Events/Interactable Event")]
    public class InteractableEvent : ScriptableObject
    {
        public UnityAction<Interactable> onEventRaised;
        public void RaiseEvent(Interactable value)
        {
            if (onEventRaised != null)
                onEventRaised.Invoke(value);
        }
    }
}
