using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ARPG.Movement
{
    public class RootMotionRedirect : MonoBehaviour
    {
        public UnityAction onAnimatorMove;
        public UnityAction<int> onAnimatorIK;

        void OnAnimatorMove()
        {
            onAnimatorMove?.Invoke();
        }

        void OnAnimatorIK(int layerIndex)
        {
            onAnimatorIK?.Invoke(layerIndex);
        }
    }
}

