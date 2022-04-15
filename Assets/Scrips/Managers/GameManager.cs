using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


namespace Scrips
{
    public class GameManager : MonoBehaviour
    {
         [HideInInspector] public static int sceneIndex = 1;
         
        private void Start()
        {
            DontDestroyOnLoad(this);
            PlayerPrefs.GetInt("SceneIndex(ruseHour)",sceneIndex); 
        }
        
        

        #region SceneManagmant
        
        public void LoadCurrentScene()
        {
            SceneManager.LoadScene(sceneIndex);
        }
        
        public void LoadNextScenes()
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetInt("SceneIndex(ruseHour)",sceneIndex);
        }

        public void LoadLevelSelect()
        {
            SceneManager.LoadScene("LevelSelect");
        }

        public void LoadScene(int scceneIndex)
        {
            SceneManager.LoadScene(scceneIndex);
        }
        
        #endregion

        #region EndScreen

        public void LockCuror(bool cursorStat)
        {
            Cursor.visible = cursorStat;

            if (!cursorStat)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
        }

        public void OnCarExit()
        {
            Debug.Log("End");
            LockCuror(true);
        }

        #endregion
    }
}
