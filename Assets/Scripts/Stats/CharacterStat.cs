using System.Collections;
using System.Collections.Generic;
using Animancer;
using UnityEngine;

using ARPG.Controller;
using ARPG.Utils;

namespace ARPG.Stats
{
    public enum StatType
    {
        Health,
        Damage,
        PhysicArmor,
        MagicArmor
    }

    [System.Serializable]
    public class CharacterStat
    {
        [SerializeField] StatType type;
        [SerializeField] float baseValue;
        
        float modifyValue;
        float effectValue;

        List<StatModifier> modifiers = new List<StatModifier>();
        List<StatEffect> effects = new List<StatEffect>();

        public StatType StatType { get => type; }

        public void AddModifier(StatModifier modifier)
        {
            modifiers.Add(modifier);
            UpdateModifiers();
        }

        public void RemoveModifier(object source)
        {
            for (int i = modifiers.Count - 1; i >= 0; i--)
            {
                if (modifiers[i].Source == source)
                {
                    modifiers.RemoveAt(i);
                    UpdateModifiers();
                }
            }
        }

        public void UpdateModifiers()
        {
            modifyValue = baseValue;
            foreach (StatModifier modifier in modifiers)
                modifyValue += modifier.Value;
        }

        public void AddEffect(StatEffect effect)
        {
            effects.Add(effect);
        }

        public void UpdateEffects(float dt)
        {
            for (int i = effects.Count - 1; i >= 0; i--)
            {
                effectValue += effects[i].Update(dt);
                if (effects[i].IsComplete)
                    effects.RemoveAt(i);
            }
        }

        public float GetValue()
        {
            return Mathf.Max(0, modifyValue + effectValue);
        }
    }
}