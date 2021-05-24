using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Inventory;

namespace ARPG.Combat
{
    public class HideState : CombatState
    {
        public override void OnEnter()
        {   
            fsm.BaseCombat.HideActions.ForEach(action => {
                action.Start();
            });
        }

        public override void OnExit()
        {
            fsm.BaseCombat.ClearActions();
        }

        public override void OnUpdate(float dt)
        {
            foreach (ICombatAction action in fsm.BaseCombat.HideActions)
                if (!action.IsComplete())
                    return;

            fsm.MakeTransition<IdleState>();
        }
    }   
}

