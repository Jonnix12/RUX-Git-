using System;
using System.Collections;
using System.Collections.Generic;
using Scrips.Gride;
using UnityEngine;
using UnityEngine.Events;

public class Gride : MonoBehaviour
{
    GridePlate[] gridePlates;

    public UnityEvent OnCarExit; 

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("RedCar"))
        {
            Debug.Log("Greadt");
            OnCarExit?.Invoke();
        }
    }


    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(6, 0, 0));
    //     Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(0, 0, 6));
    //     Gizmos.DrawLine(new Vector3(6, 0, 0), new Vector3(6, 0, 6));
    //     Gizmos.DrawLine(new Vector3(0, 0, 6), new Vector3(6, 0, 6));
    //
    //     Gizmos.color = Color.green;
    //     for (int X = 1; X < 6; X++)
    //     {
    //         Gizmos.DrawLine(new Vector3(X, 0, 6), new Vector3(X, 0, 0));
    //         Gizmos.DrawLine(new Vector3(0, 0, X), new Vector3(6, 0, X));
    //     }
    // }
}
