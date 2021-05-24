using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Animancer;

namespace ARPG.Core
{
    public class Animatrix : AnimancerComponent
    {
        public enum LayerName
        {
            Base = 0,
            LeftHand,
            RightHand,
            DualHand,
            Torso,
            Body,
            TorsoAdditive
        }

        [System.Serializable]
        public class AnimatrixLayer
        {
            [SerializeField] LayerName name;
            [SerializeField] AvatarMask avatarMask;
            [SerializeField] bool isAdditive;

            public LayerName Name { get => name; }
            public AvatarMask AvatarMask { get => avatarMask; }
            public bool IsAdditive { get => isAdditive; }
        }

        [SerializeField] List<AnimatrixLayer> animatrixLayers;

        public UnityAction onAnimatorIK;

        void Start()
        {
            AnimancerPlayable.LayerList.SetMinDefaultCapacity(animatrixLayers.Count);

            for (int i = 0; i < animatrixLayers.Count; i++)
            {
                if (animatrixLayers[i].AvatarMask != null)
                    Layers[i].SetMask(animatrixLayers[i].AvatarMask);
                Layers[i].IsAdditive = animatrixLayers[i].IsAdditive;
            }
        }

        public AnimancerLayer GetLayer(LayerName layerName)
        {
            for (int i = 0; i < animatrixLayers.Count; i++)
                if (animatrixLayers[i].Name == layerName)
                    return Layers[i];

            return null;
        }

        public int GetLayerIndex(LayerName layerName)
        {
            for (int i = 0; i < animatrixLayers.Count; i++)
                if (animatrixLayers[i].Name == layerName)
                    return i;

            return -1;
        }

        void OnAnimatorIK(int layerIndex)
        {
            onAnimatorIK?.Invoke();
        }
    }
}