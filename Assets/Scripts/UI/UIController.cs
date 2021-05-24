using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Core;
using System;
using ARPG.Events;

namespace ARPG.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] VoidEvent onPlayerUIInventory;
        [SerializeField] BoolEvent onLockPlayerActions;
        [SerializeField] BoolEvent onInventoryActive;
        [SerializeField] InventoryPanel inventoryPanel;
        [SerializeField] HUDController hudController;

        void Start()
        {
            inventoryPanel.gameObject.SetActive(false);
        }

        void OnEnable()
        {
            onPlayerUIInventory.onEventRaised += OnPlayerUIInventory;
        }

        void OnDisable()
        {
            onPlayerUIInventory.onEventRaised -= OnPlayerUIInventory;
        }

        private void OnPlayerUIInventory()
        {
           inventoryPanel.gameObject.SetActive(!inventoryPanel.gameObject.activeSelf);
           onLockPlayerActions.RaiseEvent(inventoryPanel.gameObject.activeSelf);
        //    hudController.gameObject.SetActive(!inventoryPanel.gameObject.activeSelf);

           onInventoryActive.RaiseEvent(inventoryPanel.gameObject.activeSelf);
        }
    }
}

