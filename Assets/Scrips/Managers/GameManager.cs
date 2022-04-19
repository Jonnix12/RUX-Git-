using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


namespace Scrips
{
    public class GameManager : MonoBehaviour
    {
         [HideInInspector] public static int sceneIndex = 1;

         private UIManager _uiManager;
         private LevelManager _levelManager;
         private CarManager _carManager;
        
         private void Start()
        {
            DontDestroyOnLoad(this);
            PlayerPrefs.GetInt("SceneIndex(ruseHour)",sceneIndex); 
        }

         public void SetManager(int managerIndex)
         {
             switch (managerIndex)
             {
                 case 1:
                     break;
                 case 2:
                         break;
                     case 3:
                         break;
                         
             }
         }

         public void OnCarExit()
        {
            Debug.Log("End");
            
        }

        
    }
}
