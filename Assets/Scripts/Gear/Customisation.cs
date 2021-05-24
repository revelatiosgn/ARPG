using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using ARPG.Inventory;
using ARPG.Events;
using Animancer;

namespace ARPG.Gear
{
    public class Customisation : MonoBehaviour
    {
        [SerializeField] HairTrait hair;
        [SerializeField] EyebrowsTrait eyebrows;
        [SerializeField] BeardTrait beard;

        public HairTrait Hair { get => hair; }
        public EyebrowsTrait Eyebrows { get => eyebrows; }
        public BeardTrait Beard { get => beard; }
    }
}
