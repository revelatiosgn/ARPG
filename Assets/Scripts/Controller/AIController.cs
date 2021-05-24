using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using ARPG.AI;
using ARPG.Movement;
using ARPG.Combat;
using ARPG.Gear;

namespace ARPG.Controller
{
    public class AIController : BaseController
    {
        public AIMovement AIMovement { get => BaseMovement as AIMovement; }
        public AICombat AICombat { get => BaseCombat as AICombat; }

        [SerializeField] AILook aiLook;
        public AILook AILook { get => aiLook; }

        void Start()
        {
            aiLook.gameObject.SetActive(true);
        }
    }
}
