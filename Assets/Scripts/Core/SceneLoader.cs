using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ARPG.Core
{
    public class SceneLoader : MonoBehaviour
    {
        void Start()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
}


