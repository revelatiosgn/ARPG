using UnityEngine;
using UnityEngine.Events;

namespace ARPG.Events
{
    [CreateAssetMenu(menuName = "Events/Vector2 Event")]
    public class Vector2Event : ScriptableObject
    {
        public UnityAction<Vector2> onEventRaised;
        public void RaiseEvent(Vector2 value)
        {
            if (onEventRaised != null)
                onEventRaised.Invoke(value);
        }
    }
}
