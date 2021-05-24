using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Stats;

namespace ARPG.Movement
{
    public class HeadIK : MonoBehaviour
    {
        Animator anim;
        CharacterStats characterStats;

        void Awake()
        {
            anim = GetComponent<Animator>();
            characterStats = GetComponent<CharacterStats>();
        }

        void Update()
        {
        }

        void OnAnimatorIK(int layerIndex)
        {
            // if (characterStats.health <= 0f)
            //     return;

            Transform headTransform = anim.GetBoneTransform(HumanBodyBones.Head);
            anim.SetLookAtWeight(1.0f);
            anim.SetLookAtPosition(headTransform.position + transform.forward);
        }
    }
}

