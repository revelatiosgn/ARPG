using UnityEngine;
using UnityEngine.Events;

using ARPG.Inventory;

namespace ARPG.Events
{
    [CreateAssetMenu(menuName = "Events/Item Event")]
    public class ItemEvent : ScriptableObject
    {
        public UnityAction<Item> onEventRaised;
        public void RaiseEvent(Item value)
        {
            if (onEventRaised != null)
                onEventRaised.Invoke(value);
        }
    }
}
