using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Events;

namespace ARPG.Combat
{
    public class PlayerCombat : BaseCombat
    {
        [SerializeField] CameraEvent onCameraFreeLook, onCameraAim;
        
        [SerializeField] VoidEvent onPlayerAttackBegin;
        [SerializeField] VoidEvent onPlayerAttackEnd;
        [SerializeField] VoidEvent onPlayerDefenceBegin;
        [SerializeField] VoidEvent onPlayerDefenceEnd;
        [SerializeField] VoidEvent onPlayerRemoveWeapon;

        void OnEnable()
        {
            onPlayerAttackBegin.onEventRaised += AttackBegin;
            onPlayerAttackEnd.onEventRaised += AttackEnd;
            onPlayerDefenceBegin.onEventRaised += DefenceBegin;
            onPlayerDefenceEnd.onEventRaised += DefenceEnd;
            onPlayerRemoveWeapon.onEventRaised += RemoveWeapon;
        }

        void OnDisable()
        {
            onPlayerAttackBegin.onEventRaised -= AttackBegin;
            onPlayerAttackEnd.onEventRaised -= AttackEnd;
            onPlayerDefenceBegin.onEventRaised -= DefenceBegin;
            onPlayerDefenceEnd.onEventRaised -= DefenceEnd;
            onPlayerRemoveWeapon.onEventRaised -= RemoveWeapon;
        }

        void Update()
        {
            aimRotation = Camera.main.transform.rotation;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.rotation * Vector3.forward, out hit, Mathf.Infinity, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore))
            {
                targetPosition = hit.point;
            }
            else
            {
                targetPosition = Camera.main.transform.position + Camera.main.transform.forward * 30f;
            }
        }

        public override void AttackBegin()
        {
            base.AttackBegin();

            if (CombatState == State.Idle)
                CombatState = State.Action;
        }

        public override void AimBegin()
        {
            StopAllCoroutines();
            StartCoroutine(AimCamera());
        }

        public override void AimEnd()
        {
            StopAllCoroutines();
            StartCoroutine(FreeLookCamera());
        }

        IEnumerator AimCamera()
        {
            yield return new WaitForSeconds(0f);
            onCameraAim.RaiseEvent();
        }

        IEnumerator FreeLookCamera()
        {
            yield return new WaitForSeconds(1.5f);
            onCameraFreeLook.RaiseEvent();
        }

        void RemoveWeapon()
        {
            CombatState = State.Idle;
        }
    }
}


