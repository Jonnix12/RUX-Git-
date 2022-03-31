using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;

    [HideInInspector] public GridePlate currentPlate;

    [HideInInspector] public bool isFaceForword;

    private void Start()
    {
        GetCurrentPlate();

        if ((transform.rotation.eulerAngles.y == 90) || (transform.rotation.eulerAngles.y == 270))
        {
            isFaceForword = false;
        }
        else if ((transform.rotation.eulerAngles.y == 0) || (transform.rotation.eulerAngles.y == 180))
        {
            isFaceForword = true;
        }
        else
        {
            Debug.LogError("Car Rotation Not Vaild " + gameObject.name);
        }
    }

    private void OnMouseEnter()
    {
        meshRenderer.material.color = Color.red;
    }

    private void OnMouseDown()
    {
        CarManager.instant.SetTarget(this);
    }

    private void OnMouseExit()
    {
        meshRenderer.material.color = Color.white;
    }

    void GetCurrentPlate()
    {
        Physics.Raycast(new Ray(transform.position, Vector3.down), out RaycastHit raycastHit, 1f);
        currentPlate = raycastHit.collider.GetComponent<GridePlate>();
        //Debug.Log(currentPlate.name + "X: " + currentPlate.X + "Y: " + currentPlate.Y);
    }

    public IEnumerator MoveForword(int move)
    {
        for (int i = 0; i < move; i++)
        {
            transform.position += transform.forward;
            yield return new WaitForSeconds(1);
        }
        StopAllCoroutines();
        GetCurrentPlate();
    }

    public IEnumerator MoveBackword(int move)
    {
        for (int i = 0; i < move; i++)
        {
            transform.position -= transform.forward;
            yield return new WaitForSeconds(1);
        }
        StopAllCoroutines();
        GetCurrentPlate();
    }

}
