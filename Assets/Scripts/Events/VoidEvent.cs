using UnityEngine;
using UnityEngine.Events;

namespace ARPG.Events
{
    [CreateAssetMenu(menuName = "Events/Void Event")]
    public class VoidEvent : ScriptableObject
    {
        public UnityAction onEventRaised;
        public void RaiseEvent()
        {
            if (onEventRaised != null)
                onEventRaised.Invoke();
        }
    }
}
