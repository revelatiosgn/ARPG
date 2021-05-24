using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] Transform target;

    void LateUpdate()
    {
        transform.position = target.position;
    }
}
