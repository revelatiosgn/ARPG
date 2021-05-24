using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lightbug.CharacterControllerPro.Core;
using ARPG.Core;
using ARPG.Combat;
using ARPG.Stats;
using ARPG.Controller;

namespace ARPG.Movement
{
    public class MovementFSM : BaseFSM<MovementState>
    {
        [SerializeField] BaseController baseController;

        public Animatrix Animatrix { get => baseController.Animatrix; }
        public CharacterActor CharacterActor { get => baseController.CharacterActor; }
        public BaseMovement BaseMovement { get => baseController.BaseMovement; }
        public BaseCombat BaseCombat { get => baseController.BaseCombat; }
        public CharacterStats CharacterStats { get => baseController.CharacterStats; }

        void FixedUpdate()
        {
            UpdateStates(Time.fixedDeltaTime);

            if (CharacterStats.IsDead())
                MakeTransition<DeadState>();
        }
    }
}

