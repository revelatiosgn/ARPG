using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Controller;

namespace ARPG.AI
{
    public class AILook : MonoBehaviour
    {
        [SerializeField] BaseController baseController;

        List<BaseController> potentialTargets = new List<BaseController>();
        List<BaseController> targets = new List<BaseController>();
        public List<BaseController> Targets { get => targets; }

        LayerMask layerMask;

        void Awake()
        {
            layerMask = LayerMask.GetMask("Environment");
        }

        void Update()
        {
            targets.Clear();
            potentialTargets.ForEach(target => {
                if (baseController.CharacterGroup != target.CharacterGroup && !target.CharacterStats.IsDead() && IsCanSee(target))
                    targets.Add(target);
            });
        }
        
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == baseController.gameObject)
                return;

            potentialTargets.Add(other.GetComponent<BaseController>());
        }
        
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject == baseController.gameObject)
                return;

            potentialTargets.Remove(other.GetComponent<BaseController>());
        }
        bool IsCanSee(BaseController target)
        {
            Vector3 direction = ((target.transform.position + Vector3.up) - transform.position);
            float angle = Vector3.Angle(transform.forward, direction);

            if (angle * 2f > 120f)
                return false;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction.normalized, out hit, direction.magnitude, layerMask))
                return false;

            return true;
        }
    }
}
