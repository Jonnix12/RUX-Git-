using System;
using System.Collections;
using System.Collections.Generic;
using Scrips;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    [HideInInspector] public static int sceneIndex = 1;
    
    private GameManager _manager;
    
    private void Awake()
    {
        _manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
