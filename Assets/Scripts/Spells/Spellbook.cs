using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Spells
{
    public class Spellbook : MonoBehaviour
    {
        [SerializeField] List<Spell> spells;
        public List<Spell> Spells { get => spells; }
    }
}

