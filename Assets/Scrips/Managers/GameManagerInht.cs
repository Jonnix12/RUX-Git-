using System.Collections;
using System.Collections.Generic;
using Scrips;
using UnityEngine;

public class GameManagerInht : MonoBehaviour
{
    public static GameManager GameManager;

    [SerializeField] private GameObject _gameManager;
    void Start()
    {
        if (GameManager == null)
        {
            GameManager = Instantiate(_gameManager).GetComponent<GameManager>();
        }
    }
}
