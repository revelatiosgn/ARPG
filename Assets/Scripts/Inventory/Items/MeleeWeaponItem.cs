using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;
using UnityEngine.Events;

using ARPG.Combat;
using ARPG.Gear;

namespace ARPG.Inventory
{
    [CreateAssetMenu(fileName = "MeleeWeapon", menuName = "Items/Equipment/MeleeWeapon", order = 1)]
    public class MeleeWeaponItem : WeaponItem
    {
        public enum MeleeWeaponType
        {
            Light,
            Heavy
        }

        [System.Serializable]
        public class MeleeAnimations
        {
            public ClipState.Transition[] attacks;
            public ClipState.Transition defence;
            public ClipState.Transition damageImpact;
        }

        public MeleeWeaponType type;
        public float angle = 90f;
        public float damage = 10f;
        public float range = 1f;
        [Range(0f, 1f)] public float defenceValue = 0.5f;
        [Range(0f, 360f)] public float defenceAngle = 90f;
        public MeleeAnimations meleeAnimations;

        public override void AddActions(BaseCombat baseCombat)
        {
            if (baseCombat == null)
                return;

            baseCombat.AttackAction = new MeleeAttack(this, baseCombat);
            if (baseCombat.DefenceAction == null)
                baseCombat.DefenceAction = new MeleeDefence(this, baseCombat);
            baseCombat.ShowActions.Add(new ShowWeapon(this, baseCombat));
            baseCombat.HideActions.Add(new HideWeapon(this, baseCombat));
        }
    }
}

