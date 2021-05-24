using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

using ARPG.Combat;
using ARPG.Gear;

namespace ARPG.Inventory
{
    [CreateAssetMenu(fileName = "RangedWeapon", menuName = "Items/Equipment/RangedWeapon", order = 1)]
    public class RangedWeaponItem : WeaponItem
    {
        [System.Serializable]
        public class RangedAnimations
        {
            public ClipState.Transition grabArrow;
            public ClipState.Transition aim;
            public ClipState.Transition launch;
        }

        public float damage = 10f;
        public float range = 10f;

        public RangedAnimations rangedAnimations;
        
        public override void AddActions(BaseCombat baseCombat)
        {
            if (baseCombat == null)
                return;

            baseCombat.AttackAction = new RangedAttack(this, baseCombat);
            baseCombat.ShowActions.Add(new ShowWeapon(this, baseCombat));
            baseCombat.HideActions.Add(new HideWeapon(this, baseCombat));
        }
    }
}

