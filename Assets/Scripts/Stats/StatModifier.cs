using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Stats
{
    public class StatModifier
    {
        [SerializeField] object source;
        [SerializeField] float value;

        public StatModifier(object source, float value)
        {
            this.source = source;
            this.value = value;
        }

        public object Source { get => source; }
        public float Value { get => value; }
    }
}

