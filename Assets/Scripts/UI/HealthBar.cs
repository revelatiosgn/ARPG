using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ARPG.Stats;

namespace ARPG.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] CharacterStats characterStats;
        [SerializeField] GameObject background;

        Slider slider;

        void Awake()
        {
            slider = GetComponent<Slider>();
        }

        void Update()
        {
            float maxHealth = characterStats.GetStat(StatType.Health).GetValue();
            float health = characterStats.GetTotalHealth();

            slider.maxValue = maxHealth;
            slider.value = health;

            background.SetActive(0f < health && health < maxHealth);
        }
    }
}


