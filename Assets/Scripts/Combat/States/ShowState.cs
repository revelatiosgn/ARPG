using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Combat
{
    public class ShowState : CombatState
    {
        public override void OnEnter()
        {
            fsm.BaseCombat.ClearActions();

            fsm.BaseCombat.Combatings.ForEach(combating => {
                combating.Object.AddActions(fsm.BaseCombat);
            });

            if (fsm.BaseCombat.AttackAction == null && fsm.DefaultWeapon != null)
                fsm.DefaultWeapon.AddActions(fsm.BaseCombat);

            fsm.BaseCombat.ShowActions.ForEach(action => {
                action.Start();
            });
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate(float dt)
        {
            foreach (ICombatAction action in fsm.BaseCombat.ShowActions)
                if (!action.IsComplete())
                    return;

            fsm.MakeTransition<ActionState>();
        }
    }   
}

