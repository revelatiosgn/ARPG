using UnityEngine;
using UnityEngine.Events;

namespace ARPG.Events
{
    [CreateAssetMenu(menuName = "Events/Bool Event")]
    public class BoolEvent : ScriptableObject
    {
        public UnityAction<bool> onEventRaised;
        public void RaiseEvent(bool value)
        {
            if (onEventRaised != null)
                onEventRaised.Invoke(value);
        }
    }
}
