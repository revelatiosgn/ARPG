using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Gear;

namespace ARPG.Combat
{
    public class ActionState : CombatState
    {
        public override void OnEnter()
        {
            fsm.Equipment.onEquip += OnEquip;
            fsm.Equipment.onUnequip += OnUnequip;
        }

        public override void OnExit()
        {
            fsm.Equipment.onEquip -= OnEquip;
            fsm.Equipment.onUnequip -= OnUnequip;
        }

        public override void OnUpdate(float dt)
        {
            if (fsm.BaseCombat.CombatState == BaseCombat.State.Idle)
            {
                fsm.MakeTransition<HideState>();
                return;
            }

            if (fsm.BaseCombat.IsAttacking)
            {
                fsm.MakeTransition<AttackState>();
                return;
            }

            if (fsm.BaseCombat.IsDefending)
            {
                fsm.MakeTransition<DefenceState>();
                return;
            }
        }

        void OnEquip(IEquipable equipmentItem)
        {
            fsm.MakeTransition<ShowState>();
        }

        void OnUnequip(IEquipable equipmentItem)
        {
            fsm.MakeTransition<ShowState>();
        }
    }   
}

