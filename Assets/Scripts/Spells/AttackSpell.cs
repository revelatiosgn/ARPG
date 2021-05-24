using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Combat;

namespace ARPG.Spells
{
    [CreateAssetMenu(fileName = "AttackSpell", menuName = "Spells/AttackSpell", order = 1)]
    public class AttackSpell : Spell
    {
        public override void AddActions(BaseCombat baseCombat)
        {
            if (baseCombat == null)
                return;

            baseCombat.AttackAction = new SpellAttack(this, baseCombat);
            baseCombat.ShowActions.Add(new ShowSpell(this, baseCombat));
            baseCombat.HideActions.Add(new HideSpell(this, baseCombat));
        }
    }
}

