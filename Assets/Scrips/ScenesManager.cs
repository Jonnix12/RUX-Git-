using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


namespace Scrips
{
    public class ScenesManager : MonoBehaviour
    {
         [HideInInspector] public int sceneIndex = 1;

        private void Start()
        {
            DontDestroyOnLoad(this);
            PlayerPrefs.GetInt("SceneIndex(ruseHour)",sceneIndex); 
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneIndex);
        }
        
        public void NextScenes()
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetInt("SceneIndex(ruseHour)",sceneIndex);
        }
    }
}
