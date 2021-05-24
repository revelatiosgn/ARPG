using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Core;

namespace ARPG.AI
{
    public abstract class AIState : BaseFSMState
    {
        protected AIFSM fsm;

        void Awake()
        {
            fsm = GetComponent<AIFSM>();
        }
    }
}

