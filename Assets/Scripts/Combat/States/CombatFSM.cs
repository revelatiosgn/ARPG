using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lightbug.CharacterControllerPro.Core;
using ARPG.Core;
using ARPG.Gear;
using ARPG.Inventory;
using ARPG.Stats;
using ARPG.Controller;

namespace ARPG.Combat
{
    public class CombatFSM : BaseFSM<CombatState>
    {
        [SerializeField] BaseController baseController;
        [SerializeField] WeaponItem defaultWeapon;

        public BaseController BaseController { get => baseController; }
        public WeaponItem DefaultWeapon { get => defaultWeapon; }
        public Animatrix Animatrix { get => baseController.Animatrix; }
        public CharacterActor CharacterActor { get => baseController.CharacterActor; }
        public BaseCombat BaseCombat { get => baseController.BaseCombat; }
        public Equipment Equipment { get => baseController.Equipment; }
        public CharacterStats CharacterStats { get => baseController.CharacterStats; }

        void Update()
        {
            UpdateStates(Time.fixedDeltaTime);

            if (CharacterStats.IsDead())
                MakeTransition<IdleState>();
        }
    }
}

