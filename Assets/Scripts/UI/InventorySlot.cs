using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ARPG.Inventory;

namespace ARPG.UI
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] Image icon;
        [SerializeField] Text count;
        [SerializeField] Image selected;
        [SerializeField] Text equipped;

        ItemSlot itemSlot;
        Button button;

        void Awake()
        {
            button = GetComponent<Button>();
        }

        public ItemSlot ItemSlot
        {
            get => itemSlot;
            set
            {
                itemSlot = value;

                if (itemSlot == null)
                {
                    icon.gameObject.SetActive(false);
                    count.gameObject.SetActive(false);
                    SetEquipped(false);
                    button.interactable = false;
                }
                else
                {
                    icon.sprite = itemSlot.Item.icon;
                    icon.gameObject.SetActive(true);
                    
                    if (itemSlot.Count > 1)
                    {
                        count.gameObject.SetActive(true);
                        count.text = itemSlot.Count.ToString();
                    }
                    else
                    {
                        count.gameObject.SetActive(false);
                    }

                    button.interactable = true;
                }
            }
        }
        
        public void SetEquipped(bool value)
        {
            equipped.gameObject.SetActive(value);
        }

        public void SetSelected(bool value)
        {
            selected.gameObject.SetActive(value);
        }

        public void UseItem()
        {
            if (itemSlot != null)
                itemSlot.Item.Use(GameObject.FindGameObjectWithTag(Constants.Tags.Player));
        }
    }
}
