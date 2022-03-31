using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Car : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 3;

    [HideInInspector] public GridePlate currentPlate;

    private void Start()
    {
        GetCurrentPlate();
    }

    private void OnMouseEnter()
    {
        meshRenderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        meshRenderer.material.color = Color.white;
    }

    private void OnMouseDrag()
    {
        meshRenderer.material.color = Color.red;
        rb.isKinematic = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            float dis = transform.InverseTransformPoint(raycastHit.point).z;
            dis = dis / Math.Abs(dis);

            Vector3 moveTo = transform.forward * dis;
            rb.velocity = moveTo * speed;
        }
    }

    private void OnMouseUp()
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        //meshRenderer.material.color = Color.white;
        GetCurrentPlate();
    }

    void GetCurrentPlate()
    {
        Physics.Raycast(new Ray(transform.position, Vector3.down), out RaycastHit raycastHit, 1f);
        currentPlate = raycastHit.collider.GetComponent<GridePlate>();
        transform.position = new Vector3(currentPlate.transform.position.x, 0.5f, currentPlate.transform.position.z);
    }


}
