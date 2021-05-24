using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Combat
{
    public class MeleeCollider : MonoBehaviour
    {
        void Awake()
        {
            // gameObject.SetActive(false);
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger");
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(Deactivate());
        }

        IEnumerator Deactivate()
        {
            yield return new WaitForSeconds(0.1f);
            gameObject.SetActive(false);
        }
    }
}

