using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

using ARPG.Gear;
using ARPG.Combat;

namespace ARPG.Inventory
{
    [CreateAssetMenu(fileName = "Shield", menuName = "Items/Equipment/Shield", order = 1)]
    public class ShieldItem : WeaponItem
    {
        [System.Serializable]
        public class ShieldAnimations
        {
            public ClipState.Transition defence;
            public ClipState.Transition damageImpact;
        }

        [Range(0f, 1f)] public float defenceValue = 1f;
        [Range(0f, 360f)] public float defenceAngle = 90f;
        public ShieldAnimations shieldAnimations;
        
        public override void AddActions(BaseCombat baseCombat)
        {
            if (baseCombat == null)
                return;

            baseCombat.DefenceAction = new ShieldDefence(this, baseCombat);
            baseCombat.ShowActions.Add(new ShowWeapon(this, baseCombat));
            baseCombat.HideActions.Add(new HideWeapon(this, baseCombat));
        }
    }
}

