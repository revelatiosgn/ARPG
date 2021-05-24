using System.Collections;
using System.Collections.Generic;
using Animancer;
using UnityEngine;

using ARPG.Controller;
using ARPG.Utils;
using ARPG.Core;

namespace ARPG.Stats
{
    [System.Serializable]
    public class IModifierProviderReference : InterfaceReference<IModifierProvider>
    {
        public IModifierProviderReference(IModifierProvider obj)
        {
            this.Object = obj;
        }
    }

    public class CharacterStats : MonoBehaviour
    {
        [SerializeField] List<CharacterStat> stats = new List<CharacterStat>();
        [SerializeField] List<IModifierProviderReference> providers = new List<IModifierProviderReference>();

        CharacterStat healthStat;
        CharacterStat damageStat;
        CharacterStat physicArmorStat;
        CharacterStat magicArmorStat;

        void Start()
        {
            providers.ForEach(provider => provider.Object.Modify(this));
            stats.ForEach(stat => stat.UpdateModifiers());

            healthStat = GetStat(StatType.Health);
            damageStat = GetStat(StatType.Damage);
            physicArmorStat = GetStat(StatType.PhysicArmor);
            magicArmorStat = GetStat(StatType.MagicArmor);
        }

        void Update()
        {
            stats.ForEach(stat => stat.UpdateEffects(Time.deltaTime));
        }

        public CharacterStat GetStat(StatType statType)
        {
            return stats.Find(stat => stat.StatType == statType);
        }

        public void AddProvider(IModifierProvider provider)
        {
            provider.Modify(this);
            providers.Add(new IModifierProviderReference(provider));
        }

        public void RemoveProvider(IModifierProvider provider)
        {
            stats.ForEach(stat => stat.RemoveModifier(provider));
            providers.RemoveAll(p => p.Object.Equals(provider));
        }

        public float GetTotalHealth()
        {
            if (healthStat != null)
            {
                if (damageStat != null)
                    return healthStat.GetValue() - damageStat.GetValue();
                
                return healthStat.GetValue();
            }

            return 0f;
        }

        public float GetPhysicArmor()
        {
            if (physicArmorStat != null)
                return physicArmorStat.GetValue();

            return 0f;
        }

        public float GetMagicArmor()
        {
            if (magicArmorStat != null)
                return magicArmorStat.GetValue();

            return 0f;
        }

        public bool IsDead()
        {
            return GetTotalHealth() <= 0f;
        }
    }
}