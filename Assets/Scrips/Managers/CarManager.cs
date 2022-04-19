using System;
using System.Collections;
using System.Collections.Generic;
using Scrips;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    private GameManager _manager;
    
    private GameObject[] cars;

    private void Awake()
    {
        _manager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
       
        cars = GameObject.FindGameObjectsWithTag("Car");
    }
    
}
