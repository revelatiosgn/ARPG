using UnityEngine;
using UnityEngine.Events;

namespace ARPG.Events
{
    [CreateAssetMenu(menuName = "Events/InputActions Event")]
    public class InputActionsEvent : ScriptableObject
    {
        public UnityAction<InputActions> onEventRaised;
        public void RaiseEvent(InputActions value)
        {
            if (onEventRaised != null)
                onEventRaised.Invoke(value);
        }
    }
}
