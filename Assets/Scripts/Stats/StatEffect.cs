using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Stats
{
    public class StatEffect
    {
        float value;
        float duration;
        float perSec;
        bool isComplete = false;

        public bool IsComplete { get => isComplete; }

        public StatEffect(float value, float duration)
        {
            this.value = value;
            this.duration = duration;
            this.perSec = value / duration;
            this.isComplete = false;
        }

        public float Update(float dt)
        {
            if (duration <= 0f)
            {
                isComplete = true;
                return value;
            }

            if (isComplete)
                return 0f;

            duration -= dt;
            if (duration <= 0f)
                isComplete = true;

            return perSec * dt;
        }
    }
}

