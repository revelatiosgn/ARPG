using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Movement
{
    public class FootIK : MonoBehaviour
    {
        [SerializeField] LayerMask layerMask;
        [SerializeField][Range(0f, 1f)] float raycastOrigin = 0.5f;
        [SerializeField][Range(0f, 1f)] float raycastOffset = 0.5f;
        [SerializeField][Range(0f, 1f)] float footSmoothTime = 0.05f;
        [SerializeField][Range(0f, 1f)] float bodySmoothTime = 0.05f;
        [SerializeField] bool debugDraw = false;

        Animator anim;

        float leftFootDelataY, rightFootDeltaY, bodyDeltaY;
        float leftSmoothSpeed, rightSmoothSpeed;

        void Awake()
        {
            anim = GetComponent<Animator>();
        }

        void Update()
        {
        }

        void OnAnimatorIK(int layerIndex)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1.0f);
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, anim.GetFloat("leftFoot"));
            anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, anim.GetFloat("rightFoot"));

            UpdateFootIK(AvatarIKGoal.LeftFoot, AvatarIKHint.LeftKnee, HumanBodyBones.LeftFoot, ref leftFootDelataY, ref leftSmoothSpeed);
            UpdateFootIK(AvatarIKGoal.RightFoot, AvatarIKHint.RightKnee, HumanBodyBones.RightFoot, ref rightFootDeltaY, ref rightSmoothSpeed);
            UpdateBody();
        }

        void UpdateFootIK(AvatarIKGoal footIKGoal, AvatarIKHint kneeIkHint, HumanBodyBones footBone, ref float footDeltaY, ref float smoothSpeed)
        {
            Vector3 footPosition = anim.GetBoneTransform(footBone).position;
            footPosition.y = transform.position.y;

            Vector3 footIKPosition = anim.GetIKPosition(footIKGoal);
            Vector3 kneeIkPosition = anim.GetIKHintPosition(kneeIkHint);
            float deltaY = 0f;

            Ray ray = new Ray(footPosition + Vector3.up * raycastOrigin, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, raycastOrigin + raycastOffset, layerMask))
            {
                deltaY = hit.point.y - transform.position.y;
                // anim.SetIKRotation(footIKGoal, Quaternion.FromToRotation(Vector3.up, hit.normal) * transform.rotation);
            }

            footDeltaY = Mathf.SmoothDamp(footDeltaY, deltaY, ref smoothSpeed, footSmoothTime);
            footIKPosition.y += footDeltaY;
            kneeIkPosition.y += footDeltaY;

            anim.SetIKPosition(footIKGoal, footIKPosition);
            anim.SetIKHintPosition(kneeIkHint, kneeIkPosition);

            if (debugDraw)
                Debug.DrawLine(footPosition + Vector3.up * raycastOrigin, footPosition + Vector3.down * raycastOffset);
        }

        void UpdateBody()
        {
            bodyDeltaY = Mathf.Min(leftFootDelataY, rightFootDeltaY);
            Vector3 bodyPosition = anim.bodyPosition;
            bodyPosition.y += Mathf.Min(leftFootDelataY, rightFootDeltaY);
            anim.bodyPosition = bodyPosition;
        }
    }
}

