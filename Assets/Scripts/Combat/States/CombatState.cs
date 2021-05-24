using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Core;
using Animancer;
using Lightbug.CharacterControllerPro.Core;

namespace ARPG.Combat
{
    public abstract class CombatState : BaseFSMState
    {
        protected CombatFSM fsm;

        void Awake()
        {
            fsm = GetComponent<CombatFSM>();
        }
    }
}

