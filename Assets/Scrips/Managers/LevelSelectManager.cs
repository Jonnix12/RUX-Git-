using System.Collections;
using System.Collections.Generic;
using Scrips;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    private int _currnetScene;
    void Start()
    {
        _currnetScene = GameManager.sceneIndex;

        for (int i = 0; i < _currnetScene; i++)
        {
            _buttons[i].interactable = true;
        }
    }

    
}
