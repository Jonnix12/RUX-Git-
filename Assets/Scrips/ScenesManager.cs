using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


namespace Scrips
{
    public class ScenesManager : MonoBehaviour
    {
        public int sceneIndex = 0;

        private void Start()
        {
            DontDestroyOnLoad(this);
        }

        public void NextScenes()
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
