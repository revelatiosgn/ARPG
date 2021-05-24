using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Inventory
{
    [System.Serializable]
    public class ItemSlot
    {
        [SerializeField] Item item = null;
        [SerializeField][MinAttribute(1)] int count = 1;

        public Item Item { get => item; }
        public int Count { get => count; set => count = value; }
    }
}
