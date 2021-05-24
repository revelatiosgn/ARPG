using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ARPG.Core
{
    public abstract class InterfaceReference<I> where I : class
    {
        [SerializeField] UnityEngine.Object obj;
        public I Object { get => obj as I; set => obj = value as UnityEngine.Object; }
    }
}


