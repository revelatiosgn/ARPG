using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Animancer;
using ARPG.Spells;
using ARPG.Gear;
using ARPG.Core;

namespace ARPG.Combat
{
    public class ShowSpell : ICombatAction
    {
        bool isComplete = true;
        Spell spell;
        AnimancerLayer layer;
        BaseCombat baseCombat;
        Equipment equipment;

        public ShowSpell(Spell spell, BaseCombat baseCombat)
        {
            this.spell = spell;
            this.baseCombat = baseCombat;
            this.equipment = baseCombat.GetComponent<Equipment>();
            layer = baseCombat.Animatrix.GetLayer(spell.handHolder == HandHolderType.LeftHand ? Animatrix.LayerName.LeftHand : Animatrix.LayerName.RightHand);
        }

        public void Start()
        {
            AnimancerState state = layer.Play(spell.spellAnimations.idle);
            state.Time = 0f;
            equipment?.GetSlot(spell)?.EquipmentObject?.SetActive(true);
        }

        public void Act()
        {
        }

        public bool IsComplete()
        {
            return isComplete;
        }

        public void Interrupt()
        {
            isComplete = true;
            layer.StartFade(0f, 0.2f);
        }
    }
}

