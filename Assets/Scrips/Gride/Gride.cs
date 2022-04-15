using System;
using System.Collections;
using System.Collections.Generic;
using Scrips.Gride;
using UnityEngine;
using UnityEngine.Events;

public class Gride : MonoBehaviour
{
    GridePlate[] gridePlates;



    private void Awake()
    {
        gridePlates = GetComponentsInChildren<GridePlate>();

        int i = 0;

        for (int X = 1; X <= 6; X++)
        {
            for (int Y = 1; Y <= 6; Y++)
            {
                gridePlates[i].X = X;
                gridePlates[i].Y = Y;
                i++;
            }
        }
    }
}
