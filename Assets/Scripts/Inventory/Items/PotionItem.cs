using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Stats;

namespace ARPG.Inventory
{
    [CreateAssetMenu(fileName = "Potion", menuName = "Items/Potion", order = 1)]
    public class PotionItem : Item, IConsumable
    {
        public float heal = 30f;
        public float duration = 3f;

        public override void Use(GameObject target)
        {
            CharacterStats characterStats = target.GetComponent<CharacterStats>();
            if (characterStats == null)
                return;

            characterStats.GetStat(StatType.Damage).AddEffect(new StatEffect(-heal, duration));

            Consume(target.GetComponent<ItemStorage>());
        }

        public void Consume(ItemStorage itemStorage)
        {
            if (itemStorage == null)
                return;

            ItemSlot slot = itemStorage.GetSlot(this);
            slot.Count--;

            itemStorage.onConsume?.Invoke(this);
        }
    }
}

