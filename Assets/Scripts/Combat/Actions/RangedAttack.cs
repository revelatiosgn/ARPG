using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

using ARPG.Inventory;
using ARPG.Core;
using ARPG.Movement;
using ARPG.Gear;
using ARPG.Controller;

namespace ARPG.Combat
{
    public class RangedAttack : ICombatAction
    {
        bool isComplete = true;
        RangedWeaponItem item;
        AnimancerLayer layer;
        BaseCombat baseCombat;
        BaseMovement baseMovement;
        Equipment equipment;
        BaseController baseController;
        
        Projectile projectile = null;
        bool isAiming = false;
        Quaternion rotation;
        Quaternion rotationVel;
        bool isIKPass = false;

        AnimancerEvent.Sequence grabArrowEvents;
        AnimancerEvent.Sequence launchEvents;
        
        public RangedAttack(RangedWeaponItem item, BaseCombat baseCombat)
        {
            this.item = item;
            this.baseCombat = baseCombat;
            this.baseMovement = baseCombat.GetComponent<BaseMovement>();
            this.equipment = baseCombat.GetComponent<Equipment>();
            this.baseController = baseCombat.GetComponent<BaseController>();

            layer = baseCombat.Animatrix.GetLayer(Animatrix.LayerName.Torso);

            grabArrowEvents = new AnimancerEvent.Sequence(item.rangedAnimations.grabArrow.Events);
            grabArrowEvents.SetCallback("GrabArrow", () => {
                projectile.gameObject.SetActive(true);
                isIKPass = true;
            });
            grabArrowEvents.OnEnd = () => {
                Aim();
            };

            launchEvents = new AnimancerEvent.Sequence(item.rangedAnimations.launch.Events);
            launchEvents.OnEnd = () => {
                layer.StartFade(0f, 0.2f);
                baseMovement.MovementState = BaseMovement.State.Forward;
                baseCombat.AimEnd();
                baseCombat.Animatrix.onAnimatorIK -= OnAnimatorIK;
                isComplete = true;
            };
            
            baseCombat.AttackRange = item.range;
        }

        public void Start()
        {
            isComplete = false;
            projectile = null;
            baseCombat.Animatrix.onAnimatorIK += OnAnimatorIK;
            GrabArrow();
        }

        public void Act()
        {
            if (isAiming && !baseCombat.IsAttacking)
                Launch();
        }

        public bool IsComplete()
        {
            return isComplete;
        }

        public void Interrupt()
        {
            isComplete = true;
            layer.StartFade(0f, 0.2f);
            baseCombat.Animatrix.onAnimatorIK -= OnAnimatorIK;
        }

        void GrabArrow()
        {
            AnimancerState state = layer.Play(item.rangedAnimations.grabArrow);
            state.Events = grabArrowEvents;
            state.Time = 0f;
            state.ApplyAnimatorIK = true;

            if (baseCombat.Projectile != null && baseCombat.Projectile.Object != null)
                projectile = baseCombat.Projectile.Object.GetProjectile();

            if (projectile == null)
            {
                Interrupt();
                return;
            }

            Transform hand = equipment.GetHolder(HandHolderType.RightHand).transform;
            projectile.transform.parent = hand;
            projectile.transform.position = hand.position;
            projectile.transform.rotation = hand.rotation;
            projectile.gameObject.SetActive(false);

            baseCombat.AimBegin();
            baseMovement.MovementState = BaseMovement.State.Strafe;
        }

        void Aim()
        {
            isAiming = true;

            AnimancerState state = layer.Play(item.rangedAnimations.aim);
            state.Time = 0f;
            state.ApplyAnimatorIK = true;

            if (!baseCombat.IsAttacking)
                Launch();
        }

        void Launch()
        {
            isAiming = false;

            AnimancerState state = layer.Play(item.rangedAnimations.launch);
            state.Events = launchEvents;
            state.Time = 0f;
            state.ApplyAnimatorIK = true;
            isIKPass = false;

            projectile.gameObject.transform.parent = null;
            projectile.AttackDamage.Damage += item.damage;
            projectile.AttackDamage.Source = baseController;
            Vector3 targetPosition = baseCombat.targetPosition;
            Vector3 direction = targetPosition - projectile.transform.position;
            projectile.transform.rotation = Quaternion.LookRotation(direction);
            projectile.Launch();
        }

        public void OnAnimatorIK()
        {
            Animator animator = baseCombat.Animatrix.Animator;
            Transform chestTransform = animator.GetBoneTransform(HumanBodyBones.Spine);
            Quaternion targetRotation = chestTransform.localRotation;

            if (isIKPass)
            {
                targetRotation = Quaternion.Inverse(chestTransform.parent.rotation) * baseCombat.aimRotation;
                targetRotation *= Quaternion.AngleAxis(50f, Vector3.up);
            }

            rotation = Utils.QuaternionUtil.SmoothDamp(rotation, targetRotation, ref rotationVel, 0.1f);
            animator.SetBoneLocalRotation(HumanBodyBones.Spine, rotation);
        }
    }
}


