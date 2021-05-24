using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Gear
{
    public interface IEquipable
    {
        void Equip(Equipment equipment);
        void Unequip(Equipment equipment);
        bool IsEquipped(Equipment equipment);
    }
}

