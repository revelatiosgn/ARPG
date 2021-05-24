using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Animancer;
using Lightbug.CharacterControllerPro.Core;

namespace ARPG.Combat
{
    public class IdleState : CombatState
    {
        public override void OnEnter()
        {
            fsm.BaseCombat.ClearActions();
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate(float dt)
        {
            if (fsm.BaseCombat.CombatState == BaseCombat.State.Action && !fsm.CharacterStats.IsDead())
                fsm.MakeTransition<ShowState>();
        }
    }   
}

