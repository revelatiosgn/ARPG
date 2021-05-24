using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Stats;
using Lightbug.CharacterControllerPro.Core;
using ARPG.Combat;
using ARPG.Gear;
using ARPG.Core;
using ARPG.Movement;

namespace ARPG.Controller
{
    public enum CharacterGroup
    {
        Neutral = 0,
        Enemy
    }

    public class BaseController : MonoBehaviour
    {
        CharacterStats characterStats;
        CharacterActor characterActor;
        BaseCombat baseCombat;
        Equipment equipment;
        BaseMovement baseMovement;

        public CharacterStats CharacterStats { get => characterStats; }
        public CharacterActor CharacterActor { get => characterActor; }
        public BaseCombat BaseCombat { get => baseCombat; }
        public Equipment Equipment { get => equipment; }
        public BaseMovement BaseMovement { get => baseMovement; }

        [SerializeField] Animatrix animatrix;
        public Animatrix Animatrix { get => animatrix; }

        [SerializeField] CharacterGroup characterGroup;
        public CharacterGroup CharacterGroup { get => characterGroup; }

        protected virtual void Awake()
        {
            characterStats = GetComponent<CharacterStats>();
            characterActor = GetComponent<CharacterActor>();
            baseCombat = GetComponent<BaseCombat>();
            equipment = GetComponent<Equipment>();
            baseMovement = GetComponent<BaseMovement>();
        }
    }
}


