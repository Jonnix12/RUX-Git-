using System;
using Scrips.Gride;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Scrips
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private float[] chackNums;
        [SerializeField] private float speed = 3;
        [SerializeField] private CarPart front;
        [SerializeField] private CarPart back;

        [HideInInspector] public GridePlate currentPlate;

        [FormerlySerializedAs("SnapCar")] public UnityEvent snapCar;


        private void Awake()
        {
            SetPosition();
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
            SetPosition();
        }

        private void SetPosition()
        {
            snapCar?.Invoke();

            if (front.currentPlate.X == back.currentPlate.X)
            {
                float posZ = (front.currentPlate.transform.position.z + back.currentPlate.transform.position.z) / 2f;
                int posZint = (int)Math.Round(posZ);
                transform.position = new Vector3(front.currentPlate.transform.position.x, transform.position.y, FindPositonXZ(posZint));
            }
            else
            {
                float posX = (front.currentPlate.transform.position.x + back.currentPlate.transform.position.x) / 2f;
                int posXint = (int) Math.Round(posX);
                transform.position = new Vector3(FindPositonXZ(posXint), transform.position.y, front.currentPlate.transform.position.z);
            }
            
        }

        private float FindPositonXZ(float num)
        {
            if (num < 3)
            {
                num = 3;
            }
            
            float sendNum = 0;
            float previousSum = 15;
            
            for (int i = 0; i < chackNums.Length; i++)
            {
                float temp = Math.Abs(chackNums[i] - num);
                if (temp <= previousSum)
                {
                    previousSum = temp;
                    sendNum = chackNums[i];
                } 
            }
            
            return sendNum;
        }
    }
}
