using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Core;
using ARPG.Movement;
using ARPG.Combat;
using ARPG.Controller;

namespace ARPG.AI
{
    public class AIFSM : BaseFSM<AIState>
    {
        [SerializeField] AIController aiController;

        public AIMovement AIMovement { get => aiController.AIMovement; }
        public AICombat AICombat { get => aiController.AICombat; }
        public AILook AILook { get => aiController.AILook; }

        Vector3 returnPosition;
        public Vector3 ReturnPosition { get => returnPosition; set => returnPosition = value; }

        void Update()
        {
            UpdateStates(Time.deltaTime);
        }
    }
}

