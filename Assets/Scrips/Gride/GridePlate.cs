using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridePlate : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;
    public int X;
    public int Y;
    public bool CarOverLap = false;

    bool canGo = false;


    private void OnMouseEnter()
    {
        if (CarManager.instant.Target != null)
        {
            if ((CanGoOnTheX) || (CanGoOnTheY))
            {
                Debug.DrawRay(CarManager.instant.Target.transform.position, CarManager.instant.Target.transform.forward);
                mesh.material.color = Color.green;
                canGo = true;
            }
            else
            {
                mesh.material.color = Color.red;
                canGo = false;
            }
        }

    }

    private void OnMouseExit()
    {
        mesh.material.color = Color.white;
    }

    private void OnMouseDown()
    {
        if (canGo)
        {
            CarManager.instant.GetPlate(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Car"))
        {
            CarOverLap = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Contains("Car"))
        {
            CarOverLap = false;
        }
    }

    private bool CanGoOnTheX => X == CarManager.instant.Target.currentPlate.X && CarManager.instant.Target.isFaceForword;

    private bool CanGoOnTheY => Y == CarManager.instant.Target.currentPlate.Y && !CarManager.instant.Target.isFaceForword;

    private bool RayClear => Physics.Raycast(new Ray(CarManager.instant.Target.transform.position, CarManager.instant.Target.transform.forward));
}
