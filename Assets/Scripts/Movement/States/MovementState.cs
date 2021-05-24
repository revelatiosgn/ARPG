using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Core;
using Animancer;
using Lightbug.CharacterControllerPro.Core;

namespace ARPG.Movement
{
    public abstract class MovementState : BaseFSMState
    {
        protected MovementFSM fsm;

        void Awake()
        {
            fsm = GetComponent<MovementFSM>();
        }
    }
}

