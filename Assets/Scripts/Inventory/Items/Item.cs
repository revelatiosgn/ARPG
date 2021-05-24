using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Inventory
{
    public abstract class Item : ScriptableObject
    {
        public string title = "Unnamed Item";
        public Sprite icon;

        public abstract void Use(GameObject target);
    }
}

