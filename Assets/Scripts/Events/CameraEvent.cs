using UnityEngine;
using UnityEngine.Events;

namespace ARPG.Events
{
    [CreateAssetMenu(menuName = "Events/Camera Event")]
    public class CameraEvent : ScriptableObject
    {
        public UnityAction onEventRaised;
        public void RaiseEvent()
        {
            if (onEventRaised != null)
                onEventRaised.Invoke();
        }
    }
}
