using System;
using System.Collections;
using System.Collections.Generic;
using ARPG.Events;
using Cinemachine;
using UnityEngine;

namespace ARPG.Core
{
    public class CameraSystem : MonoBehaviour
    {
        [SerializeField] Vector2Event onPlayerRotateCamera;
        [SerializeField] BoolEvent onInventoryActive;

        [SerializeField] CinemachineVirtualCamera freeLookCamera;
        [SerializeField] CinemachineVirtualCamera aimCamera;
        [SerializeField] CameraEvent onCameraFreeLook, onCameraAim;
        [SerializeField] Camera InteractionCamera;

        void OnPlayerRotateCamera(Vector2 value)
        {
        }

        void Awake()
        {
        }

        void OnEnable()
        {
            onPlayerRotateCamera.onEventRaised += OnPlayerRotateCamera;
            onCameraFreeLook.onEventRaised += OnCameraFreeLook;
            onCameraAim.onEventRaised += OnCameraAim;
            onInventoryActive.onEventRaised += OnInventoryActive;
        }

        void OnDisable()
        {
            onPlayerRotateCamera.onEventRaised -= OnPlayerRotateCamera;
            onCameraFreeLook.onEventRaised -= OnCameraFreeLook;
            onCameraAim.onEventRaised -= OnCameraAim;
            onInventoryActive.onEventRaised -= OnInventoryActive;
        }

        void OnCameraFreeLook()
        {
            if (freeLookCamera.Priority == 1)
                return;

            aimCamera.Priority = 0;
            freeLookCamera.Priority = 1;
            freeLookCamera.ForceCameraPosition(aimCamera.transform.position, aimCamera.transform.rotation);
        }

        void OnCameraAim()
        {
            if (aimCamera.Priority == 1)
                return;

            freeLookCamera.Priority = 0;
            aimCamera.Priority = 1;
            aimCamera.ForceCameraPosition(freeLookCamera.transform.position, freeLookCamera.transform.rotation);
        }

        void OnInventoryActive(bool isInventoryActive)
        {
            InteractionCamera.gameObject.SetActive(!isInventoryActive);

            freeLookCamera.enabled = !isInventoryActive;
            aimCamera.enabled = !isInventoryActive;
        }
    }
}


