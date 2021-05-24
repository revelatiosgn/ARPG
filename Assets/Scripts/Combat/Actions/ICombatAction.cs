using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Combat
{
    public interface ICombatAction
    {
        void Start();
        void Act();
        bool IsComplete();
        void Interrupt();
    }
}


