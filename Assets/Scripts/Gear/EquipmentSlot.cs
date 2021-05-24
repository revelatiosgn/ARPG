using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Core;

namespace ARPG.Gear
{
    public enum SlotType
    {
        LCombat = 1,
        RCombat = 2,
        Quiver = 4,
        HeadArmor = 8,
        ChestArmor = 16,
        HandsArmor = 32,
        LegsArmor = 64,
        FootsArmor = 128,
        Hair = 256,
        Eyebrows = 512,
        Beard = 1024
    }

    [System.Serializable]
    public class IEquipableReference : InterfaceReference<IEquipable> {}

    public class EquipmentSlot : MonoBehaviour
    {
        [SerializeField] SlotType slotType;
        [SerializeField] IEquipableReference equipable = new IEquipableReference();
        [SerializeField] GameObject equipmentObject;

        public SlotType SlotType { get => slotType; }
        public IEquipable Equipable { get => equipable.Object; set => equipable.Object = value; }
        public GameObject EquipmentObject { get => equipmentObject; set => equipmentObject = value; }
    }
}
