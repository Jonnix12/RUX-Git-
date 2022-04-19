using System;
using System.Collections;
using System.Collections.Generic;
using Scrips;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<GameManager>();
    }

    public void LockCuror(bool cursorStat)
    {
        Cursor.visible = cursorStat;

        if (!cursorStat)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
}
